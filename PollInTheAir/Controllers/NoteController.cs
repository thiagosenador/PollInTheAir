using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PollInTheAir.Domain.Models;
using PollInTheAir.Domain.Service;

namespace PollInTheAir.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet]
        public ViewResult CreateNote()
        {
            return this.View();
        }

        [HttpPost]
        public ViewResult CreateNote(Note note, Location location, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                var file = new File
                {
                    FileName = upload.FileName,
                    ContentType = upload.ContentType
                };

                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    file.Content = reader.ReadBytes(upload.ContentLength);
                }

                note.File = file;
            }

            note.UserId = this.User.Identity.GetUserId();
            note.CreationDate = DateTime.Now;
            note.CreationLocation = LocationUtil.ParseLocation(location);

            this.noteService.CreateNote(note);

            return this.View("FinishNoteCreation", note);
        }

        [HttpGet]
        public ViewResult AvailableNotes(Location location)
        {
            var notes = this.noteService.GetAvailableNotes(location);

            return this.View(notes);
        }

        [HttpGet]
        public ActionResult ShowImage(long fileId)
        {
            var imageBytes = this.noteService.GetFile(fileId).Content;

            return this.File(imageBytes, "image/jpg");
        }

        [HttpPost]
        public ActionResult CommentNote(NoteComment comment)
        {
            comment.UserId = this.User.Identity.GetUserId();
            comment.CommentDate = DateTime.Now;

            var newComment = this.noteService.AddNoteComment(comment);
            newComment.User = new User { UserName = this.User.Identity.Name };

            return this.PartialView("Note/_NoteComments", newComment);
        }

        [HttpGet]
        public ViewResult UserNotes()
        {
            var notes = this.noteService.GetUserNotes(new User { Id = this.User.Identity.GetUserId() });

            return this.View(notes);
        }

        [HttpGet]
        public RedirectToRouteResult DeleteNote(long noteId)
        {
            this.noteService.DeleteNote(noteId);

            return this.RedirectToAction("UserNotes");
        }
    }
}

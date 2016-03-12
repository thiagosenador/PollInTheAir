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
        private INoteService noteService;

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
            note.UserId = this.User.Identity.GetUserId();
            note.CreationDate = DateTime.Now;
            note.CreationLocation = LocationUtil.ParseLocation(location);

            this.noteService.CreateNote(note);

            return null;
        }
    }
}

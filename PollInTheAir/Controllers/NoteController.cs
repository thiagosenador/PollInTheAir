using System.Web;
using System.Web.Mvc;
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
            using (var reader = new System.IO.BinaryReader(upload.InputStream))
            {
                note.Image = reader.ReadBytes(upload.ContentLength);
            }

            return null;
        }
    }
}

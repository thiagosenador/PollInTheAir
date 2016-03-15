namespace PollInTheAir.Domain.Service.Impl
{
    using System.Collections.Generic;
    using Models;
    using Repository;

    public class NoteService : INoteService
    {
        private readonly ICatalog catalog;

        public NoteService(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public File GetFile(long id)
        {
            return this.catalog.Files.Find(id);
        }

        public IEnumerable<Note> GetAvailableNotes(Location location)
        {
            return this.catalog.Notes.RetrieveAvailableNotes(location);
        }

        public Note CreateNote(Note note)
        {
            return this.catalog.Notes.Create(note);
        }
    }
}
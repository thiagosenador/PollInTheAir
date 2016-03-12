namespace PollInTheAir.Domain.Service.Impl
{
    using Models;
    using Repository;

    public class NoteService : INoteService
    {
        private readonly ICatalog catalog;

        public NoteService(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public Note CreateNote(Note note)
        {
            return this.catalog.Notes.Create(note);
        }
    }
}
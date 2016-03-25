namespace PollInTheAir.Domain.Repository
{
    using System.Collections.Generic;
    using PollInTheAir.Domain.Models;

    public interface INoteRepository : IRepository<Note>
    {
        IEnumerable<Note> RetrieveAvailableNotes(Location location);

        IEnumerable<Note> RetrieveUserNotes(User currentUser);

        Note RetrieveNote(long noteId);
    }
}
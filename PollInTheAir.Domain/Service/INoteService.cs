namespace PollInTheAir.Domain.Service
{
    using System.Collections.Generic;
    using PollInTheAir.Domain.Models;

    public interface INoteService
    {
        Note CreateNote(Note note);

        IEnumerable<Note> GetAvailableNotes(Location location);
    }
}
namespace PollInTheAir.Domain.Service
{
    using System.Collections.Generic;
    using PollInTheAir.Domain.Models;

    public interface INoteService
    {
        Note CreateNote(Note note);

        File GetFile(long id);

        IEnumerable<Note> GetAvailableNotes(Location location);

        NoteComment AddNoteComment(NoteComment comment);

        IEnumerable<Note> GetUserNotes(User currentUser);

        void DeleteNote(long noteId);

        Note GetNote(long noteId);
    }
}
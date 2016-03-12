namespace PollInTheAir.Domain.Service
{
    using PollInTheAir.Domain.Models;

    public interface INoteService
    {
        Note CreateNote(Note note);
    }
}
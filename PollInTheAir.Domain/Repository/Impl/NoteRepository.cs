namespace PollInTheAir.Domain.Repository.Impl
{
    using PollInTheAir.Domain.Models;

    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
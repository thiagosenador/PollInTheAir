namespace PollInTheAir.Domain.Repository.Impl
{
    using PollInTheAir.Domain.Models;

    public class NoteCommentRepository : Repository<NoteComment>, INoteCommentRepository
    {
        public NoteCommentRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
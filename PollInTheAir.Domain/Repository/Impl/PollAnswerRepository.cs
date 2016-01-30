namespace PollInTheAir.Domain.Repository.Impl
{
    using PollInTheAir.Domain.Models;

    public class PollAnswerRepository : Repository<PollAnswer>, IPollAnswerRepository
    {
        public PollAnswerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
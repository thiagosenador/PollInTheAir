namespace PollInTheAir.Domain.Repository.Impl
{
    using PollInTheAir.Domain.Models;

    public class PollRepository : Repository<Poll>, IPollRepository
    {
        public PollRepository(AppDbContext context) : base(context)
        {
        }
    }
}
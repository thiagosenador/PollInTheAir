namespace PollInTheAir.Domain.Repository.Impl
{
    using System.Data.Entity;
    using System.Linq;

    using PollInTheAir.Domain.Models;

    public class PollRepository : Repository<Poll>, IPollRepository
    {
        public PollRepository(AppDbContext context) : base(context)
        {
        }

        public Poll RetrievePollStructure(long id)
        {
            // TODO INCLUDE CHOICES
            return this.DbSet.Include(q => q.Questions).First(p => p.Id.Equals(id));
        }
    }
}
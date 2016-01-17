using System.Data.Entity;
using PollInTheAir.Domain.Abstract;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Domain.Concrete
{
    public class PollRepository : IPollRepository
    {
        private readonly PollDbContext context = new PollDbContext();

        public DbSet<Poll> Polls
        {
            get { return context.Polls; }
        }
    }
}

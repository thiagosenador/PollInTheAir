using System.Data.Entity;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Domain.Concrete
{
    public class PollDbContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }

        public DbSet<Question> Questions { get; set; }
    }
}

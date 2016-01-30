namespace PollInTheAir.Domain.Repository
{
    using System.Data.Entity;

    using PollInTheAir.Domain.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("InTheAirDB")
        {
        }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<PollAnswer> PollAnswers { get; set; }
    }
}

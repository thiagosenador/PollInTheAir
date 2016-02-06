﻿namespace PollInTheAir.Domain.Repository
{
    using System.Data.Entity;

    using PollInTheAir.Domain.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("InTheAirDB")
        {
        }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<PollAnswer> PollAnswers { get; set; }

        public DbSet<Choice> Choice { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<MultipleChoicesAnswer>().HasMany(m => m.SelectedChoices).WithMany();
        }
    }
}

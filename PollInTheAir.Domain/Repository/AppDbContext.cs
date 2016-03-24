using Microsoft.AspNet.Identity.EntityFramework;

namespace PollInTheAir.Domain.Repository
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using PollInTheAir.Domain.Models;

    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
            : base("name=InTheAir")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<PollAnswer> PollAnswers { get; set; }

        public DbSet<Choice> Choices { get; set; }

        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<NoteComment> NoteComments { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure Asp Net Identity Tables
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<MultipleChoicesAnswer>().HasMany(m => m.SelectedChoices).WithMany();

            modelBuilder.Entity<Note>().HasOptional(n => n.File).WithMany().HasForeignKey(x => x.FileId).WillCascadeOnDelete(true);
        }
    }
}

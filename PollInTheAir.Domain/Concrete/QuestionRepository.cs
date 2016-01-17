using System.Data.Entity;
using PollInTheAir.Domain.Abstract;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Domain.Concrete
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly PollDbContext context = new PollDbContext();

        public DbSet<Question> Questions
        {
            get { return context.Questions; }
        }
    }
}

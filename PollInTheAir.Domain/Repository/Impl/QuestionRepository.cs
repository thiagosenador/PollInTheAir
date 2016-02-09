using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PollInTheAir.Domain.Repository.Impl
{
    using PollInTheAir.Domain.Models;

    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }

        public List<Question> GetQuestionsOfPoll(long pollId)
        {
            var free = this.DbSet.OfType<Question>().Where(q => q.Type == QuestionType.FreeText && q.PollId.Equals(pollId)).ToList();
            var multiple = this.DbSet.OfType<MultipleChoicesQuestion>().Include(c => c.Choices).Where(q => q.PollId.Equals(pollId)).ToList();

            var questions = new List<Question>();
            questions.AddRange(free);
            questions.AddRange(multiple);

            questions.Sort((x, y) => x.Id.CompareTo(y.Id));

            return questions;
        }
    }
}
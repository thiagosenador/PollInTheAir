using System.Collections.Generic;

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

        public Poll RetrievePollStructure(long pollId)
        {
            var free = this.Context.Questions.OfType<Question>().Where(q => q.Type == QuestionType.FreeText && q.PollId.Equals(pollId)).ToList();
            var multiple = this.Context.Questions.OfType<MultipleChoicesQuestion>().Include(c => c.Choices).Where(q => q.PollId.Equals(pollId)).ToList();

            var questions = new List<Question>();
            questions.AddRange(free);
            questions.AddRange(multiple);

            questions.Sort((x, y) => x.Id.CompareTo(y.Id));

            var poll = this.Context.Polls.Find(pollId);
            poll.Questions = questions;

            return poll;
        }
    }
}
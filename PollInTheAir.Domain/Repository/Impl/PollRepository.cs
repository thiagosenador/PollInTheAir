namespace PollInTheAir.Domain.Repository.Impl
{
    using System;
    using System.Collections.Generic;
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

            questions.Sort((x, y) => x.Order.CompareTo(y.Order));

            var poll = this.Context.Polls.Find(pollId);
            poll.Questions = questions;

            return poll;
        }

        public IEnumerable<Poll> RetrievePollsAvailableForAnswer(Location location, User currentUser)
        {
            // TODO APPLY LOCATION FILTER
            return this.Context.Polls.Include(p => p.User)
                .Where(p =>
                p.ExpirationDate.CompareTo(DateTime.Now) > 0
                && !p.UserId.Equals(currentUser.Id)
                && !this.Context.PollAnswers.Any(a => a.PollId.Equals(p.Id) && a.UserId.Equals(currentUser.Id)));
        }

        public IEnumerable<Poll> RetrievePollsAvailableForResult(User currentUser)
        {
            return this.Context.Polls.Where(p => p.UserId.Equals(currentUser.Id));
        }
    }
}
using PollInTheAir.Domain.Models;
using PollInTheAir.Domain.Repository;

namespace PollInTheAir.Domain.Service.Impl
{
    public class PollService : IPollService
    {
        private readonly ICatalog catalog;

        public PollService(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public Poll GetPoll(long pollId)
        {
            var poll = this.catalog.Polls.Find(pollId);

            poll.Questions = this.catalog.Questions.GetQuestionsOfPoll(pollId);

            return poll;
        }
    }
}
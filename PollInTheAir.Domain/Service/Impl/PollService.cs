namespace PollInTheAir.Domain.Service.Impl
{
    using PollInTheAir.Domain.Models;
    using PollInTheAir.Domain.Repository;

    public class PollService : IPollService
    {
        private readonly ICatalog catalog;

        public PollService(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public Poll GetPoll(long pollId)
        {
            return this.catalog.Polls.RetrievePollStructure(pollId);
        }

        public void AddPollAnswer(PollAnswer pollAnswer)
        {
            this.catalog.PollAnswers.AddPollAnswer(pollAnswer);
        }

        public PollResultsSummary GetPollResults(long pollId)
        {
            return this.catalog.PollAnswers.GetPollResults(pollId);
        }
    }
}
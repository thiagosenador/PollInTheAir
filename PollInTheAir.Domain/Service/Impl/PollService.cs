namespace PollInTheAir.Domain.Service.Impl
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repository;

    public class PollService : IPollService
    {
        private readonly ICatalog catalog;

        public PollService(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public void CreatePoll(Poll poll)
        {
            this.catalog.Polls.Create(poll);
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

        public IEnumerable<Poll> GetAvailablePollsForAnswer(Location location, User currentUser)
        {
            return this.catalog.Polls.RetrievePollsAvailableForAnswer(location, currentUser);
        }

        public IEnumerable<Poll> GetAvailablePollsForResult(User currentUser)
        {
            return this.catalog.Polls.RetrievePollsAvailableForResult(currentUser);
        }
    }
}
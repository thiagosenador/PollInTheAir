﻿namespace PollInTheAir.Domain.Service.Impl
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
            poll.CreationDate = DateTime.Now;
            this.catalog.Polls.Create(poll);
        }

        public Poll GetPoll(long pollId)
        {
            return this.catalog.Polls.RetrievePollStructure(pollId);
        }

        public void AddPollAnswer(PollAnswer pollAnswer)
        {
            pollAnswer.AnswerDate = DateTime.Now;
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

        public IEnumerable<Poll> GetUserPolls(User currentUser)
        {
            return this.catalog.Polls.RetrieveUserPolls(currentUser);
        }

        public void DeletePoll(long pollId)
        {
            this.catalog.Polls.Delete(p => p.Id.Equals(pollId));
        }
    }
}
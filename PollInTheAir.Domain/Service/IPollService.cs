namespace PollInTheAir.Domain.Service
{
    using System.Collections.Generic;
    using PollInTheAir.Domain.Models;

    public interface IPollService
    {
        Poll GetPoll(long pollId);

        void CreatePoll(Poll poll);

        void AddPollAnswer(PollAnswer pollAnswer);

        PollResultsSummary GetPollResults(long pollId);

        IEnumerable<Poll> GetAvailablePollsForAnswer(Location location, User currentUser);

        IEnumerable<Poll> GetAvailablePollsForResult(User currentUser);
    }
}
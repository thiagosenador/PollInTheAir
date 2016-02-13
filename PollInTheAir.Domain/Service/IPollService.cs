namespace PollInTheAir.Domain.Service
{
    using PollInTheAir.Domain.Models;

    public interface IPollService
    {
        Poll GetPoll(long pollId);

        void AddPollAnswer(PollAnswer pollAnswer);

        PollResultsSummary GetPollResults(long pollId);
    }
}
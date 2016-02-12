namespace PollInTheAir.Domain.Repository
{
    using PollInTheAir.Domain.Models;

    public interface IPollAnswerRepository : IRepository<PollAnswer>
    {
        void AddPollAnswer(PollAnswer pollAnswer);

        PollResultsSummary GetPollResults(long pollId);
    }
}
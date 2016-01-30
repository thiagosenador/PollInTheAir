namespace PollInTheAir.Domain.Services
{
    using PollInTheAir.Domain.Models;

    public interface IPollService
    {
        void CreatePoll(Poll poll);
    }
}
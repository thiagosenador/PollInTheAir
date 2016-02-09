using PollInTheAir.Domain.Models;

namespace PollInTheAir.Domain.Service
{
    public interface IPollService
    {
        Poll GetPoll(long pollId);
    }
}
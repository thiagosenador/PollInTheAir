namespace PollInTheAir.Domain.Repository
{
    using PollInTheAir.Domain.Models;

    public interface IPollRepository : IRepository<Poll>
    {
        Poll RetrievePollStructure(long id);
    }
}
namespace PollInTheAir.Domain.Repository
{
    using System.Collections.Generic;
    using PollInTheAir.Domain.Models;

    public interface IPollRepository : IRepository<Poll>
    {
        Poll RetrievePollStructure(long id);

        IEnumerable<Poll> RetrievePollsAvailableForAnswer(Location location, User currentUser);

        IEnumerable<Poll> RetrieveUserPolls(User currentUser);
    }
}
namespace PollInTheAir.Domain.Services.Impl
{
    using PollInTheAir.Domain.Models;
    using PollInTheAir.Domain.Repository;
    using PollInTheAir.Domain.Repository.Impl;

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
    }
}
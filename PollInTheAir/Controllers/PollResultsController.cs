namespace PollInTheAir.Web.Controllers
{
    using System.Web.Mvc;

    using PollInTheAir.Domain.Repository;
    using PollInTheAir.Domain.Service;

    public class PollResultsController : Controller
    {
        // TODO REMOVE CATALOG
        private readonly ICatalog catalog;

        private readonly IPollService pollService;

        public PollResultsController(ICatalog catalog, IPollService pollService)
        {
            this.catalog = catalog;
            this.pollService = pollService;
        }

        public ActionResult AvailableResultPolls()
        {
            // TODO APPLY FILTERS
            var availablePools = this.catalog.Polls.All();

            return this.View(availablePools);
        }

        public ActionResult ViewPollResults(long pollId)
        {
            var pollAnswers = this.pollService.GetPollResults(pollId);

            return this.View("PollResults", pollAnswers);
        }
    }
}
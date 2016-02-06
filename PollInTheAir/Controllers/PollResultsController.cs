namespace PollInTheAir.Web.Controllers
{
    using System.Web.Mvc;

    using PollInTheAir.Domain.Repository;

    public class PollResultsController : Controller
    {
        private readonly ICatalog catalog;

        public PollResultsController(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public ActionResult AvailableResultPolls()
        {
            // TODO APPLY FILTERS
            var availablePools = this.catalog.Polls.All();

            return this.View(availablePools);
        }

        public ActionResult ViewPollResults(long pollId)
        {
            var poll = this.catalog.Polls.Find(pollId);

            this.ViewBag.PollName = poll.Name;

            var pollAnswers = this.catalog.PollAnswers.Filter(p => p.Poll.Id.Equals(pollId));

            return this.View("PollResults", pollAnswers);
        }
    }
}
namespace PollInTheAir.Web.Controllers
{
    using System.Web.Mvc;

    using PollInTheAir.Domain.Repository;

    public class PollAnswerController : Controller
    {
        private readonly ICatalog catalog;

        public PollAnswerController(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public ActionResult AvailablePolls(string latitude, string longitude)
        {
            // TODO APPLY FILTERS
            return this.View(this.catalog.Polls.All());
        }

        public ActionResult AnswerPoll(long pollId)
        {
            return this.View(this.catalog.Polls.RetrievePollStructure(pollId));
        }
    }
}
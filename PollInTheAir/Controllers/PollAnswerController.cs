namespace PollInTheAir.Web.Controllers
{
    using System.Web.Mvc;

    using PollInTheAir.Domain.Models;
    using PollInTheAir.Domain.Repository;
    using PollInTheAir.Web.ViewModel;

    public class PollAnswerController : Controller
    {
        private readonly ICatalog catalog;

        public PollAnswerController(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public ActionResult AvailablePolls(Location location)
        {
            // TODO APPLY FILTERS
            return this.View(this.catalog.Polls.All());
        }

        public ActionResult AnswerPoll(long pollId)
        {
            var poll = this.catalog.Polls.RetrievePollStructure(pollId);

            var viewModel = new AnswerPollViewModel { Poll = poll };

            return this.View(viewModel);
        }

        public ActionResult AnswerFreeTextQuestion(FreeTextAnswer questionAnswer)
        {
            return null;
        }

        public ActionResult AnswerQuestion(MultipleChoicesQuestion questionAnswer)
        {
            return null;
        }
    }
}
namespace PollInTheAir.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using PollInTheAir.Domain.Service;

    public class PollResultsController : Controller
    {
        private readonly IPollService pollService;

        public PollResultsController(IPollService pollService)
        {
            this.pollService = pollService;
        }

        public ActionResult AvailableResultPolls()
        {
            var availablePools = this.pollService.GetAvailablePollsForResult(new Domain.Models.User { Id = User.Identity.GetUserId() });

            return this.View(availablePools);
        }

        public ActionResult ViewPollResults(long pollId)
        {
            var pollAnswers = this.pollService.GetPollResults(pollId);

            return this.View("PollResults", pollAnswers);
        }
    }
}
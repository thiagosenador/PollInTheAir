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

        public ActionResult UserPolls()
        {
            var availablePools = this.pollService.GetUserPolls(new Domain.Models.User { Id = this.User.Identity.GetUserId() });

            return this.View(availablePools);
        }

        public ActionResult ViewPollResults(long pollId)
        {
            var pollAnswers = this.pollService.GetPollResults(pollId);

            return this.View("PollResults", pollAnswers);
        }

        public RedirectToRouteResult DeletePoll(long pollId)
        {
            this.pollService.DeletePoll(pollId);

            return this.RedirectToAction("UserPolls");
        }
    }
}
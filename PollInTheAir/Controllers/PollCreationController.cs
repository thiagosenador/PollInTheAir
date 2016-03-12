namespace PollInTheAir.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    using Domain.Service;
    using Microsoft.AspNet.Identity;

    using PollInTheAir.Domain.Models;

    public class PollCreationController : Controller
    {
        private const string PollKey = "poll";

        private readonly IPollService pollService;

        public PollCreationController(IPollService pollService)
        {
            this.pollService = pollService;
        }

        [HttpGet]
        public ViewResult CreatePoll()
        {
            return this.View();
        }

        [HttpPost]
        public RedirectToRouteResult CreatePoll(QuestionType questionType, Poll poll, Location location)
        {
            poll.Questions = new List<Question>();
            poll.CreationLocation = LocationUtil.ParseLocation(location);

            this.Session[PollKey] = poll;

            return this.GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public RedirectToRouteResult CreateMultipleChoicesQuestion(QuestionType questionType, MultipleChoicesQuestion question)
        {
            var poll = (Poll)this.Session[PollKey];

            question.Type = QuestionType.MultipleChoices;
            question.Order = (short)poll.Questions.Count;

            poll.Questions.Add(question);

            return this.GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public RedirectToRouteResult CreateFreeTextQuestion(QuestionType questionType, Question question)
        {
            var poll = (Poll)this.Session[PollKey];

            question.Type = QuestionType.FreeText;
            question.Order = (short)poll.Questions.Count;

            poll.Questions.Add(question);

            return this.GoToCreateQuestion(questionType);
        }

        [HttpGet]
        public ViewResult CreateMultipleChoicesQuestion()
        {
            return this.View();
        }

        [HttpGet]
        public ViewResult CreateFreeTextQuestion()
        {
            return this.View();
        }

        public ViewResult FinishPollCreation()
        {
            Poll poll = (Poll)this.Session[PollKey];

            return this.View("ReviewPoll", poll);
        }

        public ActionResult PublishPoll()
        {
            var poll = (Poll)this.Session[PollKey];
            poll.UserId = this.User.Identity.GetUserId();

            this.pollService.CreatePoll(poll);

            return this.View("FinishPollPublish", poll);
        }

        private RedirectToRouteResult GoToCreateQuestion(QuestionType questionType)
        {
            if (questionType.Equals(QuestionType.FreeText))
            {
                return this.RedirectToAction("CreateFreeTextQuestion");
            }

            if (questionType.Equals(QuestionType.MultipleChoices))
            {
                return this.RedirectToAction("CreateMultipleChoicesQuestion");
            }

            return this.RedirectToAction("FinishPollCreation");
        }
    }
}
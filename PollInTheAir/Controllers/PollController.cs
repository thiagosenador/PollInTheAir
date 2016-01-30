namespace PollInTheAir.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using PollInTheAir.Domain.Models;
    using PollInTheAir.Domain.Services;

    public class PollController : Controller
    {
        private const string PollKey = "poll";

        private readonly IPollService pollService;

        public PollController(IPollService pollService)
        {
            this.pollService = pollService;
        }

        [HttpGet]
        public ViewResult CreatePoll()
        {
            return this.View();
        }

        [HttpPost]
        public RedirectToRouteResult CreatePoll(string questionType, Poll poll)
        {
            poll.Questions = new List<Question>();

            this.Session[PollKey] = poll;

            return this.GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public RedirectToRouteResult CreateMultipleChoicesQuestion(List<string> choices, string questionType, MultipleChoicesQuestion question)
        {
            foreach (var choice in choices)
            {
                question.Choices.Add(new Choice { Text = choice });
            }

            ((Poll)Session[PollKey]).Questions.Add(question);

            return this.GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public RedirectToRouteResult CreateFreeTextQuestion(string questionType, Question question)
        {
            ((Poll)Session[PollKey]).Questions.Add(question);

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
            Poll poll = (Poll)Session[PollKey];

            return this.View("ReviewPollView", poll);
        }

        public ActionResult PublishPoll()
        {
            var poll = (Poll)this.Session[PollKey];

            poll.CreatedAt = DateTime.Now;

            this.pollService.CreatePoll(poll);

            return null;
        }

        private RedirectToRouteResult GoToCreateQuestion(string questionType)
        {
            if (questionType.Equals("free text"))
            {
                return this.RedirectToAction("CreateFreeTextQuestion");
            }

            if (questionType.Equals("multiple choices"))
            {
                return this.RedirectToAction("CreateMultipleChoicesQuestion");
            }

            if (string.IsNullOrEmpty(questionType))
            {
                return this.RedirectToAction("FinishPollCreation");
            }

            return null;
        }
    }
}
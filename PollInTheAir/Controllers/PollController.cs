using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PollInTheAir.Domain.Abstract;
using PollInTheAir.Domain.Concrete;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Web.Controllers
{
    public class PollController : Controller
    {
        private const string PollKey = "poll";

        private readonly IPollRepository pollRepository;

        public PollController(IPollRepository pollRepository)
        {
            this.pollRepository = pollRepository;
        }

        [HttpGet]
        public ViewResult CreatePoll()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult CreatePoll(string questionType, Poll poll)
        {
            poll.Questions = new List<Question>();

            Session[PollKey] = poll;

            return GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public RedirectToRouteResult CreateMultipleChoicesQuestion(List<string> choices, string questionType, MultipleChoicesQuestion question)
        {
            foreach (var choice in choices)
            {
                question.Choices.Add(new Choice {Text = choice});
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
            return View();
        }

        [HttpGet]
        public ViewResult CreateFreeTextQuestion()
        {
            return View();
        }

        public ViewResult FinishPollCreation()
        {
            Poll poll = (Poll)Session[PollKey];

            return View("ReviewPollView", poll);
        }

        private RedirectToRouteResult GoToCreateQuestion(string questionType)
        {
            if (questionType.Equals("free text"))
            {
                return RedirectToAction("CreateFreeTextQuestion");
            }

            if (questionType.Equals("multiple choices"))
            {
                return RedirectToAction("CreateMultipleChoicesQuestion");
            }

            if (string.IsNullOrEmpty(questionType))
            {
                return RedirectToAction("FinishPollCreation");
            }

            return null;
        }

        public ActionResult PublishPoll()
        {
            var poll = (Poll)Session[PollKey];

            poll.CreatedAt = DateTime.Now;

            var context = new PollDbContext();
            context.Polls.Add(poll);
            context.SaveChanges();

            return null;
        }
    }
}
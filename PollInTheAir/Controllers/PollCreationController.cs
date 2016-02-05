﻿namespace PollInTheAir.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using PollInTheAir.Domain.Models;
    using PollInTheAir.Domain.Repository;

    public class PollCreationController : Controller
    {
        private const string PollKey = "poll";

        private readonly ICatalog catalog;

        public PollCreationController(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        [HttpGet]
        public ViewResult CreatePoll()
        {
            return this.View();
        }

        [HttpPost]
        public RedirectToRouteResult CreatePoll(QuestionType questionType, Poll poll)
        {
            poll.Questions = new List<Question>();

            this.Session[PollKey] = poll;

            return this.GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public RedirectToRouteResult CreateMultipleChoicesQuestion(QuestionType questionType, MultipleChoicesQuestion question)
        {
            ((Poll)Session[PollKey]).Questions.Add(question);

            return this.GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public RedirectToRouteResult CreateFreeTextQuestion(QuestionType questionType, Question question)
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

            return this.View("ReviewPoll", poll);
        }

        public ActionResult PublishPoll()
        {
            var poll = (Poll)this.Session[PollKey];

            poll.CreationDate = DateTime.Now;

            this.catalog.Polls.Create(poll);

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
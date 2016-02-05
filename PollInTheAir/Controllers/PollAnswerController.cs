namespace PollInTheAir.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using PollInTheAir.Domain.Models;
    using PollInTheAir.Domain.Repository;
    using PollInTheAir.Web.ViewModel;

    public class PollAnswerController : Controller
    {
        private const string PollAnswerKey = "poll_answer";
        private const string PollKey = "current_poll";

        private readonly ICatalog catalog;

        public PollAnswerController(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public ActionResult AvailablePolls(Location location)
        {
            // TODO APPLY LOCATION FILTER
            var availablePools = this.catalog.Polls.Filter(p => p.ExpirationDate.CompareTo(DateTime.Now) > 0);

            return this.View(availablePools);
        }

        public ActionResult AnswerPoll(long pollId)
        {
            // TODO DO I NEED THE EXTRA METHOD IN POLLREPOSITORY???
            var poll = this.catalog.Polls.RetrievePollStructure(pollId);

            this.Session[PollKey] = poll;
            this.Session[PollAnswerKey] = new PollAnswer { PollId = poll.Id, QuestionAnswers = new List<QuestionAnswer>() };

            return this.RedirectToAction("AnswerQuestion");
        }

        public ActionResult AnswerQuestion()
        {
            var pollAnswer = (PollAnswer)this.Session[PollAnswerKey];
            var poll = (Poll)this.Session[PollKey];

            if (pollAnswer.QuestionAnswers.Count < poll.Questions.Count)
            {
                var viewModel = new AnswerPollViewModel
                {
                    PollName = poll.Name,
                    CurrentQuestion = poll.Questions[pollAnswer.QuestionAnswers.Count]
                };

                return this.View(viewModel);
            }

            return this.RedirectToAction("FinishAnswerPoll");
        }

        public ActionResult FinishAnswerFreeTextQuestion(FreeTextAnswer questionAnswer)
        {
            var pollAnswer = (PollAnswer)this.Session[PollAnswerKey];

            pollAnswer.QuestionAnswers.Add(questionAnswer);

            return this.RedirectToAction("AnswerQuestion");
        }

        public ActionResult FinishAnswerMultipleChoicesQuestion(long[] selectedChoices, MultipleChoicesAnswer questionAnswer)
        {
            var pollAnswer = (PollAnswer)this.Session[PollAnswerKey];

            // TODO CAN REMOVE THE INPUT LIST???
            foreach (long choiceId in selectedChoices)
            {
                questionAnswer.SelectedChoices.Add(new Choice { Id = choiceId });
            }

            pollAnswer.QuestionAnswers.Add(questionAnswer);

            return this.RedirectToAction("AnswerQuestion");
        }

        public ActionResult FinishAnswerPoll()
        {
            var pollAnswer = (PollAnswer)this.Session[PollAnswerKey];
            var poll = (Poll)this.Session[PollKey];

            pollAnswer.AnswerDate = DateTime.Now;

            this.catalog.PollAnswers.Create(pollAnswer);

            return this.View(poll);
        }
    }
}
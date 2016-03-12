namespace PollInTheAir.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using PollInTheAir.Domain.Models;
    using PollInTheAir.Domain.Service;
    using PollInTheAir.Web.ViewModel;

    public class PollAnswerController : Controller
    {
        private const string PollAnswerKey = "poll_answer";
        private const string PollKey = "current_poll";

        private readonly IPollService pollService;

        public PollAnswerController(IPollService pollService)
        {
            this.pollService = pollService;
        }

        public ActionResult AvailablePolls(Location location)
        {
            var user = new User { Id = this.User.Identity.GetUserId() };

            var availablePools = this.pollService.GetAvailablePollsForAnswer(location, user);

            return this.View(availablePools);
        }

        public ActionResult AnswerPoll(long pollId)
        {
            var poll = this.pollService.GetPoll(pollId);

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

            return this.RedirectToAction("FinishPollAnswer");
        }

        public ActionResult FinishAnswerFreeTextQuestion(FreeTextAnswer questionAnswer)
        {
            var pollAnswer = (PollAnswer)this.Session[PollAnswerKey];

            pollAnswer.QuestionAnswers.Add(questionAnswer);

            return this.RedirectToAction("AnswerQuestion");
        }

        public ActionResult FinishAnswerMultipleChoicesQuestion(MultipleChoicesQuestion multipleChoicesQuestion)
        {
            var questionAnswer = new MultipleChoicesAnswer
            {
                SelectedChoices = new List<Choice>(multipleChoicesQuestion.Choices.Where(c => c.Selected)),
                QuestionId = multipleChoicesQuestion.Id
            };

            var pollAnswer = (PollAnswer)this.Session[PollAnswerKey];

            pollAnswer.QuestionAnswers.Add(questionAnswer);

            return this.RedirectToAction("AnswerQuestion");
        }

        public ActionResult FinishPollAnswer()
        {
            var pollAnswer = (PollAnswer)this.Session[PollAnswerKey];
            pollAnswer.UserId = this.User.Identity.GetUserId();

            var poll = (Poll)this.Session[PollKey];

            this.pollService.AddPollAnswer(pollAnswer);

            return this.View(poll);
        }
    }
}
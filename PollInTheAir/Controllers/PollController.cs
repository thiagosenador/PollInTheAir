using System.Collections.Generic;
using System.Web.Mvc;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Web.Controllers
{
    public class PollController : Controller
    {
        private const string PollKey = "poll";

        [HttpGet]
        public ViewResult CreatePoll()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CreatePoll(string questionType, Poll poll)
        {
            poll.Questions = new List<Question>();

            Session[PollKey] = poll;

            return GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public ViewResult CreateMultipleChoicesQuestion(string questionType, MultipleChoicesQuestion question)
        {
            ((Poll)Session[PollKey]).Questions.Add(question);

            return this.GoToCreateQuestion(questionType);
        }

        [HttpPost]
        public ViewResult CreateFreeTextQuestion(string questionType, Question question)
        {
            ((Poll)Session[PollKey]).Questions.Add(question);

            return this.GoToCreateQuestion(questionType);
        }

        [HttpGet]
        public ViewResult CreateMultipleChoicesQuestion()
        { 
            return View("CreateMultipleChoicesQuestion");
        }

        [HttpGet]
        public ViewResult CreateFreeTextQuestion()
        {
            return View("CreateFreeTextQuestion");
        }

        public ViewResult FinishQuestion(Question question)
        {
            Poll poll = (Poll)Session[PollKey];
            poll.Questions.Add(question);

            return View("CreateMultipleChoicesQuestion");
        }

        private ViewResult GoToCreateQuestion(string questionType)
        {
            if (questionType.Equals("free text"))
            {
                return this.CreateFreeTextQuestion();
            }

            if (questionType.Equals("multiple choices"))
            {
                return this.CreateMultipleChoicesQuestion();
            }

            return null;
        }
    }
}
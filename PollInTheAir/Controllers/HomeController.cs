using System.Collections.Generic;
using System.Web.Mvc;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Web.Controllers
{
    public class HomeController : Controller
    {
        private List<Question> questions = new List<Question>(); 

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult CreatePoll()
        {
            return View();
        }

        [HttpGet]
        public ViewResult CreateMultipleChoicesQuestion()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CreateMultipleChoicesQuestion(MultipleChoicesQuestion question)
        {
            this.questions.Add(question);

            return View();
        }

        [HttpGet]
        public ViewResult CreateFreeTextQuestion()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CreateFreeTextQuestion(Question question)
        {
            this.questions.Add(question);

            return View();
        }

        public ViewResult FinishQuestion()
        {
            this.ToString();

            return null;
        }
    }
}
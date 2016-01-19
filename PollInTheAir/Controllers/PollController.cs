using System.Web.Mvc;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Web.Controllers
{
    public class PollController : Controller
    {
        [HttpGet]
        public ViewResult CreatePoll()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CreatePoll(Poll poll)
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
            return View();
        }

        public ViewResult FinishQuestion(MultipleChoicesQuestion question)
        {
            this.ToString();

            return View("CreateMultipleChoicesQuestion");
        }
    }
}
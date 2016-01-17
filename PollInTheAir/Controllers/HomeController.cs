using PollInTheAir.Models;
using System.Web.Mvc;

namespace PollInTheAir.Controllers
{
    public class HomeController : Controller
    {
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
            question.ToString();

            return View();
        }
    }
}
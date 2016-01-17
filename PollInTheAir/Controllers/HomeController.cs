using System.Web.Mvc;
using PollInTheAir.Domain.Concrete;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Web.Controllers
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
            using (var context = new PollDbContext())
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }

            return View();
        }
    }
}
using System.Web.Mvc;

namespace PollInTheAir.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
namespace PollInTheAir.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return this.View();
        }

        // TODO GET THE LOCATION WHEN CLICK ON VIEW POLLS BUTTON
        // TODO PROVIDE HANDLING FOR BROWSER WHICH DOESNT SUPPORT LOCATION
    }
}
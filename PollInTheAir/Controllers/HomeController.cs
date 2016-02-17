namespace PollInTheAir.Web.Controllers
{
    using System.Web.Mvc;

    [RequireHttps]
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return this.View();
        }

        // TODO CLIENT SIDE VALIDATION
        // TODO DISPLY AT LEAST TWO OPTIONS ON MULTIPLE CHOICE CREATION
    }
}
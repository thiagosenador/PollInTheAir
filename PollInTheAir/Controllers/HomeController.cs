namespace PollInTheAir.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ViewResult Home()
        {
            return this.View();
        }

        [RequireHttps]
        [Authorize]
        public ViewResult Index()
        {
            return this.View();
        }

        // TODO CLIENT SIDE VALIDATION ON MULTIPLE CHOICE CREATION
        // TODO DISPLY AT LEAST TWO OPTIONS ON MULTIPLE CHOICE CREATION
        // TODO TWO PAGES ASKING FOR PERMISSION ON LOCATION
        // TODO EMAIL SERVICE FOR POLL RESULTS
        // TODO DRAW THE RANGE IN PICTURE WHEN PUBLISHING A POLL
        // TODO VALIDATE FILE TYPE ON UPLOAD USING JQUERY
    }
}
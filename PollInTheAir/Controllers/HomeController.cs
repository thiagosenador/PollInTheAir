﻿namespace PollInTheAir.Web.Controllers
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

        // TODO CLIENT SIDE VALIDATION
        // TODO DISPLY AT LEAST TWO OPTIONS ON MULTIPLE CHOICE CREATION
        // TODO TWO PAGES ASKING FOR PERMISSION ON LOCATION
        // TODO EMAIL SERVICE FOR POLL RESULTS
        // TODO PASS LOCATION AS PARAMETER IN HOME PAGE
    }
}
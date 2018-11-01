using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About the fitness studio.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the gym.";

            return View();
        }
    }
}
using System.Web.Mvc;

namespace Fitness.Web.Controllers
{
    using System.Web.Security;

    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            if (username == "IvoKostovski" && password == "admin")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return new RedirectResult("~/Trainers/Index");
            }
            else
            {
                return new RedirectResult("~/Users/LogIn");
            }
        }

        [HttpGet]
        [Authorize]
        public RedirectResult LogOut()
        {
            FormsAuthentication.SignOut();
            return new RedirectResult("~/Users/LogIn");
        }
    }
}
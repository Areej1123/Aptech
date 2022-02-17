using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        AptechDbContext db = new AptechDbContext();

        [Authorize]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            var std = db.Students.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (std == null)
            {
                ViewBag.msg = "Email or password incorrect";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(std.Email, true);
                return RedirectToAction("index");
            }

        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
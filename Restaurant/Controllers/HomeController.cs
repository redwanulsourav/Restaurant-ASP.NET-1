using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private RestaurantEntities obj = new RestaurantEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Signup log)
        {
            var login = obj.Signups.Where(x => x.username == log.username && x.password == log.password).FirstOrDefault();
            if(login != null)
            {
                Session["username"] = log.username;
                return RedirectToAction("ManagerProfile");
            }
            else
            {
                ViewBag.Errormessage = "Username or Password is incorrect";
                return View("Login", log);
            }

            
        }

        [HttpGet]
        public ActionResult ManagerProfile()
        {
            var username = Session["username"];
            var mang = obj.Signups.Where(x => x.username == username).FirstOrDefault();
            return View(mang);
        }
    }
}
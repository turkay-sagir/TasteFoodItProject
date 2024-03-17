using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TasteFoodIt.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Username"]!=null)
            {
                ViewBag.Username = Session["Username"];
                ViewBag.NameSurname = Session["NameSurname"];
                ViewBag.ProfilePhoto = Session["ProfilePhoto"];
                return View();
            }

            else
            { 
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;
using System.Web.Security;

namespace TasteFoodIt.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = context.Admins.FirstOrDefault(x=>x.Username==p.Username && x.Password==p.Password);

            if(values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.Username,true);
                Session["Username"] = values.Username;
                Session["NameSurname"] = values.NameSurname;
                Session["ProfilePhoto"] = values.ProfilePhoto;
                
                return RedirectToAction("Index","Profile");
            }

            else
            {
                ViewBag.error = "Giriş Başarısız!";
                return View();
            }

            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }

    }
}
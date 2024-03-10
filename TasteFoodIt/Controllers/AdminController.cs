using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AdminList()
        {
            var values = context.Admins.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(Admin p)
        {
            context.Admins.Add(p);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var value = context.Admins.Find(id);
            context.Admins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = context.Admins.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {
            var value = context.Admins.Find(p.AdminId);

            value.Username = p.Username;
            value.Password = p.Password;

            context.SaveChanges();
            return RedirectToAction("AdminList");
        }


    }
}
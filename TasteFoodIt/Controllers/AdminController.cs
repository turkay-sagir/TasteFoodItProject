using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult CreateAdmin(Admin p, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/image/"), fileName);

                file.SaveAs(path);
                p.ProfilePhoto = Path.Combine("/Templates/tasteit-master/image/", fileName);
            }

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
        public ActionResult UpdateAdmin(Admin p, HttpPostedFileBase file)
        {
            var value = context.Admins.Find(p.AdminId);

            if(file!=null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/image/"), fileName);

                file.SaveAs(path);
                value.ProfilePhoto = Path.Combine("/Templates/tasteit-master/image/", fileName);
            }

            value.Username = p.Username;
            value.Password = p.Password;
            value.NameSurname = p.NameSurname;

            context.SaveChanges();
            return RedirectToAction("AdminList");
        }


    }
}
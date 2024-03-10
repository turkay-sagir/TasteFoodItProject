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
    public class ChefController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult Index()
        {
            ViewBag.PageTitle = "Şeflerimiz";
            return View();
        }
        public ActionResult ChefList()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateChef(Chef p, HttpPostedFileBase file)
        {
            if(file!=null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images/"),fileName);

                file.SaveAs(path);
                p.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            context.Chefs.Add(p);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }

        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            context.Chefs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }

        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateChef(Chef p, HttpPostedFileBase file)
        {
            var value = context.Chefs.Find(p.ChefId);

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images/"), fileName);

                file.SaveAs(path);
                value.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            value.NameSurname = p.NameSurname;
            value.Title = p.Title;
            value.Description = p.Description;

            context.SaveChanges();
            return RedirectToAction("ChefList");
        }


    }
}
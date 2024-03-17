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
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.PageTitle = "Hakkımızda";
            return View();
        }
        public ActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            ViewBag.num1 = context.Abouts.Count();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            ViewBag.num2 = context.Abouts.Count();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About p, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images/"), fileName);

                file.SaveAs(path);

                p.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            context.Abouts.Add(p);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About p, HttpPostedFileBase file)
        {
            var value = context.Abouts.Find(p.AboutId);
            
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images/"), fileName);

                file.SaveAs(path);

                value.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            value.Title = p.Title;
            value.Description = p.Description;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }




    }
}
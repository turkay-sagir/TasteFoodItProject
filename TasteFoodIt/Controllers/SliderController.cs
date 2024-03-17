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
    public class SliderController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult SliderList()
        {
            var values = context.Sliders.ToList();
            ViewBag.num1 = context.Sliders.Count();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSlider()
        {
            ViewBag.num2 = context.Sliders.Count();
            return View();
            
        }

        [HttpPost]
        public ActionResult CreateSlider(Slider p, HttpPostedFileBase file)
        {
            if(file!=null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images"),fileName);

                file.SaveAs(path);
                p.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            context.Sliders.Add(p);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        public ActionResult DeleteSlider(int id)
        {
            var value = context.Sliders.Find(id);
            context.Sliders.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var value = context.Sliders.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSlider(Slider p, HttpPostedFileBase file)
        {
            var value = context.Sliders.Find(p.SliderId);

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images"), fileName);

                file.SaveAs(path);
                value.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            value.Title = p.Title;
            value.Description = p.Description;

            context.SaveChanges();
            return RedirectToAction("SliderList");
        }


    }
}
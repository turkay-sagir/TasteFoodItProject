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
    public class TestimonialController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult TestimonialList()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial p, HttpPostedFileBase file)
        {
            if(file!=null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images/"), fileName);

                file.SaveAs(path);

                p.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            context.Testimonials.Add(p);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial p, HttpPostedFileBase file)
        {
            var value = context.Testimonials.Find(p.TestimonialId);


            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images/"), fileName);

                file.SaveAs(path);

                value.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            value.NameSurname = p.NameSurname;
            value.Description = p.Description;
            value.Title = p.Title;


            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }


    }
}
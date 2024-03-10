using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class OpenDayHoursController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult OpenDayHourList()
        {
            var values = context.OpenDayHours.ToList();
            ViewBag.num1 = context.OpenDayHours.Count();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateOpenDayHour()
        {
            List<string> existingDays = context.OpenDayHours.Select(x => x.DayName).ToList();

            List<SelectListItem> allDays = new List<SelectListItem>()
            {
                new SelectListItem {Text="Pazartesi",Value="Pazartesi"},
                new SelectListItem {Text="Salı",Value="Salı"},
                new SelectListItem {Text="Çarşamba",Value="Çarşamba"},
                new SelectListItem {Text="Perşembe",Value="Perşembe"},
                new SelectListItem {Text="Cuma",Value="Cuma"},
                new SelectListItem {Text="Cumartesi",Value="Cumartesi"},
                new SelectListItem {Text="Pazar",Value="Pazar"}
            };

            foreach (var item in existingDays)
            {
                var itemRemove = allDays.FirstOrDefault(x => x.Text == item);
                if (itemRemove != null) //Sırasız ekleme olursa
                {
                    allDays.Remove(itemRemove);
                }
            }

            ViewBag.AllDays = allDays;

            ViewBag.num2 = context.OpenDayHours.Count();
            return View();
        }


        [HttpPost]
        public ActionResult CreateOpenDayHour(OpenDayHour p)
        {
            context.OpenDayHours.Add(p);
            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }

        public ActionResult DeleteOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            context.OpenDayHours.Remove(value);
            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }

        [HttpGet]
        public ActionResult UpdateOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            List<string> existingDays = context.OpenDayHours.Select(x => x.DayName).ToList();

            List<SelectListItem> allDays = new List<SelectListItem>()
    {
        new SelectListItem {Text="Pazartesi",Value="Pazartesi"},
        new SelectListItem {Text="Salı",Value="Salı"},
        new SelectListItem {Text="Çarşamba",Value="Çarşamba"},
        new SelectListItem {Text="Perşembe",Value="Perşembe"},
        new SelectListItem {Text="Cuma",Value="Cuma"},
        new SelectListItem {Text="Cumartesi",Value="Cumartesi"},
        new SelectListItem {Text="Pazar",Value="Pazar"}
    };

            foreach (var item in existingDays)
            {
                var itemToRemove = allDays.FirstOrDefault(x => x.Text == item && value.DayName != item);
                if (itemToRemove != null) //Sırasız ekleme olursa
                {
                    allDays.Remove(itemToRemove);
                }
            }

            ViewBag.AllDays = allDays;
            
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateOpenDayHour(OpenDayHour p)
        {
            var value = context.OpenDayHours.Find(p.OpenDayHourId);

            value.DayName = p.DayName;
            value.OpenHourRange = p.OpenHourRange;

            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }


    }
}
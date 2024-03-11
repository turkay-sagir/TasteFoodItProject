using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ContactController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            ViewBag.PageTitle = "İletişim";

            ViewBag.Address = context.Addresses.Select(x=>x.Location).FirstOrDefault();
            ViewBag.Phone = context.Addresses.Select(x=>x.Phone).FirstOrDefault();
            ViewBag.Email = context.Addresses.Select(x=>x.Email).FirstOrDefault();
            ViewBag.Website = context.Addresses.Select(x=>x.Website).FirstOrDefault();

            return View();
        }

        public ActionResult MessageList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        public ActionResult MessageDetail(int id)
        {
            var value = context.Contacts.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return View(value);
        }

        [HttpPost]
        public JsonResult SendMessage(Contact p)
        {
            System.Threading.Thread.Sleep(500);
            p.SendDate = DateTime.Now;
            p.IsRead = false;
            context.Contacts.Add(p);
            context.SaveChanges();

            return Json(p, JsonRequestBehavior.AllowGet);
        }

    }
}
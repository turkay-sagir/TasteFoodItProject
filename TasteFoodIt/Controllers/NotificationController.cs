using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class NotificationController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult NotificationList()
        {
            var values = context.Notifications.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNotification(Notification p)
        {
            p.Date = DateTime.Now;
            p.IsRead = false;
            context.Notifications.Add(p);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }

        public ActionResult DeleteNotification(int id)
        {
            var value = context.Notifications.Find(id);
            context.Notifications.Remove(value);
            context.SaveChanges();

            return RedirectToAction("NotificationList");
        }

        public ActionResult StatusChangeNotification(int id)
        {
            var value = context.Notifications.Find(id);
            if (value.IsRead == true)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}
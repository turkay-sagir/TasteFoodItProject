using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

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
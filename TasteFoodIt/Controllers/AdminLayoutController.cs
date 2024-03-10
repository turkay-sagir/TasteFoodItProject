using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class AdminLayoutController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            ViewBag.notificationIsReadByFalseCount = context.Notifications.Where(x => x.IsRead == false).Count();
            var values = context.Notifications.Where(x => x.IsRead == false).ToList();
            return PartialView(values);
        }


        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var value = context.Notifications.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }

    }
}
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

        public PartialViewResult PartialNavbarNotification()
        {
            ViewBag.notificationIsReadByFalseCount = context.Notifications.Where(x => x.IsRead == false).Count();
            var values = context.Notifications.Where(x => x.IsRead == false).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialNavbarMessage()
        {
            ViewBag.messageIsReadByFalseCount = context.Contacts.Where(x => x.IsRead == false).Count();
            var values = context.Contacts.Where(x => x.IsRead == false).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialNavbarUser()
        {

            if (Session["Username"]!=null)
            {
                ViewBag.NameSurname = Session["NameSurname"];
                ViewBag.ProfilePhoto = Session["ProfilePhoto"];

            }
            else
            {
                ViewBag.NameSurname = "Misafir";
                ViewBag.ProfilePhoto = "/Templates/ruang-admin/img/boy.png";
            }

            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
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

            return RedirectToAction("NotificationList", "Notification");
        }

    }
}
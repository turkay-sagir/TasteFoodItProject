using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ReservationController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult Index()
        {
            ViewBag.PageTitle = "Rezervasyon";
            return View();
        }

        public ActionResult ReservationStatusChange(int id)
        {
            var value = context.Reservations.Find(id);

            if(value.ReservationStatus=="Boş")
            {
                value.ReservationStatus = "Dolu";
            }

            else
            {
                value.ReservationStatus = "Boş";
            }

            context.SaveChanges();

            return RedirectToAction("ReservationList");
        }

        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }


        [HttpPost]
        public JsonResult CreateReservation(Reservation p)
        {
            p.ReservationStatus = "Dolu";
            context.Reservations.Add(p);
            context.SaveChanges();

            return Json(p, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteReservation(int id)
        {
            var value = context.Reservations.Find(id);
            context.Reservations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var value = context.Reservations.Find(id);

            List<SelectListItem> list1 = new List<SelectListItem>()
            {
                new SelectListItem{Text="Dolu", Value = "Dolu"},
                new SelectListItem{Text="Boş",Value="Boş" }
            };

            List<SelectListItem> list2 = new List<SelectListItem>()
            {
                new SelectListItem{Text="00:00", Value = "00:00"},
                new SelectListItem{Text="00:30",Value="00:30" },
                new SelectListItem{Text="1:00", Value = "1:00"},
                new SelectListItem{Text="1:30",Value="1:30" },
                new SelectListItem{Text="2:00", Value = "2:00"},
                new SelectListItem{Text="2:30",Value="2:30" },
                new SelectListItem{Text="3:00", Value = "3:00"},
                new SelectListItem{Text="3:30",Value="3:30" },
                new SelectListItem{Text="4:00", Value = "4:00"},
                new SelectListItem{Text="4:30",Value="4:30" },
                new SelectListItem{Text="5:00", Value = "5:00"},
                new SelectListItem{Text="5:30",Value="5:30" },
                new SelectListItem{Text="6:00", Value = "6:00"},
                new SelectListItem{Text="6:30",Value="6:30" },
                new SelectListItem{Text="7:00", Value = "7:00"},
                new SelectListItem{Text="7:30",Value="7:30" },
                new SelectListItem{Text="8:00", Value = "8:00"},
                new SelectListItem{Text="8:30",Value="8:30" },
                new SelectListItem{Text="9:00", Value = "9:00"},
                new SelectListItem{Text="9:30",Value="9:30" },
                new SelectListItem{Text="10:00", Value = "10:00"},
                new SelectListItem{Text="10:30",Value="10:30" },
                new SelectListItem{Text="11:00", Value = "11:00"},
                new SelectListItem{Text="11:30",Value="11:30" },
                new SelectListItem{Text="12:00", Value = "12:00"},
                new SelectListItem{Text="12:30",Value="12:30" },
                new SelectListItem{Text="13:00", Value = "13:00"},
                new SelectListItem{Text="13:30",Value="13:30" },
                new SelectListItem{Text="14:00", Value = "14:00"},
                new SelectListItem{Text="14:30",Value="14:30" },
                new SelectListItem{Text="15:00", Value = "15:00"},
                new SelectListItem{Text="15:30",Value="15:30" },
                new SelectListItem{Text="16:00", Value = "16:00"},
                new SelectListItem{Text="16:30",Value="16:30" },
                new SelectListItem{Text="17:00", Value = "17:00"},
                new SelectListItem{Text="17:30",Value="17:30" },
                new SelectListItem{Text="18:00", Value = "18:00"},
                new SelectListItem{Text="18:30",Value="18:30" },
                new SelectListItem{Text="19:00", Value = "19:00"},
                new SelectListItem{Text="19:30",Value="19:30" },
                new SelectListItem{Text="20:00", Value = "20:00"},
                new SelectListItem{Text="20:30",Value="20:30" },
                new SelectListItem{Text="21:00", Value = "21:00"},
                new SelectListItem{Text="21:30",Value="21:30" },
                new SelectListItem{Text="22:00", Value = "22:00"},
                new SelectListItem{Text="22:30",Value="22:30" },
                new SelectListItem{Text="23:00", Value = "23:00"},
                new SelectListItem{Text="23:30",Value="23:30" },

            };

            List<SelectListItem> list3 = new List<SelectListItem>()
            {
                new SelectListItem{Text="1", Value = "1"},
                new SelectListItem{Text="2", Value = "2"},
                new SelectListItem{Text="3", Value = "3"},
                new SelectListItem{Text="4", Value = "4"},
                new SelectListItem{Text="5", Value = "5"},
            };

            ViewBag.List1 = list1;
            ViewBag.List2 = list2;
            ViewBag.List3 = list3;
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateReservation(Reservation p)
        {
            var value = context.Reservations.Find(p.ReservationId);

            if(p.ReservationDate>DateTime.MinValue) //Tarih boş bırakılırsa
            {
                value.ReservationDate = p.ReservationDate;
            }
            
            value.Name = p.Name;
            value.Email = p.Email;
            value.Phone = p.Phone;
            value.Time = p.Time;
            value.GuestCount = p.GuestCount;

            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }


    }
}

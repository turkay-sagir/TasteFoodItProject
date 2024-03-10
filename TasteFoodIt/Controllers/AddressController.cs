using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AddressController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AddressList()
        {
            ViewBag.AddressId = context.Addresses.Select(k=>k.AddressId).FirstOrDefault();
            ViewBag.Phone = context.Addresses.Select(x=>x.Phone).FirstOrDefault();
            ViewBag.Email = context.Addresses.Select(y=> y.Email).FirstOrDefault();
            ViewBag.Description = context.Addresses.Select(z=>z.Description).FirstOrDefault();

            ViewBag.num1 = context.Addresses.Count();

            return View();
        }

        [HttpGet]
        public ActionResult CreateAddress()
        {
            ViewBag.num2 = context.Addresses.Count();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(Address p)
        {
            context.Addresses.Add(p);
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }

        public ActionResult DeleteAddress(int id)
        {
            var value = context.Addresses.Find(id);
            context.Addresses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var value = context.Addresses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAddress(Address p) 
        {
            var value = context.Addresses.Find(p.AddressId);
            value.Phone = p.Phone;
            value.Email = p.Email;
            value.Description = p.Description;

            context.SaveChanges();
            return RedirectToAction("AddressList");
        }


    }
}
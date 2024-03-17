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
    public class SocialMediaController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }

        public ActionResult StatusChangeSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);

            if(value.Status==false)
            {
                value.Status = true;
            }
            else
            {
                value.Status=false;
            }

            context.SaveChanges();
            return RedirectToAction("SocialMediaList");

        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia p)
        {
            p.Status = true;
            context.SocialMedias.Add(p);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia p)
        {
            var value = context.SocialMedias.Find(p.SocialMediaId);

            value.Status = true;
            value.PlatformName = p.PlatformName;
            value.IconUrl = p.IconUrl;
            value.RedirectUrl = p.RedirectUrl;

            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }


    }
}
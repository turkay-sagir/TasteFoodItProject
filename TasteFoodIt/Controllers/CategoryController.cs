using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class CategoryController : Controller
    {
        TasteContext context = new TasteContext();
        
        public ActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            List<SelectListItem> icons = new List<SelectListItem>
            {
                new SelectListItem {Text="Ekmek", Value="flat flaticon-bread"},
                new SelectListItem {Text="Kahvaltı", Value="flat flaticon-breakfast"},
                new SelectListItem {Text="Burger", Value="flat flaticon-burger"},
                new SelectListItem {Text="Tavuk", Value="flat flaticon-chicken-leg"},
                new SelectListItem {Text="Cupcake", Value="flat flaticon-cupcake"},
                new SelectListItem {Text="Dondurma", Value="flat flaticon-ice-cream"},
                new SelectListItem {Text="Omlet", Value="flat flaticon-omelette"},
                new SelectListItem {Text="Pizza", Value="flat flaticon-pizza"},
                new SelectListItem {Text="İçecek 1", Value="flat flaticon-wine"},
                new SelectListItem {Text="İçecek 2", Value="flat flaticon-wine-1"}
            };

            ViewBag.icons = icons;

            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category p)
        {
            context.Categories.Add(p);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);

            List<SelectListItem> icons = new List<SelectListItem>
            {
                new SelectListItem {Text="Ekmek", Value="flat flaticon-bread"},
                new SelectListItem {Text="Kahvaltı", Value="flat flaticon-breakfast"},
                new SelectListItem {Text="Burger", Value="flat flaticon-burger"},
                new SelectListItem {Text="Tavuk", Value="flat flaticon-chicken-leg"},
                new SelectListItem {Text="Cupcake", Value="flat flaticon-cupcake"},
                new SelectListItem {Text="Dondurma", Value="flat flaticon-ice-cream"},
                new SelectListItem {Text="Omlet", Value="flat flaticon-omelette"},
                new SelectListItem {Text="Pizza", Value="flat flaticon-pizza"},
                new SelectListItem {Text="İçecek 1", Value="flat flaticon-wine"},
                new SelectListItem {Text="İçecek 2", Value="flat flaticon-wine-1"}
            };

            ViewBag.icons = icons;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            var value = context.Categories.Find(p.CategoryId);
            value.CategoryName = p.CategoryName;
            value.IconUrl = p.IconUrl;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }


    }
}
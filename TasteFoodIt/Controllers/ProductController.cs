using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ProductController : Controller
    {
        TasteContext context = new TasteContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.PageTitle = "Menü";
            return View();
        }

        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        public ActionResult ProductStatusChange(int id)
        {
            var value = context.Products.Find(id);

            if(value.IsActive==true)
            {
                value.IsActive = false;
            }

            else
            {
                value.IsActive=true;
            }

            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }
                                           ).ToList();

            ViewBag.values = values;
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product p, HttpPostedFileBase file)
        {
            if(file!=null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images/"),fileName);

                file.SaveAs(path);
                p.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }
            p.IsActive = true;
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("ProductList");

        }

        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        { 
            var value = context.Products.Find(id);

            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }
                                           ).ToList();

            

            ViewBag.values = values;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product p, HttpPostedFileBase file)
        {
            var value = context.Products.Find(p.ProductId);

            if(file != null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images/"), fileName);

                file.SaveAs(path);

                value.ImageUrl = Path.Combine("/Templates/tasteit-master/images/", fileName);
            }

            value.ProductName = p.ProductName;
            value.Description = p.Description;
            value.Price = p.Price;
            value.CategoryId = p.CategoryId;
            value.IsActive = true;
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }


    }
    


}
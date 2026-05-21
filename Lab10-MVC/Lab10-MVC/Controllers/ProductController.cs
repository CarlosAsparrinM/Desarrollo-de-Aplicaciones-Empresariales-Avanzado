using Lab10_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab10_MVC.Controllers
{
    public class ProductController : Controller
    {
        List<ProductModel> products = new List<ProductModel>();
        public ActionResult Index()
        { 
            products.Add(new ProductModel { id = 1, name = "Laptop", price = 1000 });
            products.Add(new ProductModel { id = 2, name = "Smartphone", price = 500 });
            products.Add(new ProductModel { id = 3, name = "Tablet", price = 300 });

            Session["Products"] = products;

            return View(products);
        }

        public ActionResult Index2()
        {
            return View(Session["products"]);
        }
    }
}
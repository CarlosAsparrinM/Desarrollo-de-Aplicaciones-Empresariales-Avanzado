using Lab10_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lab10_MVC.Controllers
{
    public class ProductFinalController : Controller
    {
        // GET: ProductFinal
        public ActionResult Index()
        {
            if (Session["products"] == null)
            {
                List<ProductModel> products = new List<ProductModel>()
                {
                    new ProductModel { id = 1, name = "Laptop", price = 49 },
                    new ProductModel { id = 2, name = "Smartphone", price = 80 },
                    new ProductModel { id = 3, name = "Tablet", price = 120 }
                };

                Session["products"] = products;
            }

            return View((List<ProductModel>)Session["products"]);
        }

        // GET: ProductFinal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductFinal/Create
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            List<ProductModel> products =
                (List<ProductModel>)Session["products"];

            model.id = products.Any()
                ? products.Max(x => x.id) + 1
                : 1;

            products.Add(model);

            Session["products"] = products;

            return RedirectToAction("Index");
        }

        // GET: ProductFinal/Details/5
        public ActionResult Details(int id)
        {
            List<ProductModel> products =
                (List<ProductModel>)Session["products"];

            ProductModel product =
                products.FirstOrDefault(x => x.id == id);

            return View(product);
        }

        // GET: ProductFinal/Edit/5
        public ActionResult Edit(int id)
        {
            List<ProductModel> products =
                (List<ProductModel>)Session["products"];

            ProductModel product =
                products.FirstOrDefault(x => x.id == id);

            return View(product);
        }

        // POST: ProductFinal/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            List<ProductModel> products =
                (List<ProductModel>)Session["products"];

            ProductModel product =
                products.FirstOrDefault(x => x.id == model.id);

            if (product != null)
            {
                product.name = model.name;
                product.price = model.price;
            }

            Session["products"] = products;

            return RedirectToAction("Index");
        }

        // GET: ProductFinal/Delete/5
        public ActionResult Delete(int id)
        {
            List<ProductModel> products =
                (List<ProductModel>)Session["products"];

            ProductModel product =
                products.FirstOrDefault(x => x.id == id);

            return View(product);
        }

        // POST: ProductFinal/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            List<ProductModel> products =
                (List<ProductModel>)Session["products"];

            ProductModel product =
                products.FirstOrDefault(x => x.id == id);

            if (product != null)
            {
                products.Remove(product);
            }

            Session["products"] = products;

            return RedirectToAction("Index");
        }
    }
}
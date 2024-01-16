using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Repository_DBFirst;
using Microsoft.Ajax.Utilities;

using PresentationLayer_MVC.Models;
using System.Linq;
using System;

namespace PresentationLayer_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ETailorEntities db = new();
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(c => c.Category);
            List<ProductViewModel> productsViewModel = new();
            products.ForEach(product => productsViewModel.Add(new ProductViewModel
            {
                Product_Id = product.product_id,
                Product_Name = product.product_name,
                Description = product.description,
                Price = product.price,
                Image_URL = product.image_url,
                Category_Id = product.category_id,
                Category_Name = product.category_name
            }));
            return View(productsViewModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Repository_DBFirst.Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            // Convert the Product entity to a ProductViewModel
            ProductViewModel productViewModel = new()
            {
                Product_Id = product.product_id,
                Product_Name = product.product_name,
                Description = product.description,
                Price = product.price,
                Image_URL = product.image_url,
                Category_Id = product.category_id,
                Category_Name = product.category_name
            };

            return View(productViewModel);
        }

        //GET: Products/Create
        public ActionResult Create()
        {
            SelectList categories = new(db.Categories, "Category_Id");
            ProductViewModel productViewModel = new(categories);
            return View(productViewModel);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_Id, Product_Name, Description, Price, Image_URL, Category_Id, Category_Name")] Repository_DBFirst.Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.Category_Id = new SelectList(db.Categories, "Category_Id", product.category_id.ToString());
             return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Repository_DBFirst.Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            // Map the entity to a ViewModel
            ProductViewModel productViewModel = new()
            {
                Product_Id = product.product_id,
                Product_Name = product.product_name,
                Description = product.description,
                Price = product.price,
                Image_URL = product.image_url,
                Category_Id = product.category_id,
                Category_Name = product.category_name
            };
            // You may not need to set ViewBag.Category_Id here
            // ViewBag.Category_Id = new SelectList(db.Categories, "Category_Id", product.category_id.ToString());

            return View(productViewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_Id, Product_Name, Description, Price, Image_URL, Category_Id, Category_Name")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = db.Products.Find(productViewModel.Product_Id);
                if (product == null)
                {
                    return HttpNotFound();
                }

                // Update the existing product
                product.product_name = productViewModel.Product_Name;
                product.description = productViewModel.Description;
                product.price = productViewModel.Price;
                product.image_url = productViewModel.Image_URL;
                product.category_id = productViewModel.Category_Id;
                product.category_name = productViewModel.Category_Name;

                // You may not need to set ViewBag.Category_Id here
                // ViewBag.Category_Id = new SelectList(db.Categories, "Category_Id", productViewModel.Category_Id.ToString());

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, there might not be a need to set ViewBag.Category_Id here
            // ViewBag.Category_Id = new SelectList(db.Categories, "Category_Id", productViewModel.Category_Id.ToString());

            return View(productViewModel);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository_DBFirst.Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            // Map the entity to a ViewModel
            ProductViewModel productViewModel = new()
            {
                Product_Id = product.product_id,
                Product_Name = product.product_name,
                Description = product.description,
                Price = product.price,
                Image_URL = product.image_url,
                Category_Id = product.category_id,
                Category_Name = product.category_name
            };

            return View(productViewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the entity to be deleted
            Repository_DBFirst.Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            if (product.Orders.Any())
            {
                return View("Error", new HandleErrorInfo(new Exception("Product has associated orders"), "ProductsController", "Delete"));
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

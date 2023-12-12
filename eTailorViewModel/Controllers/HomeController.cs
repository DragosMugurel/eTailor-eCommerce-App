using NivelAccesDate_DBFirst;

using Repository_DBFirst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;
namespace eTailorViewModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsAccessor productsAccessor;
        private readonly List<Product> cart = new List<Product>();
        public HomeController()
        {
            var dbContext = new eTailorEntities();
            productsAccessor = new ProductsAccessor(dbContext);
        }

        private ActionResult HandleException(Exception ex, string actionName)
        {
            Trace.TraceError($"Error in HomeController/{actionName}: {ex}");
            return View("Error");
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var products = productsAccessor.GetProductsList();
                return View(products);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(Index));
            }
        }

        [HttpPost]
        public ActionResult Index(LibrarieModele.Product model)
        {
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Create(LibrarieModele.Product model)
        {
            if (ModelState.IsValid)
            {
                productsAccessor.AddProduct(model);
                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View("Create", model);
        }
        public ActionResult Cart()
        {
            // Retrieve cart items from session
            var cartItems = Session["Cart"] as List<Product> ?? new List<Product>();

            var cartViewModel = cartItems.Select(item => new LibrarieModele.Product
            {
                Product_Id = item.product_id,
                Product_Name = item.product_name,
                Description = item.description,
                Price = item.price,
                Image_URL = item.image_url
            }).ToList();
            return View(cartViewModel);
        }



        [HttpPost]
        public ActionResult AddToCart(LibrarieModele.Product model)
        {
            var item = new Product { product_id = model.Product_Id, product_name = model.Product_Name, price = model.Price };
            // Use Session to store cart items
            var cart = Session["Cart"] as List<Product> ?? new List<Product>();
            cart.Add(item);
            Session["Cart"] = cart;
            TempData["SuccessMessage"] = "Product added to cart successfully!";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cartItems = Session["Cart"] as List<Product> ?? new List<Product>();
            var itemToRemove = cartItems.FirstOrDefault(item => item.product_id == id);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                Session["Cart"] = cartItems;
                TempData["SuccessMessage"] = "Product removed from cart successfully!";
            }

            return RedirectToAction(nameof(Cart));
        }


        public ActionResult Edit(int id)
        {
            var productById = productsAccessor.GetProductById(id);
            return View("Edit", productById);
        }

        // POST: Home/Edit/1
        [HttpPost]
        public ActionResult Edit(LibrarieModele.Product editedProduct)
        {
            if (editedProduct == null)
            {
                return HttpNotFound(); // or another appropriate action
            }

            var existingProduct = productsAccessor.GetProductById(editedProduct.Product_Id);

            if (existingProduct == null)
            {
                return HttpNotFound(); // or another appropriate action
            }

            UpdateProductProperties(existingProduct, editedProduct);
            productsAccessor.UpdateProduct(existingProduct);

            return RedirectToAction(nameof(Index));
        }

        // GET: Home/Delete/1
        public ActionResult Delete(int id)
        {
            var existingProduct = productsAccessor.GetProductById(id);
            return View(existingProduct);
        }


        // POST: Home/DeleteConfirmed/1
        [HttpPost]
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var existingProduct = productsAccessor.GetProductById(id);

                if (existingProduct == null)
                {
                    return HttpNotFound(); // or another appropriate action
                }

                productsAccessor.DeleteProduct(existingProduct);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(DeleteConfirmed));
            }
        }


        public ActionResult Details(int id)
        {
            var product = productsAccessor.GetProductById(id);
            return View(product);
        }

        public ActionResult About()
        {
            return View();
        }


        private void UpdateProductProperties(LibrarieModele.Product existingProduct, LibrarieModele.Product editedProduct)
        {
            existingProduct.Product_Name = editedProduct.Product_Name;
            existingProduct.Description = editedProduct.Description;
            existingProduct.Price = editedProduct.Price;
            existingProduct.Image_URL = editedProduct.Image_URL;
        }
    }

}

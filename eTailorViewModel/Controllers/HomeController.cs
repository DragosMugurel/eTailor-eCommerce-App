using NivelAccesDate_DBFirst;

using Repository_DBFirst;

using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace eTailorViewModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsAccessor productsAccessor;

        public HomeController()
        {
            var dbContext = new eTailorEntities();
            this.productsAccessor = new ProductsAccessor(dbContext);
        }



        private ActionResult HandleException(Exception ex, string actionName)
        {
            // Log the exception using System.Diagnostics.Trace
            Trace.TraceError($"Error in HomeController/{actionName}: {ex}");

            // Return a custom error view
            return View("Error");
        }

        // GET: Products
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

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(LibrarieModele.Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                productsAccessor.AddProduct(model);
                productsAccessor.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception details and add the exception message to the ModelState
                LogAndAddModelError(ex, "Error in HomeController/Create");
                return View(model);
            }
        }

        // GET: Home/Edit/1
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var productById = productsAccessor.GetProductById(id);

                if (productById == null)
                {
                    return HttpNotFound();
                }

                return View("Edit", productById);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(Edit));
            }
        }

        // POST: Home/Edit/1
        [HttpPost]
        public ActionResult Edit(LibrarieModele.Product editedProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(editedProduct);
            }

            try
            {
                var existingProduct = productsAccessor.GetProductById(editedProduct.Product_Id);

                if (existingProduct == null)
                {
                    return HttpNotFound();
                }

                UpdateProductProperties(existingProduct, editedProduct);
                productsAccessor.UpdateProduct(existingProduct);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(Edit));
            }
        }

        // GET: Home/Delete/1
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var existingProduct = productsAccessor.GetProductById(id);

                if (existingProduct == null)
                {
                    return HttpNotFound();
                }

                return View(existingProduct);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(Delete));
            }
        }

        // POST: Home/DeleteConfirmed/1
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var existingProduct = productsAccessor.GetProductById(id);

                if (existingProduct == null)
                {
                    return HttpNotFound();
                }

                // Delete the product
                productsAccessor.DeleteProduct(existingProduct);
                productsAccessor.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(DeleteConfirmed));
            }
        }


        // GET: Home/Details/1
        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var product = productsAccessor.GetProductById(id);

                if (product == null)
                {
                    return HttpNotFound();
                }

                return View(product);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(Details));
            }
        }

        private void LogAndAddModelError(Exception ex, string logMessage)
        {
            Trace.TraceError($"{logMessage}: {ex}");
            ModelState.AddModelError(string.Empty, ex.Message);
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

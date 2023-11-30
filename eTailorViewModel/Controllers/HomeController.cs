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
            productsAccessor = new ProductsAccessor(dbContext);
        }

        private ActionResult HandleException(Exception ex, string actionName)
        {
            Trace.TraceError($"Error in HomeController/{actionName}: {ex}");
            return View("Error");
        }

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
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return RedirectToAction("Index");
        }


        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(LibrarieModele.Product model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            productsAccessor.AddProduct(model);
            return View("Create", model);
            
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
                var existingProduct = productsAccessor.GetProductById(editedProduct.Product_Id);
                UpdateProductProperties(existingProduct, editedProduct);
                productsAccessor.UpdateProduct(existingProduct);
                return RedirectToAction("Index");

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
                productsAccessor.DeleteProduct(existingProduct);

                return RedirectToAction("Index");
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

        private void UpdateProductProperties(LibrarieModele.Product existingProduct, LibrarieModele.Product editedProduct)
        {
            existingProduct.Product_Name = editedProduct.Product_Name;
            existingProduct.Description = editedProduct.Description;
            existingProduct.Price = editedProduct.Price;
            existingProduct.Image_URL = editedProduct.Image_URL;
        }
    }

}

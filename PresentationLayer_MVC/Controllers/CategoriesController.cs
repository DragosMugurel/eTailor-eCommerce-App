using BusinessLayer.Interfaces;
using DomainModels;

using PresentationLayer_MVC.Models;

using NLog;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using DataAccessLayer_ORM_CF;


namespace PresentationLayer_MVC.Controllers
{
    public class CategoriesController(ICategories categoriesService) : Controller
    {
        private readonly ICategories categoriesService = categoriesService;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            List<CategoryViewModel> categoriesViewModel = new();
            List<Category> categories = categoriesService.GetCategories();
            if (categories is null)
            {
                logger.Error("Categories cannot be retrieved.");
                return View(categoriesViewModel);
            }
            foreach (Category category in categories)
            {
                CategoryViewModel categoryViewModel = new()
                {
                    Category_Id = category.Category_Id
                };
                categoriesViewModel.Add(categoryViewModel);
            }
            return View(categoriesViewModel);
        }


        //GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoriesService.GetCategory(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }

            CategoryViewModel categoryViewModel = new()
            {
                Category_Id = category.Category_Id
            };

            return View(categoryViewModel);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            CategoryViewModel model = new();

            return View(model);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new()
                {
                    Category_Id = categoryViewModel.Category_Id
                };

                categoriesService.AddCategory(category);

                return RedirectToAction("Index");
            }

            return View(categoryViewModel);
        }
        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoriesService.GetCategory(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }

            CategoryViewModel categoryViewModel = new()
            {
                Category_Id = category.Category_Id
            };

            return View(categoryViewModel);
        }
        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_Id")] CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new()
                {
                    Category_Id = categoryViewModel.Category_Id
                };

                categoriesService.UpdateCategory(category);

                return RedirectToAction("Index");
            }
            return View(categoryViewModel);
        }
        // GET: CategoriesGenerated/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoriesService.GetCategory(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            CategoryViewModel categoryViewModel = new()
            {
                Category_Id = category.Category_Id
            };

            return View(categoryViewModel);
        }
        // POST: CategoriesGenerated/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoriesService.DeleteCategory(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
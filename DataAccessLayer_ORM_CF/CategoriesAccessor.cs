using DataAccessLayer_ORM_CF.Interfaces;

using DomainModels;

using NLog;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;


namespace DataAccessLayer_ORM_CF
{
    public class CategoriesAccessor(IProductDbContext db) : ICategoriesAccessor
    {
        private ETailorDbContext db = (ETailorDbContext)db;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public List<Category> GetCategories()
        {
            List<Category> categories;
            try
            {
                categories = [.. db.Categories.AsNoTracking()];
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Error on getting categories from db");
                return null;
            }
            return categories;
        }

        public Category GetCategory(int id)
        {
            Category category = db.Categories.AsNoTracking().FirstOrDefault(localCategory => localCategory.Category_Id == id);
            return category;
        }
        public bool AddCategory(Category category)
        {
            db.Categories.Add(category);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Category_Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
        public bool DeleteCategory(int categoryId)
        {
            Category category = db.Categories.Find(categoryId);
            db.Categories.Remove(category);
            db.SaveChanges();
            return true;
        }
        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Category_Id == id) > 0;
        }
        //method injection
        public void SetDependency(IProductDbContext db)
        {
            this.db = (ETailorDbContext)db;
        }
        //property injection
        public IProductDbContext DbContextProperty
        {
            set
            {
                db = (ETailorDbContext)value;
            }
            get
            {
                if(db==null)
                {
                    throw new Exception("DbContext is not initialized.");
                }
                else
                {
                    return db;
                }
            }
        }

    }
}

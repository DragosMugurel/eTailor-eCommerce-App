using BusinessLayer.CoreServices.Interfaces;
using BusinessLayer.Interfaces;

using DataAccessLayer_ORM_CF.Interfaces;

using DomainModels;

using NLog;

using System.Collections.Generic;

namespace BusinessLayer
{
    public class CategoriesService : ICategories
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ICache cacheManager;
        private readonly ICategoriesAccessor categoriesAccessor;
        public CategoriesService(ICategoriesAccessor categoriesAccessor, ICache cacheManager)
        {
            this.categoriesAccessor = categoriesAccessor;
            this.cacheManager = cacheManager;
        }
       public CategoriesService() { }
        public bool AddCategory(Category category)
        {
            bool result = categoriesAccessor.AddCategory(category);
            if (result)
            {
                cacheManager.Remove("companies_list_all");
            }

            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            bool result = categoriesAccessor.DeleteCategory(categoryId);

            if (result)
            {
                string individual_key = "categories_" + categoryId;
                string list_key = "categories_list";
                cacheManager.Remove(individual_key);
                cacheManager.RemoveByPattern(list_key);
            }

            return true;
        }

        public List<Category> GetCategories()
        {
            string key = "categories_list_all";
            List<Category> categories;
            logger.Debug("Get all categories from productsAccessor");

            if (cacheManager.IsSet(key))
            {
                categories = cacheManager.Get<List<Category>>(key);
            }
            else
            {
                categories = categoriesAccessor.GetCategories();
                cacheManager.Set(key, categories);
            }

            return categories;
        }

        public Category GetCategory(int id)
        {
            Category category;
            string key = "categories_" + id;

            if (cacheManager.IsSet(key))
            {
                category = cacheManager.Get<Category>(key);
            }
            else
            {
                category = categoriesAccessor.GetCategory(id);
                cacheManager.Set(key, category);
            }

            return category;
        }
        public bool UpdateCategory(Category category)
        {
            bool result = categoriesAccessor.UpdateCategory(category);
            if (result)
            {
                string individual_key = "categories_" + category.Category_Id;
                string list_key = "categories_list";
                cacheManager.Remove(individual_key);
                cacheManager.RemoveByPattern(list_key);
            }

            return true;
        }
    }
}

using DomainModels;

using System.Collections.Generic;

namespace DataAccessLayer_ORM_CF.Interfaces
{
    public interface ICategoriesAccessor
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        
    }
}

using LibrarieModele;

using System.Collections.Generic;

namespace NivelAccessDate_DBFirst.Interfaces
{
    public interface ICategoriesAccessor
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void AddCategory(Category category);
    }
}
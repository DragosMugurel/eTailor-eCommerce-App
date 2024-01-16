using System.Collections.Generic;

using DomainModels;
namespace BusinessLayer.Interfaces
{
    public interface ICategories
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int productId);
    }
}

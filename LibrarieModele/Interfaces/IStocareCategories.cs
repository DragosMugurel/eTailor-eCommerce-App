using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareCategories : IStocareFactory
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        bool AddCategory(Category c);
        bool UpdateCategory(Category c);
    }
}

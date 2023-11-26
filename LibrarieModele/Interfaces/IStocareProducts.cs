using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareProducts : IStocareFactory
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        bool AddProduct(Product p);
        bool UpdateProduct(Product p);
    }
}

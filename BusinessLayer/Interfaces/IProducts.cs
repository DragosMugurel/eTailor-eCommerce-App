using DomainModels;

using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IProducts
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
    }
}

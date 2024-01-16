using DomainModels;

using System.Collections.Generic;

namespace DataAccessLayer_ORM_CF.Interfaces
{
    public interface IProductsAccessor
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
    }
}

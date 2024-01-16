using LibrarieModele;

using System.Collections.Generic;

namespace NivelAccessDate_DBFirst.Interfaces
{
    public interface IProductsAccessor
    {
        List<Product> GetProductsList();
        List<Product> GetProductsInCart(List<int> productIds);
        Product GetProductById(int productId);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(Product product);
        void AddProduct(Product product);
    }
}

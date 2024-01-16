using BusinessLayer.CoreServices.Interfaces;
using BusinessLayer.Interfaces;

using DataAccessLayer_ORM_CF.Interfaces;

using DomainModels;

using NLog;

using System.Collections.Generic;

namespace BusinessLayer
{
    public class ProductsService : IProducts
    {
        private readonly ICache cacheManager;
        private readonly IProductsAccessor productsAccessor;
        protected Logger logger = LogManager.GetCurrentClassLogger();
        public ProductsService(IProductsAccessor productsAccessor, ICache cacheManager)
        {
            this.productsAccessor = productsAccessor;
            this.cacheManager = cacheManager;
        }
        public List<Product> GetProducts()
        {
            string key = "products_list_all";
            List<Product> products;

            logger.Debug("Get all products from productsAccessor");

            if (cacheManager.IsSet(key))
            {
                products = cacheManager.Get<List<Product>>(key);
            }
            else
            {
                products = productsAccessor.GetProducts();
                cacheManager.Set(key, products);
            }

            return products;
        }

        public Product GetProduct(int id)
        {
            Product product;
            string key = "products_" + id;

            if (cacheManager.IsSet(key))
            {
                product = cacheManager.Get<Product>(key);
            }
            else
            {
                product = productsAccessor.GetProduct(id);
                cacheManager.Set(key, product);
            }

            return product;
        }
        public bool AddProduct(Product product)
        {
            bool result = productsAccessor.AddProduct(product);
            if (result)
            {
                cacheManager.Remove("products_list_all");
            }

            return true;
        }

        public bool UpdateProduct(Product product)
        {
            bool result = productsAccessor.UpdateProduct(product);
            if (result)
            {
                string individual_key = "products_" + product.Product_Id;
                string list_key = "products_list";
                cacheManager.Remove(individual_key);
                cacheManager.RemoveByPattern(list_key);
            }

            return true;
        }

        public bool DeleteProduct(int productId)
        {
            bool result = productsAccessor.DeleteProduct(productId);

            if (result)
            {
                string individual_key = "products_" + productId;
                string list_key = "products_list";
                cacheManager.Remove(individual_key);
                cacheManager.RemoveByPattern(list_key);
            }

            return true;
        }
    }
}

using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class ProductsAccessor
    {
        private readonly eTailorEntities dbContext;

        public ProductsAccessor(eTailorEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<LibrarieModele.Product> GetProductsList()
        {
                var products = dbContext.Products
                    .Select(MapToLibrarieModel)
                    .ToList();

                DisplayCollection(products);
                return products;

        }
        public void AddProduct(LibrarieModele.Product newProduct)
        {
                    var repositoryProduct = MapToRepositoryModel(newProduct);

                    // Attach the entity if it's in a detached state
                    if (dbContext.Entry(repositoryProduct).State == EntityState.Detached)
                    {
                        dbContext.Products.Attach(repositoryProduct);
                    }

                    dbContext.Products.Add(repositoryProduct);
                    dbContext.SaveChanges();
        }



        public LibrarieModele.Product GetProductById(int product_id)
        {
                var product = dbContext.Products
                    .Where(p => p.product_id == product_id)
                    .Select(MapToLibrarieModel)
                    .FirstOrDefault();
                return product;
        }

        public void UpdateProduct(LibrarieModele.Product updatedProduct)
        {

                var existingProduct = dbContext.Products.Find(updatedProduct.Product_Id) ?? throw new Exception("The product does not exist.");
                UpdateRepositoryModel(existingProduct, updatedProduct);
                dbContext.SaveChanges();
            
        }

        public void DeleteProduct(LibrarieModele.Product product)
        {
                var existingProduct = dbContext.Products.Find(product.Product_Id);

                if (existingProduct != null)
                {
                    // Check if the entity is attached
                    if (dbContext.Entry(existingProduct).State == EntityState.Detached)
                    {
                        // Attach the entity to the context
                        dbContext.Products.Attach(existingProduct);
                    }

                    // Remove the entity
                    dbContext.Products.Remove(existingProduct);
                    dbContext.SaveChanges();
                }
        }

        private void DisplayCollection<T>(List<T> collection)
        {
            collection.ForEach(item => Console.WriteLine(item.ToString()));
        }

        private LibrarieModele.Product MapToLibrarieModel(Product p)
        {
            return new LibrarieModele.Product
            {
                Product_Id = p.product_id,
                Product_Name = p.product_name,
                Description = p.description,
                Price = p.price,
                Image_URL = p.image_url,
                Category_Id = p.category_id,
                Category_Name = p.category_name,
                Popularity = p.popularity
            };
        }

        private Product MapToRepositoryModel(LibrarieModele.Product p)
        {
            return new Product
            {
                product_id = p.Product_Id,
                product_name = p.Product_Name,
                description = p.Description,
                price = p.Price,
                image_url = p.Image_URL,
                category_id = p.Category_Id,
                category_name = p.Category_Name,
                popularity = p.Popularity
            };
        }

        private void UpdateRepositoryModel(Product existingProduct, LibrarieModele.Product updatedProduct)
        {
            existingProduct.product_id = updatedProduct.Product_Id;
            existingProduct.product_name = updatedProduct.Product_Name;
            existingProduct.description = updatedProduct.Description;
            existingProduct.price = updatedProduct.Price;
            existingProduct.image_url = updatedProduct.Image_URL;
            existingProduct.category_id = updatedProduct.Category_Id;
            existingProduct.category_name = updatedProduct.Category_Name;
            existingProduct.popularity = updatedProduct.Popularity;
        }
    }
}

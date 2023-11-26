using Repository_DBFirst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;

namespace NivelAccesDate_DBFirst
{
    public class ProductsAccessor
    {
        private readonly eTailorEntities dbContext;

        public ProductsAccessor(eTailorEntities dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<LibrarieModele.Product> GetProductsList()
        {
            try
            {
                var products = dbContext.Products
                    .Select(MapToLibrarieModel)
                    .ToList();

                DisplayCollection(products);
                return products;
            }
            catch (Exception ex)
            {
                LogError(ex, "GetProductsList");
                throw;
            }
        }

        public void AddProduct(LibrarieModele.Product newProduct)
        {
            try
            {
                var repositoryProduct = MapToRepositoryModel(newProduct);
                dbContext.Products.Add(repositoryProduct);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex, "AddProduct");
                throw;
            }
        }

        public LibrarieModele.Product GetProductById(int productId)
        {
            try
            {
                var product = dbContext.Products
                    .Where(p => p.product_id == productId)
                    .Select(MapToLibrarieModel)
                    .FirstOrDefault();

                return product;
            }
            catch (Exception ex)
            {
                LogError(ex, "GetProductById");
                throw;
            }
        }

        public void UpdateProduct(LibrarieModele.Product updatedProduct)
        {
            try
            {
                var existingProduct = dbContext.Products.Find(updatedProduct.Product_Id) ?? throw new Exception("The product does not exist.");

                // Update the existing product with the new values
                UpdateRepositoryModel(existingProduct, updatedProduct);

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex, "UpdateProduct");
                throw;
            }
        }

        public void DeleteProduct(LibrarieModele.Product product)
        {
            try
            {
                var repositoryProduct = MapToRepositoryModel(product);

                // Attach the entity to the context
                dbContext.Products.Attach(repositoryProduct);

                // Set the entity state to Deleted
                dbContext.Entry(repositoryProduct).State = EntityState.Deleted;

                // Save changes to apply the deletion
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex, "DeleteProduct");
                throw;
            }
        }


        public void SaveChanges()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex, "SaveChanges");
                throw;
            }
        }

        private void LogError(Exception ex, string methodName)
        {
            Trace.TraceError($"Error in {nameof(ProductsAccessor)}.{methodName}: {ex}");
            Trace.TraceError($"Stack Trace: {ex.StackTrace}");
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

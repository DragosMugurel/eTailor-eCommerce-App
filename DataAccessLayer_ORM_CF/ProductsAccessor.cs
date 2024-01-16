using DataAccessLayer_ORM_CF.Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using DomainModels;
using System.Data.Entity.Infrastructure;
namespace DataAccessLayer_ORM_CF
{
    public class ProductsAccessor : IProductsAccessor
    {
        private ETailorDbContext db;
        protected Logger logger = LogManager.GetCurrentClassLogger();
        public ProductsAccessor(ICategoryDbContext db)
        {
            this.db = (ETailorDbContext)db;
        }
        public ProductsAccessor(ETailorDbContext dbContext)
        {
            db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Product> GetProducts()
        {
            List<Product> products;
            try
            {
                products = [.. db.Products.AsNoTracking()];
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Error on getting products from db");
                return null;
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            Product product = db.Products.AsNoTracking().FirstOrDefault(localProduct => localProduct.Product_Id == id);
            return product;
        }
        public bool AddProduct(Product product)
        {
            db.Products.Add(product);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Product_Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
        public bool DeleteProduct(int productId)
        {
            Product product = db.Products.Find(productId);
            db.Products.Remove(product);
            db.SaveChanges();
            return true;
        }
        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Product_Id == id) > 0;
        }

        //method injection
        public void SetDependency(IProductDbContext db)
        {
            this.db = (ETailorDbContext)db;
        }

         //property injection
         public ICategoryDbContext DbContextProperty
         {
             set
             {
                 db = (ETailorDbContext)value;
             }
             get
             {
                 if(db == null)
                 {
                     throw new Exception("DbContext is not initialized");
                 }
                 else
                 {
                     return db;
                 }
             }
         }

    }
}
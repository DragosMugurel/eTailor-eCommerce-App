using System.Data.Entity;

using DomainModels;
namespace DataAccessLayer_ORM_CF
{
    public class ETailorDbContext : DbContext, IProductDbContext, ICategoryDbContext
    {
        public ETailorDbContext()
            : base("name=ETailorEntities")
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}

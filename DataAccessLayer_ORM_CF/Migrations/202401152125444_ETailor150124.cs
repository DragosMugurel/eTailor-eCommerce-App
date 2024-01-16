namespace DataAccessLayer_ORM_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ETailor150124 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_Id = c.Int(nullable: false, identity: true),
                        Product_Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image_URL = c.String(),
                        Category_Id = c.Int(nullable: false),
                        Category_Name = c.String(),
                    })
                .PrimaryKey(t => t.Product_Id);
            /* Add the following lines to drop the ProductCategories table if it exists */
            Sql("IF OBJECT_ID('dbo.ProductCategories', 'U') IS NOT NULL DROP TABLE dbo.ProductCategories");
            /* Add the following lines to drop the ProductCategories table if it exists */
            Sql("IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL DROP TABLE dbo.Categories");
            /*   CreateTable(
                   "dbo.ProductCategories",
                   c => new
                       {
                           Product_Product_Id = c.Int(nullable: false),
                           Category_Category_Id = c.Int(nullable: false),
                       })
                   .PrimaryKey(t => new { t.Product_Product_Id, t.Category_Category_Id })
                   .ForeignKey("dbo.Products", t => t.Product_Product_Id, cascadeDelete: true)
                   .ForeignKey("dbo.Categories", t => t.Category_Category_Id, cascadeDelete: true)
                   .Index(t => t.Product_Product_Id)
                   .Index(t => t.Category_Category_Id);*/

        }
        
        public override void Down()
        {
          /*  DropForeignKey("dbo.ProductCategories", "Category_Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_Product_Id", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_Category_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Product_Product_Id" });
            DropTable("dbo.ProductCategories");*/
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

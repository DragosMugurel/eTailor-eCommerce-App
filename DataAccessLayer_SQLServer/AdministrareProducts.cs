using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareProduct : IStocareProducts
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Product> GetProducts()
        {
            var result = new List<Product>();
            var dsProducts = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Products", CommandType.Text);

            foreach (DataRow linieBD in dsProducts.Tables[PRIMUL_TABEL].Rows)
            {
                var product = new Product(linieBD);
                result.Add(product);
            }
            return result;
        }

        public Product GetProduct(int product_id)
        {
            Product result = null;
            var dsProducts = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Products WHERE product_id = @product_id", CommandType.Text,
                new SqlParameter("@product_id", product_id));

            if (dsProducts.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsProducts.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Product(linieBD);
            }
            return result;
        }

        public bool AddProduct(Product p)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Products (product_id, product_name, description, price, image_url, category_id, popularity) VALUES (@product_id, @product_name, @description, @price, @image_url, @category_id, @popularity)", CommandType.Text,
                new SqlParameter("@product_id", p.Product_Id),
                new SqlParameter("@product_name", p.Product_Name),
                new SqlParameter("@description", p.Description),
                new SqlParameter("@price", p.Price),
                new SqlParameter("@image_url", p.Image_URL),
                new SqlParameter("@category_id", p.Category_Id),
                new SqlParameter("category_name", p.Category_Name)
            ) ;
        }

        public bool UpdateProduct(Product p)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Products SET product_name = @product_name, description = @description, price = @price, image_url = @image_url, category_id = @category_id, popularity = @popularity WHERE product_id = @product_id", CommandType.Text,
                new SqlParameter("@product_id", p.Product_Id),
                new SqlParameter("@product_name", p.Product_Name),
                new SqlParameter("@description", p.Description),
                new SqlParameter("@price", p.Price),
                new SqlParameter("@image_url", p.Image_URL),
                new SqlParameter("@category_id", p.Category_Id),
                new SqlParameter("category_name", p.Category_Name)
            );
        }
    }
}

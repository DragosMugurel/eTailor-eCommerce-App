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
            var dsProducts = SqlDBHelper.ExecuteDataSet("select * from dbo.Products", CommandType.Text);

            foreach (DataRow linieBD in dsProducts.Tables[PRIMUL_TABEL].Rows)
            {
                var product = new Product(linieBD);
                //incarca entitatile aditionale
                //product.Category = new AdministrareCategories().GetCategory(product.Category_Id);
                result.Add(product);
            }
            return result;
        }

        public Product GetProduct(int id)
        {
            Product result = null;
            var dsProducts = SqlDBHelper.ExecuteDataSet("select * from dbo.Products where Product_Id = @Product_Id", CommandType.Text,
                new SqlParameter("@Product_Id", id));

            if (dsProducts.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsProducts.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Product(linieBD);
                //incarca entitatile aditionale
                //result.Category = new AdministrareCategorii().GetCompanie(result.Category_Id);
            }
            return result;
        }

        public bool AddProduct(Product p)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.Products VALUES (@Product_Id, @Product_Name, @Description, @Price, @Image_URL, @Category_Id, @Category_Name, @Popularity)", CommandType.Text,
                new SqlParameter("@Product_Id", p.Product_Id),
                new SqlParameter("@Product_Name", p.Product_Name),
                new SqlParameter("@Description", p.Description),
                new SqlParameter("@Price", p.Price),
                new SqlParameter("@Image_URL", p.Image_URL),
                new SqlParameter("@Category_Id", p.Category_Id),
                new SqlParameter("@Category_Name", p.Category_Name),
                new SqlParameter("@Popularity", p.Popularity)
            );
        }

        public bool UpdateProduct(Product p)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "update dbo.Products set product_id = @Product_Id, product_name = @Product_Name, description = @Description, price = @Price, image_url = @Image_URL, category_id = @Category_Id, popularity = @Popularity where Product_Id = @Product_Id", CommandType.Text,
                new SqlParameter("@Product_Id", p.Product_Id),
                new SqlParameter("@Product_Name", p.Product_Name),
                new SqlParameter("@Description", p.Description),
                new SqlParameter("@Price", p.Price),
                new SqlParameter("@Image_URL", p.Image_URL),
                new SqlParameter("@Category_Id", p.Category_Id),
                new SqlParameter("@Category_Name", p.Category_Name),
                new SqlParameter("@Popularity", p.Popularity)
            );
        }

    }
}

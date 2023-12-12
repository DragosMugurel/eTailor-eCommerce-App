using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareCategories : IStocareCategories
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Category> GetCategories()
        {
            var result = new List<Category>();
            var dsCategories = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Categories", CommandType.Text);

            foreach (DataRow linieDB in dsCategories.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Category(linieDB));
            }
            return result;
        }

        public Category GetCategory(int category_id)
        {
            Category result = null;
            var dsCategories = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Categories WHERE category_id = @category_id", CommandType.Text,
                new SqlParameter("@category_id", category_id));

            if (dsCategories.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCategories.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Category(linieDB);
            }
            return result;
        }

        public bool AddCategory(Category cat)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Categories (category_id, category_name) VALUES (@category_id, @category_name)", CommandType.Text,
                new SqlParameter("@category_id", cat.Category_Id),
                new SqlParameter("@category_name", cat.Category_Name));
        }

        public bool UpdateCategory(Category cat)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Categories SET category_name = @category_name WHERE category_id = @category_id", CommandType.Text,
                new SqlParameter("@category_id", cat.Category_Id),
                new SqlParameter("@category_name", cat.Category_Name));
        }

    }
}

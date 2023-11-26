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
            var dsCategories = SqlDBHelper.ExecuteDataSet("select * from dbo.Categories", CommandType.Text);

            foreach (DataRow linieDB in dsCategories.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Category(linieDB));
            }
            return result;
        }

        public Category GetCategory(int id)
        {
            Category result = null;
            var dsCategories = SqlDBHelper.ExecuteDataSet("select * from dbo.Categories where Category_Id = @Category_Id", CommandType.Text,
                new SqlParameter("@Category_Id", id));

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
                "INSERT INTO dbo.Categories VALUES (@Category_Id, @Category_Name)", CommandType.Text,
                new SqlParameter("@Category_Id", cat.Category_Id),
                new SqlParameter("@Category_Name", cat.Category_Name));
        }

        public bool UpdateCategory(Category cat)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Categories set Category_Id = @Category_Id, Category_Name = @Category_Name where Category_Id = @Category_Id", CommandType.Text,
                new SqlParameter("@Category_Id", cat.Category_Id),
                new SqlParameter("@Category_Name", cat.Category_Name));
        }

    }
}

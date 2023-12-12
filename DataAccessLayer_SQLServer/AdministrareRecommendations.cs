using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareRecommendation : IStocareRecommendations
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Recommendation> GetRecommendations()
        {
            var result = new List<Recommendation>();
            var dsRecommendations = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Recommendations", CommandType.Text);

            foreach (DataRow linieBD in dsRecommendations.Tables[PRIMUL_TABEL].Rows)
            {
                var recommendation = new Recommendation(linieBD);
                result.Add(recommendation);
            }
            return result;
        }

        public Recommendation GetRecommendation(int recommended_product_id)
        {
            Recommendation result = null;
            var dsRecommendations = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Recommendations WHERE recommended_product_id = @recommended_product_id", CommandType.Text,
                new SqlParameter("@recommended_product_id", recommended_product_id));

            if (dsRecommendations.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsRecommendations.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Recommendation(linieBD);
            }
            return result;
        }

        public bool AddRecommendation(Recommendation r)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Recommendations (recommended_product_id, user_id, product_id, score) VALUES (@recommended_product_id, @user_id, @product_id, @score)", CommandType.Text,
                new SqlParameter("@recommended_product_id", r.Recommended_Product_Id),
                new SqlParameter("@user_id", r.User_Id),
                new SqlParameter("@product_id", r.Product_Id),
                new SqlParameter("@score", r.Score));
        }

        public bool UpdateRecommendation(Recommendation r)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Recommendations SET user_id = @user_id, product_id = @product_id, score = @score WHERE recommended_product_id = @recommended_product_id", CommandType.Text,
                new SqlParameter("@recommended_product_id", r.Recommended_Product_Id),
                new SqlParameter("@user_id", r.User_Id),
                new SqlParameter("@product_id", r.Product_Id),
                new SqlParameter("@score", r.Score));
        }
    }
}

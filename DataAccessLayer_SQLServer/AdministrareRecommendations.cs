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
            var dsRecommendations = SqlDBHelper.ExecuteDataSet("select * from dbo.Recommendations", CommandType.Text);

            foreach (DataRow linieBD in dsRecommendations.Tables[PRIMUL_TABEL].Rows)
            {
                var recommendation = new Recommendation(linieBD);
                //incarca entitatile aditionale
                //recommendation.Category = new AdministrareCategories().GetCategory(recommendation.Category_Id);
                result.Add(recommendation);
            }
            return result;
        }

        public Recommendation GetRecommendation(int id)
        {
            Recommendation result = null;
            var dsRecommendations = SqlDBHelper.ExecuteDataSet("select * from dbo.Recommendations where Recommended_Product_Id = @Recommended_Product_Id", CommandType.Text,
                new SqlParameter("@Recommended_Product_Id", id));

            if (dsRecommendations.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsRecommendations.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Recommendation(linieBD);
                //incarca entitatile aditionale
                //result.Category = new AdministrareCategorii().GetCompanie(result.Category_Id);
            }
            return result;
        }

        public bool AddRecommendation(Recommendation r)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.Recommendations VALUES (@Recommended_Product_Id, @User_Id, @Product_Id, @Score)", CommandType.Text,
                new SqlParameter("@Recommended_Product_Id", r.Recommended_Product_Id),
                new SqlParameter("@User_Id", r.User_Id),
                new SqlParameter("@Product_Id", r.Product_Id),
                new SqlParameter("@Score", r.Score));
        }

        public bool UpdateRecommendation(Recommendation r)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "update dbo.Recommendations set Recommended_Product_Id = @Recommended_Product_Id, User_Id = @User_Id, Product_Id = @Product_Id, Score = @Score where Recommended_Product_Id = @Recommended_Product_Id", CommandType.Text,
                new SqlParameter("@Recommended_Product_Id", r.Recommended_Product_Id),
                new SqlParameter("@User_Id", r.User_Id),
                new SqlParameter("@Product_Id", r.Product_Id),
                new SqlParameter("@Score", r.Score));
        }

    }

}
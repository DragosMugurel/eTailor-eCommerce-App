using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibrarieModele
{
    public class Recommendation
    {
        [Key]
        public int Recommended_Product_Id { get; set; }
        public int User_Id { get; set; }
        public int Product_Id { get; set; }
        public float Score { get; set; }


        public Recommendation()
        { }

        public Recommendation(float score, int recommended_product_id = 0, int user_id = 0, int product_id = 0)
        {
            Recommended_Product_Id = recommended_product_id;
            User_Id = user_id;
            Product_Id = product_id;
            Score = score;
        }

        public Recommendation(DataRow linieDB)
        {
            Recommended_Product_Id = Convert.ToInt32(linieDB["recommended_product_id"].ToString());
            User_Id = Convert.ToInt32(linieDB["user_id"].ToString());
            Product_Id = Convert.ToInt32(linieDB["product_id"].ToString());
            Score = Convert.ToSingle(linieDB["score"].ToString());
        }


    }
}

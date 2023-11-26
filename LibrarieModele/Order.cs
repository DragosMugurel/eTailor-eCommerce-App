using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibrarieModele
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        public int User_Id { get; set; }
        public decimal Total_Price { get; set; }
        public DateTime Created_At { get; set; }
        public int Product_Id { get; set; }

        public Order()
        { }

        public Order(decimal total_price, DateTime created_at, int order_id = 0, int user_id = 0, int product_id = 0)
        {
            Order_Id = order_id;
            User_Id = user_id;
            Total_Price = total_price;
            Created_At = created_at;
            Product_Id = product_id;
        }

        public Order(DataRow linieDB)
        {
            Order_Id = Convert.ToInt32(linieDB["order_id"].ToString());
            User_Id = Convert.ToInt32(linieDB["user_id"].ToString());
            Total_Price = Convert.ToDecimal(linieDB["total_price"].ToString());
            Created_At = Convert.ToDateTime(linieDB["created_at"].ToString());
            Product_Id = Convert.ToInt32(linieDB["product_id"].ToString());
        }
    }
}

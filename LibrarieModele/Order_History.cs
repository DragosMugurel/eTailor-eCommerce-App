using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace LibrarieModele
{

    public class Order_History
    {
        [ForeignKey("Order_Id")]
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total_Price { get; set; }
        public DateTime Order_Date { get; set; }
        public string Order_Status { get; set; }

        public Order_History()
        { }

        public Order_History(int quantity, decimal price, decimal total_price, DateTime order_date, string order_status, int order_id = 0, int product_id = 0)
        {
            Order_Id = order_id;
            Product_Id = product_id;
            Quantity = quantity;
            Price = price;
            Total_Price = total_price;
            Order_Date = order_date;
            Order_Status = order_status;
        }

        public Order_History(DataRow linieDB)
        {
            Order_Id = Convert.ToInt32(linieDB["order_id"].ToString());
            Product_Id = Convert.ToInt32(linieDB["product_id"].ToString());
            Quantity = Convert.ToInt32(linieDB["quantity"].ToString());
            Price = Convert.ToDecimal(linieDB["price"].ToString());
            Total_Price = Convert.ToDecimal(linieDB["total_price"].ToString());
            Order_Date = Convert.ToDateTime(linieDB["order_date"].ToString());
            Order_Status = linieDB["order_status"].ToString();
        }
    }
}

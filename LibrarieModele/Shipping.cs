using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibrarieModele
{
    public class Shipping
    {
        [Key]
        public int Shipping_Id { get; set; }
        public int Order_Id { get; set; }
        public DateTime Shipping_Date { get; set; }
        public string Shipping_Address { get; set; }

        public Shipping()
        { }

        public Shipping(DateTime shipping_date, string shipping_address, int shipping_id = 0, int order_id = 0)
        {
            Shipping_Id = shipping_id;
            Order_Id = order_id;
            Shipping_Date = shipping_date;
            Shipping_Address = shipping_address;
        }

        public Shipping(DataRow linieDB)
        {
            Shipping_Id = Convert.ToInt32(linieDB["shipping_id"].ToString());
            Order_Id = Convert.ToInt32(linieDB["order_id"].ToString());
            Shipping_Date = Convert.ToDateTime(linieDB["shipping_date"].ToString());
            Shipping_Address = linieDB["shipping_address"].ToString();
        }
    }
}

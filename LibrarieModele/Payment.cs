using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibrarieModele
{
    public class Payment
    {
        [Key]
        public int Payment_Id { get; set; }
        public int Order_Id { get; set; }
        public DateTime Payment_Date { get; set; }
        public string Payment_Method { get; set; }

        public Payment()
        { }

        public Payment(DateTime payment_date, string payment_method, int payment_id = 0, int order_id = 0)
        {
            Payment_Id = payment_id;
            Order_Id = order_id;
            Payment_Date = payment_date;
            Payment_Method = payment_method;
        }

        public Payment(DataRow linieDB)
        {
            Payment_Id = Convert.ToInt32(linieDB["payment_id"].ToString());
            Order_Id = Convert.ToInt32(linieDB["order_id"].ToString());
            Payment_Date = Convert.ToDateTime(linieDB["payment_date"].ToString());
            Payment_Method = linieDB["payment_method"].ToString();
        }
    }
}

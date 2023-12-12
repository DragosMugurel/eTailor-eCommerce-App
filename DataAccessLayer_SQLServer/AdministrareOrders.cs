using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareOrders : IStocareOrders
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Order> GetOrders()
        {
            var result = new List<Order>();
            var dsOrders = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Orders", CommandType.Text);

            foreach (DataRow linieBD in dsOrders.Tables[PRIMUL_TABEL].Rows)
            {
                var order = new Order(linieBD);
                result.Add(order);
            }
            return result;
        }

        public Order GetOrder(int order_id)
        {
            Order result = null;
            var dsOrders = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Orders WHERE order_id = @order_id", CommandType.Text,
                new SqlParameter("@order_id", order_id));

            if (dsOrders.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsOrders.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Order(linieBD);
            }
            return result;
        }

        public bool AddOrder(Order o)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Orders (order_id, user_id, total_price, created_at, product_id) VALUES (@order_id, @user_id, @total_price, @created_at, @product_id)", CommandType.Text,
                new SqlParameter("@order_id", o.Order_Id),
                new SqlParameter("@user_id", o.User_Id),
                new SqlParameter("@total_price", o.Total_Price),
                new SqlParameter("@created_at", o.Created_At),
                new SqlParameter("@product_id", o.Product_Id)
            );
        }

        public bool UpdateOrder(Order o)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Orders SET user_id = @user_id, total_price = @total_price, created_at = @created_at, product_id = @product_id WHERE order_id = @order_id", CommandType.Text,
                new SqlParameter("@order_id", o.Order_Id),
                new SqlParameter("@user_id", o.User_Id),
                new SqlParameter("@total_price", o.Total_Price),
                new SqlParameter("@created_at", o.Created_At),
                new SqlParameter("@product_id", o.Product_Id)
            );
        }
    }
}

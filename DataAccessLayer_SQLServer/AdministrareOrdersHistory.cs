using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareOrdersHistory : IStocareOrdersHistory
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Order_History> GetOrdersHistory()
        {
            var result = new List<Order_History>();
            var dsOrders_History = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Order_History", CommandType.Text);

            foreach (DataRow linieBD in dsOrders_History.Tables[PRIMUL_TABEL].Rows)
            {
                var order_history = new Order_History(linieBD);
                result.Add(order_history);
            }
            return result;
        }

        public Order_History GetOrder_History(int order_id)
        {
            Order_History result = null;
            var dsOrders_History = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Order_History WHERE order_id = @order_id", CommandType.Text,
                new SqlParameter("@order_id", order_id));

            if (dsOrders_History.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsOrders_History.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Order_History(linieBD);
            }
            return result;
        }

        public bool AddOrder_History(Order_History ord)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Order_History (order_id, product_id, quantity, price, total_price, order_date, order_status) VALUES (@order_id, @product_id, @quantity, @price, @total_price, @order_date, @order_status)", CommandType.Text,
                new SqlParameter("@order_id", ord.Order_Id),
                new SqlParameter("@product_id", ord.Product_Id),
                new SqlParameter("@quantity", ord.Quantity),
                new SqlParameter("@price", ord.Price),
                new SqlParameter("@total_price", ord.Total_Price),
                new SqlParameter("@order_date", ord.Order_Date),
                new SqlParameter("@order_status", ord.Order_Status)
            );
        }

        public bool UpdateOrder_History(Order_History ord)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Order_History SET product_id = @product_id, quantity = @quantity, price = @price, total_price = @total_price, order_date = @order_date, order_status = @order_status WHERE order_id = @order_id", CommandType.Text,
                new SqlParameter("@order_id", ord.Order_Id),
                new SqlParameter("@product_id", ord.Product_Id),
                new SqlParameter("@quantity", ord.Quantity),
                new SqlParameter("@price", ord.Price),
                new SqlParameter("@total_price", ord.Total_Price),
                new SqlParameter("@order_date", ord.Order_Date),
                new SqlParameter("@order_status", ord.Order_Status)
            );
        }
    }
}

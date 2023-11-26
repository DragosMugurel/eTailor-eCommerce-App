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
            var dsOrders_History = SqlDBHelper.ExecuteDataSet("select * from dbo.Order_History", CommandType.Text);

            foreach (DataRow linieBD in dsOrders_History.Tables[PRIMUL_TABEL].Rows)
            {
                var order_history = new Order_History(linieBD);
                //incarca entitatile aditionale
                //order.Category = new AdministrareOrders().GetOrder(order.Order_Id);
                result.Add(order_history);
            }
            return result;
        }

        public Order_History GetOrder_History(int id)
        {
            Order_History result = null;
            var dsOrders_History = SqlDBHelper.ExecuteDataSet("select * from dbo.Order_History where Order_Id = @Order_Id", CommandType.Text,
                new SqlParameter("@Order_Id", id));

            if (dsOrders_History.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsOrders_History.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Order_History(linieBD);
                //incarca entitatile aditionale
                //result.Category = new AdministrareCategorii().GetCompanie(result.Category_Id);
            }
            return result;
        }

        public bool AddOrder_History(Order_History ord)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.Order_History VALUES (@Order_Id, @Product_Id, @Quantity, @Price, @Total_Price, @Order_Date, @Order_Status)", CommandType.Text,
                new SqlParameter("@Order_Id", ord.Order_Id),
                new SqlParameter("@Product_Id", ord.Product_Id),
                new SqlParameter("@Quantity", ord.Quantity),
                new SqlParameter("@Price", ord.Price),
                new SqlParameter("@Total_Price", ord.Total_Price),
                new SqlParameter("@Order_Date", ord.Order_Date),
                new SqlParameter("@Order_Status", ord.Order_Status)
            );
        }

        public bool UpdateOrder_History(Order_History ord)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "update dbo.Order_History set Product_Id = @Product_Id, Quantity = @Quantity, Price = @Price, Total_Price = @Total_Price, Order_Date = @Order_Date, Order_Status = @Order_Status where Order_Id = @Order_Id", CommandType.Text,
                new SqlParameter("@Order_Id", ord.Order_Id),
                new SqlParameter("@Product_Id", ord.Product_Id),
                new SqlParameter("@Quantity", ord.Quantity),
                new SqlParameter("@Price", ord.Price),
                new SqlParameter("@Total_Price", ord.Total_Price),
                new SqlParameter("@Order_Date", ord.Order_Date),
                new SqlParameter("@Order_Status", ord.Order_Status)
            );
        }




    }
}

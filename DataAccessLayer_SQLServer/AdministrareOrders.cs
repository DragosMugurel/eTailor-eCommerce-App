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
            var dsOrders = SqlDBHelper.ExecuteDataSet("select * from dbo.Orders", CommandType.Text);

            foreach (DataRow linieBD in dsOrders.Tables[PRIMUL_TABEL].Rows)
            {
                var order = new Order(linieBD);
                //incarca entitatile aditionale
                //order.Category = new AdministrareOrders().GetOrder(order.Order_Id);
                result.Add(order);
            }
            return result;
        }

        public Order GetOrders(int id)
        {
            Order result = null;
            var dsOrders = SqlDBHelper.ExecuteDataSet("select * from dbo.Orders where Order_Id = @Order_Id", CommandType.Text,
                new SqlParameter("@Product_Id", id));

            if (dsOrders.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsOrders.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Order(linieBD);
                //incarca entitatile aditionale
                //result.Category = new AdministrareCategorii().GetCompanie(result.Category_Id);
            }
            return result;
        }

        public bool AddOrder(Order o)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.Orders VALUES (@Order_Id, @User_Id, @Total_Price, @Created_At, @Product_Id)", CommandType.Text,
                new SqlParameter("@Order_Id", o.Order_Id),
                new SqlParameter("@User_Id", o.User_Id),
                new SqlParameter("@Total_Price", o.Total_Price),
                new SqlParameter("@Created_At", o.Created_At),
                new SqlParameter("@Product_Id", o.Product_Id)
            );
        }

        public bool UpdateOrder(Order o)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "update dbo.Orders set User_Id = @User_Id, Total_Price = @Total_Price, Created_At = @Created_At, Product_Id = @Product_Id where Order_Id = @Order_Id", CommandType.Text,
                new SqlParameter("@Order_Id", o.Order_Id),
                new SqlParameter("@User_Id", o.User_Id),
                new SqlParameter("@Total_Price", o.Total_Price),
                new SqlParameter("@Created_At", o.Created_At),
                new SqlParameter("@Product_Id", o.Product_Id)
            );
        }



    }
}

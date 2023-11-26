using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareShippings : IStocareShippings
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Shipping> GetShippings()
        {
            var result = new List<Shipping>();
            var dsShipping = SqlDBHelper.ExecuteDataSet("select * from dbo.Shipping", CommandType.Text);

            foreach (DataRow linieBD in dsShipping.Tables[PRIMUL_TABEL].Rows)
            {
                var shipping = new Shipping(linieBD);
                //incarca entitatile aditionale
                //order.Category = new AdministrareOrders().GetOrder(order.Order_Id);
                result.Add(shipping);
            }
            return result;
        }

        public Shipping GetShipping(int id)
        {
            Shipping result = null;
            var dsShipping = SqlDBHelper.ExecuteDataSet("select * from dbo.Shipping where Shipping_Id = @Shipping_Id", CommandType.Text,
                new SqlParameter("@Shipping_Id", id));

            if (dsShipping.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsShipping.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Shipping(linieBD);
                //incarca entitatile aditionale
                //result.Category = new AdministrareCategorii().GetCompanie(result.Category_Id);
            }
            return result;
        }

        public bool AddShipping(Shipping sh)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.Shipping VALUES (@Shipping_Id, @Order_Id, @Shipping_Date, @Shipping_Address)", CommandType.Text,
                new SqlParameter("@Shipping_Id", sh.Shipping_Id),
                new SqlParameter("@Order_Id", sh.Order_Id),
                new SqlParameter("@Shipping_Date", sh.Shipping_Date),
                new SqlParameter("@Shipping_Address", sh.Shipping_Address)
            );
        }

        public bool UpdateShipping(Shipping sh)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "update dbo.Shipping set Order_Id = @Order_Id, Shipping_Date = @Shipping Date, Shipping_Address = @Shipping_Address where Shipping_Id = @Shipping_Id", CommandType.Text,
                new SqlParameter("@Shipping_Id", sh.Shipping_Id),
                new SqlParameter("@Order_Id", sh.Order_Id),
                new SqlParameter("@Shipping_Date", sh.Shipping_Date),
                new SqlParameter("@Shipping_Address", sh.Shipping_Address)
            );
        }





    }
}

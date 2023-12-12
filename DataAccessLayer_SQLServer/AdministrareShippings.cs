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
            var dsShipping = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Shipping", CommandType.Text);

            foreach (DataRow linieBD in dsShipping.Tables[PRIMUL_TABEL].Rows)
            {
                var shipping = new Shipping(linieBD);
                result.Add(shipping);
            }
            return result;
        }

        public Shipping GetShipping(int shipping_id)
        {
            Shipping result = null;
            var dsShipping = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Shipping WHERE shipping_id = @shipping_id", CommandType.Text,
                new SqlParameter("@shipping_id", shipping_id));

            if (dsShipping.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsShipping.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Shipping(linieBD);
            }
            return result;
        }

        public bool AddShipping(Shipping sh)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Shipping (shipping_id, order_id, shipping_date, shipping_address) VALUES (@shipping_id, @order_id, @shipping_date, @shipping_address)", CommandType.Text,
                new SqlParameter("@shipping_id", sh.Shipping_Id),
                new SqlParameter("@order_id", sh.Order_Id),
                new SqlParameter("@shipping_date", sh.Shipping_Date),
                new SqlParameter("@shipping_address", sh.Shipping_Address)
            );
        }

        public bool UpdateShipping(Shipping sh)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Shipping SET order_id = @order_id, shipping_date = @shipping_date, shipping_address = @shipping_address WHERE shipping_id = @shipping_id", CommandType.Text,
                new SqlParameter("@shipping_id", sh.Shipping_Id),
                new SqlParameter("@order_id", sh.Order_Id),
                new SqlParameter("@shipping_date", sh.Shipping_Date),
                new SqlParameter("@shipping_address", sh.Shipping_Address)
            );
        }
    }
}

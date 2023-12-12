using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrarePayments : IStocarePayments
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Payment> GetPayments()
        {
            var result = new List<Payment>();
            var dsPayments = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Payments", CommandType.Text);

            foreach (DataRow linieDB in dsPayments.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Payment(linieDB));
            }
            return result;
        }

        public Payment GetPayment(int payment_id)
        {
            Payment result = null;
            var dsPayments = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Payments WHERE payment_id = @payment_id", CommandType.Text,
                new SqlParameter("@payment_id", payment_id));

            if (dsPayments.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsPayments.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Payment(linieDB);
            }
            return result;
        }

        public bool AddPayment(Payment pay)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Payments (payment_id, order_id, payment_date, payment_method) VALUES (@payment_id, @order_id, @payment_date, @payment_method)", CommandType.Text,
                new SqlParameter("@payment_id", pay.Payment_Id),
                new SqlParameter("@order_id", pay.Order_Id),
                new SqlParameter("@payment_date", pay.Payment_Date),
                new SqlParameter("@payment_method", pay.Payment_Method));
        }

        public bool UpdatePayment(Payment pay)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Payments SET order_id = @order_id, payment_date = @payment_date, payment_method = @payment_method WHERE payment_id = @payment_id", CommandType.Text,
                new SqlParameter("@payment_id", pay.Payment_Id),
                new SqlParameter("@order_id", pay.Order_Id),
                new SqlParameter("@payment_date", pay.Payment_Date),
                new SqlParameter("@payment_method", pay.Payment_Method));
        }
    }
}

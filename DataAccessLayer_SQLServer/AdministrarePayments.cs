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
            var dsPayments = SqlDBHelper.ExecuteDataSet("select * from dbo.Payments", CommandType.Text);

            foreach (DataRow linieDB in dsPayments.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Payment(linieDB));
            }
            return result;
        }

        public Payment GetPayment(int id)
        {
            Payment result = null;
            var dsPayments = SqlDBHelper.ExecuteDataSet("select * from dbo.Payments where Payment_Id = @Payment_Id", CommandType.Text,
                new SqlParameter("@Payment_Id", id));

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
                "INSERT INTO dbo.Payments VALUES (@Payment_Id, @Order_Id, @Payment_Date, @Payment_Method)", CommandType.Text,
                new SqlParameter("@Payment_Id", pay.Payment_Id),
                new SqlParameter("@Order_Id", pay.Order_Id),
                new SqlParameter("@Payment_Date", pay.Payment_Date),
                new SqlParameter("@Payment_Method", pay.Payment_Method));
        }

        public bool UpdatePayment(Payment pay)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Payments set Order_Id = @Order_Id, Payment_Date = @Payment_Date, Payment_Method = @Payment_Method where Payment_Id = @Payment_Id", CommandType.Text,
                new SqlParameter("@Payment_Id", pay.Payment_Id),
                new SqlParameter("@Order_Id", pay.Order_Id),
                new SqlParameter("@Payment_Date", pay.Payment_Date),
                new SqlParameter("@Payment_Method", pay.Payment_Method));
        }


    }
}

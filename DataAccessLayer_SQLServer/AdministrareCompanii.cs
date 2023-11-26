using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareCompanii : IStocareCompanii
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Companie> GetCompanii()
        {
            var result = new List<Companie>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from dbo.Companii", CommandType.Text);

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Companie(linieDB));
            }
            return result;
        }

        public Companie GetCompanie(int id)
        {
            Companie result = null;
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from dbo.Companii where IdCompanie = @IdCompanie", CommandType.Text,
                new SqlParameter("@IdCompanie", id));

            if (dsCompanii.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCompanii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Companie(linieDB);
            }
            return result;
        }

        public bool AddCompanie(Companie comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Companii VALUES (@Nume, @Email, @Telefon, @Adresa)", CommandType.Text,
                new SqlParameter("@Nume", comp.Nume),
                new SqlParameter("@Email", comp.Email),
                new SqlParameter("@Telefon", comp.Telefon),
                new SqlParameter("@Adresa", comp.Adresa));
        }

        public bool UpdateCompanie(Companie comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Companii set Nume = @Nume, Email = @Email, Telefon = @Telefon, Adresa = @Adresa where IdCompanie = @IdCompanie", CommandType.Text,
                new SqlParameter("@Nume", comp.Nume),
                new SqlParameter("@Email", comp.Email),
                new SqlParameter("@Telefon", comp.Telefon),
                new SqlParameter("@Adresa", comp.Adresa),
                new SqlParameter("@IdCompanie", comp.IdCompanie));
        }
    }
}

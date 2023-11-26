using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareMasini : IStocareMasini
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Masina> GetMasini()
        {
            var result = new List<Masina>();
            var dsMasini = SqlDBHelper.ExecuteDataSet("select * from dbo.Masini", CommandType.Text);

            foreach (DataRow linieBD in dsMasini.Tables[PRIMUL_TABEL].Rows)
            {
                var masina = new Masina(linieBD);
                //incarca entitatile aditionale
                masina.Companie = new AdministrareCompanii().GetCompanie(masina.IdCompanie);
                result.Add(masina);
            }
            return result;
        }

        public Masina GetMasina(int id)
        {
            Masina result = null;
            var dsMasini = SqlDBHelper.ExecuteDataSet("select * from dbo.Masini where IdMasina = @IdMasina", CommandType.Text,
                new SqlParameter("@IdMasina", id));

            if (dsMasini.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsMasini.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Masina(linieBD);
                //incarca entitatile aditionale
                result.Companie = new AdministrareCompanii().GetCompanie(result.IdCompanie);
            }
            return result;
        }

        public bool AddMasina(Masina m)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.Masini VALUES (@DataFabricatie, @IdCompanie, @Model, @Pret)", CommandType.Text,
                new SqlParameter("@DataFabricatie", m.DataFabricatie),
                new SqlParameter("@IdCompanie", m.IdCompanie),
                new SqlParameter("@Model", m.Model),
                new SqlParameter("@Pret", m.Pret)
            );
        }

        public bool UpdateMasina(Masina m)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Masini set dataFabricatie = @DataFabricatie, idCompanie = @IdCompanie, model =@Model, pret =@Pret where idMasina=@IdMasina", CommandType.Text,
                 new SqlParameter("@DataFabricatie", m.DataFabricatie),
                new SqlParameter("@IdCompanie", m.IdCompanie),
                new SqlParameter("@Model", m.Model),
                new SqlParameter("@Pret", m.Pret),
                new SqlParameter("@IdMasina", m.IdMasina)
            );
        }
    }
}

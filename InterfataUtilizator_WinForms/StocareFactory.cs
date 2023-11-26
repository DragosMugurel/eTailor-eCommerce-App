using LibrarieModele;

using LibrarieModele_Interfete;

using System;
using System.Configuration;

namespace InterfataUtilizator
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public class StocareFactory
    {
        public IStocareFactory GetTipStocare(Type tipEntitate)
        {
            var formatSalvare = ConfigurationManager.AppSettings["FormatSalvare"];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "BazaDate_SQLServer":

                        if (tipEntitate == typeof(Companie))
                        {
                            return new NivelAccesDate_SQLServer.AdministrareCompanii();
                        }
                        if (tipEntitate == typeof(Masina))
                        {
                            return new NivelAccesDate_SQLServer.AdministrareMasini();
                        }
                        break;

                    case "BazaDate_Oracle":
                        if (tipEntitate == typeof(Companie))
                        {
                            return new NivelAccesDate_Oracle.AdministrareCompanii();
                        }
                        if (tipEntitate == typeof(Masina))
                        {
                            return new NivelAccesDate_Oracle.AdministrareMasini();
                        }
                        break;
                }
            }
            return null;
        }
    }
}

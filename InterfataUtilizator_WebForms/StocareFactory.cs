using LibrarieModele;

using LibrarieModele_Interfete;

using NivelAccesDate_SQLServer;

using System;
using System.Configuration;

namespace InterfataUtilizator_WebForms
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
                            return new AdministrareCompanii();
                        }
                        if (tipEntitate == typeof(Masina))
                        {
                            return new AdministrareMasini();
                        }
                        break;

                    case "BazaDate_Oracle":
                        if (tipEntitate == typeof(Companie))
                        {
                            return new AdministrareCompanii();
                        }
                        if (tipEntitate == typeof(Masina))
                        {
                            return new AdministrareMasini();
                        }
                        break;
                }
            }
            return null;
        }
    }
}

using LibrarieModele;

using LibrarieModele_Interfete;

using System;
using System.Linq;

namespace InterfataUtilizator_WebForms
{
    public partial class ListaMasini : System.Web.UI.Page
    {
        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)
        IStocareCompanii stocareCompanii = (IStocareCompanii)new StocareFactory().GetTipStocare(typeof(Companie));
        IStocareMasini stocareMasini = (IStocareMasini)new StocareFactory().GetTipStocare(typeof(Masina));

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Masina> GetMasini()
        {
            return stocareMasini.GetMasini().AsQueryable();
        }
    }
}
using LibrarieModele;

using LibrarieModele_Interfete;

using System;
using System.Web.UI;

namespace InterfataUtilizator_WebForms
{
    public partial class AdaugareCompanie : System.Web.UI.Page
    {
        private const bool SUCCES = true;

        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)
        IStocareCompanii stocareCompanii;
        IStocareMasini stocareMasini;

        protected void Page_Load(object sender, EventArgs e)
        {
            stocareMasini = (IStocareMasini)new StocareFactory().GetTipStocare(typeof(Masina));
            stocareCompanii = (IStocareCompanii)new StocareFactory().GetTipStocare(typeof(Companie));
            if (!Page.IsPostBack)
            {
                btnAdauga.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                btnAdauga.BackColor = System.Drawing.Color.Yellow;
            }
        }

        protected void btnAdauga_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                var rezultat = stocareCompanii.AddCompanie(new Companie(txtNume.Text, txtEmail.Text, Convert.ToInt64(txtTelefon.Text), txtAdresa.Text));
                if (rezultat == SUCCES)
                {
                    lblMesaj.Text = "Companie adaugata";
                }
                else
                {
                    lblMesaj.Text = "Eroare la adaugare companie";
                }

            }

        }

        protected void btnAfiseaza_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaMasini");
        }
    }
}
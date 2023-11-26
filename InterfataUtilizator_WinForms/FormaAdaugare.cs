using LibrarieModele;

using LibrarieModele_Interfete;

using MetroFramework.Forms;

using System;
using System.Linq;
using System.Windows.Forms;

namespace InterfataUtilizator
{
    public partial class FormaAdaugare : MetroForm
    {
        private const bool SUCCES = true;

        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)
        IStocareCompanii stocareCompanii = (IStocareCompanii)new StocareFactory().GetTipStocare(typeof(Companie));
        IStocareMasini stocareMasini = (IStocareMasini)new StocareFactory().GetTipStocare(typeof(Masina));

        public FormaAdaugare()
        {
            InitializeComponent();
            if (stocareMasini == null || stocareCompanii == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }

        #region handlere ale evenimentelor formei
        private void FormaAdaugare_Load(object sender, EventArgs e)
        {
            IncarcaCompanii();
        }

        private void FormaAdaugare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region handlere ale evenimentelor controalelor de pe forma (butoane)
        /// <summary>
        /// Adauga informatiile despre o masina in tabelul catalog_DEV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdaugaMasina_Click(object sender, EventArgs e)
        {
            try
            {
                var masina = new Masina(
                    dtDataFabricatie.Value,
                    ((ComboItem)cmbCompanii.SelectedItem).Value,
                    txtModel.Text,
                    decimal.Parse(txtPret.Text));

                var rezultat = stocareMasini.AddMasina(masina);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Masina adaugata");
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare masina");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        /// <summary>
        /// Adauga o companie in tabelul Companii
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdaugaComp_Click(object sender, EventArgs e)
        {
            try
            {
                var rezultat = stocareCompanii.AddCompanie(new Companie(txtNume.Text, txtEmail.Text, Convert.ToInt64(txtTelefon.Text), txtAdresa.Text));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Companie adaugata");
                    IncarcaCompanii();
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare companie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormaAfisare f = new FormaAfisare();
            f.Show();
            this.Hide();
        }

        #endregion

        #region metode helper

        /// <summary>
        /// Afiseaza companiile din tabelul Companii in controlul de tip combobox
        /// </summary>
        private void IncarcaCompanii()
        {
            try
            {
                //se elimina itemii deja adaugati
                cmbCompanii.Items.Clear();

                var companii = stocareCompanii.GetCompanii();
                if (companii != null && companii.Any())
                {
                    foreach (var companie in companii)
                    {
                        cmbCompanii.Items.Add(new ComboItem(companie.Nume, (Int32)companie.IdCompanie));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}

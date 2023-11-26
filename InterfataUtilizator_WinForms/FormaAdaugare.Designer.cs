using MetroFramework.Controls;

namespace InterfataUtilizator
{
    partial class FormaAdaugare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMasina = new MetroFramework.Controls.MetroPanel();
            this.lblIdMasina = new MetroFramework.Controls.MetroLabel();
            this.btnAdaugaMasina = new MetroFramework.Controls.MetroButton();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.cmbCompanii = new MetroFramework.Controls.MetroComboBox();
            this.txtModel = new MetroFramework.Controls.MetroTextBox();
            this.txtPret = new MetroFramework.Controls.MetroTextBox();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.btnAdaugaComp = new MetroFramework.Controls.MetroButton();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.label7 = new MetroFramework.Controls.MetroLabel();
            this.label8 = new MetroFramework.Controls.MetroLabel();
            this.label9 = new MetroFramework.Controls.MetroLabel();
            this.txtTelefon = new MetroFramework.Controls.MetroTextBox();
            this.txtAdresa = new MetroFramework.Controls.MetroTextBox();
            this.txtNume = new MetroFramework.Controls.MetroTextBox();
            this.pnlCompanie = new MetroFramework.Controls.MetroPanel();
            this.dtDataFabricatie = new MetroFramework.Controls.MetroDateTime();
            this.lblTitluCompanie = new MetroFramework.Controls.MetroLabel();
            this.lblTitluMasina = new MetroFramework.Controls.MetroLabel();
            this.pnlMasina.SuspendLayout();
            this.pnlCompanie.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMasina
            // 
            this.pnlMasina.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMasina.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMasina.Controls.Add(this.lblTitluMasina);
            this.pnlMasina.Controls.Add(this.dtDataFabricatie);
            this.pnlMasina.Controls.Add(this.lblIdMasina);
            this.pnlMasina.Controls.Add(this.btnAdaugaMasina);
            this.pnlMasina.Controls.Add(this.label4);
            this.pnlMasina.Controls.Add(this.label3);
            this.pnlMasina.Controls.Add(this.label2);
            this.pnlMasina.Controls.Add(this.label1);
            this.pnlMasina.Controls.Add(this.cmbCompanii);
            this.pnlMasina.Controls.Add(this.txtModel);
            this.pnlMasina.Controls.Add(this.txtPret);
            this.pnlMasina.HorizontalScrollbarBarColor = true;
            this.pnlMasina.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMasina.HorizontalScrollbarSize = 10;
            this.pnlMasina.Location = new System.Drawing.Point(23, 305);
            this.pnlMasina.Name = "pnlMasina";
            this.pnlMasina.Size = new System.Drawing.Size(316, 230);
            this.pnlMasina.TabIndex = 12;
            this.pnlMasina.Text = "Adaugare masina";
            this.pnlMasina.VerticalScrollbarBarColor = true;
            this.pnlMasina.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMasina.VerticalScrollbarSize = 10;
            // 
            // lblIdMasina
            // 
            this.lblIdMasina.AutoSize = true;
            this.lblIdMasina.Location = new System.Drawing.Point(431, 69);
            this.lblIdMasina.Name = "lblIdMasina";
            this.lblIdMasina.Size = new System.Drawing.Size(0, 0);
            this.lblIdMasina.TabIndex = 9;
            this.lblIdMasina.Visible = false;
            // 
            // btnAdaugaMasina
            // 
            this.btnAdaugaMasina.Location = new System.Drawing.Point(213, 196);
            this.btnAdaugaMasina.Name = "btnAdaugaMasina";
            this.btnAdaugaMasina.Size = new System.Drawing.Size(75, 23);
            this.btnAdaugaMasina.TabIndex = 8;
            this.btnAdaugaMasina.Text = "Adauga";
            this.btnAdaugaMasina.UseSelectable = true;
            this.btnAdaugaMasina.Click += new System.EventHandler(this.btnAdaugaMasina_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pret";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Companie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Fabricatie";
            // 
            // cmbCompanii
            // 
            this.cmbCompanii.FormattingEnabled = true;
            this.cmbCompanii.ItemHeight = 23;
            this.cmbCompanii.Location = new System.Drawing.Point(123, 79);
            this.cmbCompanii.Name = "cmbCompanii";
            this.cmbCompanii.Size = new System.Drawing.Size(165, 29);
            this.cmbCompanii.TabIndex = 3;
            this.cmbCompanii.UseSelectable = true;
            // 
            // txtModel
            // 
            // 
            // 
            // 
            this.txtModel.CustomButton.Image = null;
            this.txtModel.CustomButton.Location = new System.Drawing.Point(137, 1);
            this.txtModel.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtModel.CustomButton.Name = "";
            this.txtModel.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtModel.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtModel.CustomButton.TabIndex = 1;
            this.txtModel.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtModel.CustomButton.UseSelectable = true;
            this.txtModel.CustomButton.Visible = false;
            this.txtModel.Lines = new string[0];
            this.txtModel.Location = new System.Drawing.Point(123, 114);
            this.txtModel.MaxLength = 32767;
            this.txtModel.Name = "txtModel";
            this.txtModel.PasswordChar = '\0';
            this.txtModel.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtModel.SelectedText = "";
            this.txtModel.SelectionLength = 0;
            this.txtModel.SelectionStart = 0;
            this.txtModel.ShortcutsEnabled = true;
            this.txtModel.Size = new System.Drawing.Size(165, 29);
            this.txtModel.TabIndex = 2;
            this.txtModel.UseSelectable = true;
            this.txtModel.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtModel.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPret
            // 
            // 
            // 
            // 
            this.txtPret.CustomButton.Image = null;
            this.txtPret.CustomButton.Location = new System.Drawing.Point(136, 1);
            this.txtPret.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtPret.CustomButton.Name = "";
            this.txtPret.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtPret.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPret.CustomButton.TabIndex = 1;
            this.txtPret.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPret.CustomButton.UseSelectable = true;
            this.txtPret.CustomButton.Visible = false;
            this.txtPret.Lines = new string[0];
            this.txtPret.Location = new System.Drawing.Point(124, 149);
            this.txtPret.MaxLength = 32767;
            this.txtPret.Name = "txtPret";
            this.txtPret.PasswordChar = '\0';
            this.txtPret.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPret.SelectedText = "";
            this.txtPret.SelectionLength = 0;
            this.txtPret.SelectionStart = 0;
            this.txtPret.ShortcutsEnabled = true;
            this.txtPret.Size = new System.Drawing.Size(164, 29);
            this.txtPret.TabIndex = 1;
            this.txtPret.UseSelectable = true;
            this.txtPret.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPret.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(264, 553);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseCustomForeColor = true;
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEmail
            // 
            // 
            // 
            // 
            this.txtEmail.CustomButton.Image = null;
            this.txtEmail.CustomButton.Location = new System.Drawing.Point(146, 2);
            this.txtEmail.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.CustomButton.Name = "";
            this.txtEmail.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmail.CustomButton.TabIndex = 1;
            this.txtEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmail.CustomButton.UseSelectable = true;
            this.txtEmail.CustomButton.Visible = false;
            this.txtEmail.Lines = new string[0];
            this.txtEmail.Location = new System.Drawing.Point(123, 71);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.Size = new System.Drawing.Size(164, 20);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.UseSelectable = true;
            this.txtEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 0);
            this.label5.TabIndex = 9;
            this.label5.Visible = false;
            // 
            // btnAdaugaComp
            // 
            this.btnAdaugaComp.Location = new System.Drawing.Point(213, 176);
            this.btnAdaugaComp.Name = "btnAdaugaComp";
            this.btnAdaugaComp.Size = new System.Drawing.Size(75, 23);
            this.btnAdaugaComp.TabIndex = 8;
            this.btnAdaugaComp.Text = "Adauga";
            this.btnAdaugaComp.UseSelectable = true;
            this.btnAdaugaComp.Click += new System.EventHandler(this.btnAdaugaComp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Adresa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Telefon";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(22, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nume";
            // 
            // txtTelefon
            // 
            // 
            // 
            // 
            this.txtTelefon.CustomButton.Image = null;
            this.txtTelefon.CustomButton.Location = new System.Drawing.Point(146, 2);
            this.txtTelefon.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefon.CustomButton.Name = "";
            this.txtTelefon.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtTelefon.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTelefon.CustomButton.TabIndex = 1;
            this.txtTelefon.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTelefon.CustomButton.UseSelectable = true;
            this.txtTelefon.CustomButton.Visible = false;
            this.txtTelefon.Lines = new string[0];
            this.txtTelefon.Location = new System.Drawing.Point(124, 106);
            this.txtTelefon.MaxLength = 32767;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.PasswordChar = '\0';
            this.txtTelefon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTelefon.SelectedText = "";
            this.txtTelefon.SelectionLength = 0;
            this.txtTelefon.SelectionStart = 0;
            this.txtTelefon.ShortcutsEnabled = true;
            this.txtTelefon.Size = new System.Drawing.Size(164, 20);
            this.txtTelefon.TabIndex = 2;
            this.txtTelefon.UseSelectable = true;
            this.txtTelefon.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTelefon.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAdresa
            // 
            // 
            // 
            // 
            this.txtAdresa.CustomButton.Image = null;
            this.txtAdresa.CustomButton.Location = new System.Drawing.Point(146, 2);
            this.txtAdresa.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdresa.CustomButton.Name = "";
            this.txtAdresa.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtAdresa.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdresa.CustomButton.TabIndex = 1;
            this.txtAdresa.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdresa.CustomButton.UseSelectable = true;
            this.txtAdresa.CustomButton.Visible = false;
            this.txtAdresa.Lines = new string[0];
            this.txtAdresa.Location = new System.Drawing.Point(124, 137);
            this.txtAdresa.MaxLength = 32767;
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.PasswordChar = '\0';
            this.txtAdresa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdresa.SelectedText = "";
            this.txtAdresa.SelectionLength = 0;
            this.txtAdresa.SelectionStart = 0;
            this.txtAdresa.ShortcutsEnabled = true;
            this.txtAdresa.Size = new System.Drawing.Size(164, 20);
            this.txtAdresa.TabIndex = 1;
            this.txtAdresa.UseSelectable = true;
            this.txtAdresa.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdresa.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtNume
            // 
            // 
            // 
            // 
            this.txtNume.CustomButton.Image = null;
            this.txtNume.CustomButton.Location = new System.Drawing.Point(146, 2);
            this.txtNume.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtNume.CustomButton.Name = "";
            this.txtNume.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtNume.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNume.CustomButton.TabIndex = 1;
            this.txtNume.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNume.CustomButton.UseSelectable = true;
            this.txtNume.CustomButton.Visible = false;
            this.txtNume.Lines = new string[0];
            this.txtNume.Location = new System.Drawing.Point(124, 41);
            this.txtNume.MaxLength = 32767;
            this.txtNume.Name = "txtNume";
            this.txtNume.PasswordChar = '\0';
            this.txtNume.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNume.SelectedText = "";
            this.txtNume.SelectionLength = 0;
            this.txtNume.SelectionStart = 0;
            this.txtNume.ShortcutsEnabled = true;
            this.txtNume.Size = new System.Drawing.Size(164, 20);
            this.txtNume.TabIndex = 0;
            this.txtNume.UseSelectable = true;
            this.txtNume.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNume.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pnlCompanie
            // 
            this.pnlCompanie.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlCompanie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCompanie.Controls.Add(this.lblTitluCompanie);
            this.pnlCompanie.Controls.Add(this.txtEmail);
            this.pnlCompanie.Controls.Add(this.label5);
            this.pnlCompanie.Controls.Add(this.btnAdaugaComp);
            this.pnlCompanie.Controls.Add(this.label6);
            this.pnlCompanie.Controls.Add(this.label7);
            this.pnlCompanie.Controls.Add(this.label8);
            this.pnlCompanie.Controls.Add(this.label9);
            this.pnlCompanie.Controls.Add(this.txtTelefon);
            this.pnlCompanie.Controls.Add(this.txtAdresa);
            this.pnlCompanie.Controls.Add(this.txtNume);
            this.pnlCompanie.HorizontalScrollbarBarColor = true;
            this.pnlCompanie.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlCompanie.HorizontalScrollbarSize = 10;
            this.pnlCompanie.Location = new System.Drawing.Point(23, 63);
            this.pnlCompanie.Name = "pnlCompanie";
            this.pnlCompanie.Size = new System.Drawing.Size(316, 214);
            this.pnlCompanie.TabIndex = 11;
            this.pnlCompanie.Text = "Adaugare companie";
            this.pnlCompanie.VerticalScrollbarBarColor = true;
            this.pnlCompanie.VerticalScrollbarHighlightOnWheel = false;
            this.pnlCompanie.VerticalScrollbarSize = 10;
            // 
            // dtDataFabricatie
            // 
            this.dtDataFabricatie.Location = new System.Drawing.Point(124, 40);
            this.dtDataFabricatie.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtDataFabricatie.Name = "dtDataFabricatie";
            this.dtDataFabricatie.Size = new System.Drawing.Size(164, 29);
            this.dtDataFabricatie.TabIndex = 10;
            // 
            // lblTitluCompanie
            // 
            this.lblTitluCompanie.AutoSize = true;
            this.lblTitluCompanie.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitluCompanie.Location = new System.Drawing.Point(22, 11);
            this.lblTitluCompanie.Name = "lblTitluCompanie";
            this.lblTitluCompanie.Size = new System.Drawing.Size(145, 19);
            this.lblTitluCompanie.TabIndex = 11;
            this.lblTitluCompanie.Text = "Adaugare companie";
            // 
            // lblTitluMasina
            // 
            this.lblTitluMasina.AutoSize = true;
            this.lblTitluMasina.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitluMasina.Location = new System.Drawing.Point(22, 11);
            this.lblTitluMasina.Name = "lblTitluMasina";
            this.lblTitluMasina.Size = new System.Drawing.Size(126, 19);
            this.lblTitluMasina.TabIndex = 12;
            this.lblTitluMasina.Text = "Adaugare masina";
            // 
            // FormaAdaugare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 589);
            this.Controls.Add(this.pnlCompanie);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlMasina);
            this.Name = "FormaAdaugare";
            this.Text = "Adaugare companie/masina";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaAdaugare_FormClosed);
            this.Load += new System.EventHandler(this.FormaAdaugare_Load);
            this.pnlMasina.ResumeLayout(false);
            this.pnlMasina.PerformLayout();
            this.pnlCompanie.ResumeLayout(false);
            this.pnlCompanie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroPanel pnlMasina;
        private MetroLabel lblIdMasina;
        private MetroButton btnAdaugaMasina;
        private MetroLabel label4;
        private MetroLabel label3;
        private MetroLabel label2;
        private MetroLabel label1;
        private MetroComboBox cmbCompanii;
        private MetroTextBox txtModel;
        private MetroTextBox txtPret;
        private MetroButton btnCancel;
        private MetroLabel label5;
        private MetroButton btnAdaugaComp;
        private MetroLabel label6;
        private MetroLabel label7;
        private MetroLabel label8;
        private MetroLabel label9;
        private MetroTextBox txtTelefon;
        private MetroTextBox txtAdresa;
        private MetroTextBox txtNume;
        private MetroTextBox txtEmail;
        private MetroPanel pnlCompanie;
        private MetroLabel lblTitluMasina;
        private MetroDateTime dtDataFabricatie;
        private MetroLabel lblTitluCompanie;
    }
}
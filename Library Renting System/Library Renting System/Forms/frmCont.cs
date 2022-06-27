using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Renting_System.Forms
{
    public partial class frmCont : Form
    {
        string username;
        string pass;
        string conectionString = @"Data Source = (local); Initial Catalog = UserRegistrationDB; Integrated Security=True;";
        public frmCont(string username, string pass)
        {
            InitializeComponent();
            this.username = username;
            this.pass = pass;
        }

        private void LoadTheme()
        {
            foreach (Control btn in this.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    btn.BackColor = ThemeColor.SecondaryColor;
                    btn.ForeColor = Color.White;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            titleAccount.ForeColor = ThemeColor.SecondaryColor;
            lnumeLbl.ForeColor = ThemeColor.SecondaryColor;
            prenumeLbl.ForeColor = ThemeColor.SecondaryColor;
            telefonLbl.ForeColor = ThemeColor.SecondaryColor;
        }

        private void frmCont_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verifyParameters())
            {
                updateAccount();
                MessageBox.Show("Actualizarea datelor a fost efectuata cu succes");
                Clear();
            }
        }

        private void Clear()
        {
            txtNume.Text = "";
            txtPrenume.Text = "";
            txtTelefon.Text = "";
        }
        private void updateAccount()
        {
            using (SqlConnection sqlCon = new SqlConnection(conectionString))
            {
                sqlCon.Open();
                string update = "UPDATE tblUser SET Username=@Username, Password=@Password, Nume=@Nume, Prenume=@Prenume, Telefon=@Telefon" +
                    " WHERE Username=@Username";
                using (SqlCommand updateCmd = new SqlCommand(update, sqlCon))
                {
                    updateCmd.Parameters.AddWithValue("@Username", username);
                    updateCmd.Parameters.AddWithValue("@Password", pass);
                    updateCmd.Parameters.AddWithValue("@Nume", txtNume.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text.Trim());
                    updateCmd.ExecuteNonQuery();
                }
            }
        }

        private Boolean verifyParameters()
        {
            if (txtNume.Text.Equals("") || txtPrenume.Text.Equals("") || txtTelefon.Text.Equals(""))
            {
                MessageBox.Show("Toate campurile sunt obligatorii", "Actualizare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (txtTelefon.Text.Length != 10)
            {
                MessageBox.Show("Numarul de telefon trebuie sa fie format din 10 cifre", "Actualizare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void prenumeLbl_Click(object sender, EventArgs e)
        {

        }
    }
}

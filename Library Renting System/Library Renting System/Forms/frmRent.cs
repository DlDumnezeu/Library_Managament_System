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
    public partial class Inchiriere : Form
    {
        private string username;
        private string conectionStringBook = @"(local); Initial Catalog = BookDB; Integrated Security=True;";
        private string conectionStringRent = @"(local); Initial Catalog = RentDB; Integrated Security=True;";
        private string conectionStringUser = @"(local); Initial Catalog = UserRegistrationDB; Integrated Security=True;";

        public Inchiriere(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void LoadTheme()
        {
            foreach (Control btn in this.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            titleRent.ForeColor = ThemeColor.PrimaryColor;
            numeLbl.ForeColor = ThemeColor.SecondaryColor;
            autorlbl.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Equals("") || txtAutor.Text.Equals(""))
            {
                MessageBox.Show("Te rog completeaza toate campurile", "Inchiriere esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!verifyAccount())
            {
                MessageBox.Show("Inainte de a inchiria adaugati datele in sectiunea administrare cont", "Inchiriere esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                Boolean rentExist = false;
                using (SqlConnection sqlCon = new SqlConnection(conectionStringRent))
                {
                    sqlCon.Open();
                    string checkRent = "SELECT * FROM RentTable WHERE Username = '" + username + "' and Carte = '" + txtTitle.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(checkRent, sqlCon))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                rentExist = true;
                            }
                        }
                    }
                }
                if (rentExist)
                {
                    MessageBox.Show("Ai inchiriat deja aceasta carte", "Inchiriere esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean stockBook = false; ;
                    using (SqlConnection sqlCon = new SqlConnection(conectionStringBook))                      
                    {
                        sqlCon.Open();
                        string checkBook = "SELECT * FROM BookTable WHERE Titlu = '" + txtTitle.Text + "' and Autor = '" + txtAutor.Text + "' and Cantitate > 0";
                        using (SqlCommand cmd = new SqlCommand(checkBook, sqlCon))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read() == true)
                                {
                                    stockBook = true;
                                }
                            }
                        }
                        if (stockBook)
                        {
                            string update = "UPDATE BookTable SET Cantitate=Cantitate - " + ((int)numUpDown.Value) + " WHERE Titlu = '" + txtTitle.Text + "' and Autor = '" + txtAutor.Text + "'";
                            using (SqlCommand updateCmd = new SqlCommand(update, sqlCon))
                            {
                                updateCmd.Parameters.AddWithValue("@Titlu", txtTitle.Text.Trim());
                                updateCmd.Parameters.AddWithValue("@Autor", txtAutor.Text.Trim());
                                updateCmd.Parameters.AddWithValue("@Cantitate", ((int)numUpDown.Value));
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    using (SqlConnection sqlCon = new SqlConnection(conectionStringRent))
                    {
                        sqlCon.Open();
                        using (SqlCommand sqlCmd = new SqlCommand("addRent", sqlCon))
                        {
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@Username", username);
                            sqlCmd.Parameters.AddWithValue("@Carte", txtTitle.Text.Trim());
                            sqlCmd.ExecuteNonQuery();
                            MessageBox.Show("Inchiriere completa");
                            Clear();
                            sqlCon.Close();
                        }
                    }
                }
            }
            
        }

        private Boolean verifyAccount()
        {
            Boolean exist = false;
            using (SqlConnection sqlCon = new SqlConnection(conectionStringUser))
            {
                sqlCon.Open();
                string checkUser = "SELECT * FROM tblUser WHERE Username = '" + username + "' and Nume IS NOT NULL";
                using (SqlCommand cmd = new SqlCommand(checkUser, sqlCon))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            exist = true;
                        }
                    }
                }
            }
                return exist;
        }

        private void Clear()
        {
            txtTitle.Text = "";
            txtAutor.Text = "";
            txtTitle.Focus();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Inchiriere_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}

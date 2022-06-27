using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library_Renting_System.Forms
{
    public partial class Donare : Form
    {

        string conectionString = @"Data Source = (local); Initial Catalog = BookDB; Integrated Security=True;";
        public Donare()
        {
            InitializeComponent();
        }

        private void frmDonate_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
            titleAdd.ForeColor = ThemeColor.PrimaryColor;
            titluLbl.ForeColor = ThemeColor.SecondaryColor;
            autorLbl.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if(txtTitle.Text.Equals("") || txtAutor.Text.Equals(""))
            {
                MessageBox.Show("All fields must be filled", "Donation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(numUpDown.Value < 1)
            {
                MessageBox.Show("Enter a positive number of books", "Donation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(conectionString))
                {
                    sqlCon.Open();
                    string exists = "SELECT * FROM BookTable WHERE Titlu = '" + txtTitle.Text + "' and Autor = '" + txtAutor.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(exists, sqlCon))
                    {
                        Boolean ok = true;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                ok = false;
                            }
                        }
                        if (ok)
                        {
                            using (SqlCommand sqlCmd = new SqlCommand("addBook", sqlCon))
                            {
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.Parameters.AddWithValue("@Titlu", txtTitle.Text.Trim());
                                sqlCmd.Parameters.AddWithValue("@Autor", txtAutor.Text.Trim());
                                sqlCmd.Parameters.AddWithValue("@Cantitate", ((int)numUpDown.Value));
                                sqlCmd.ExecuteNonQuery();
                                MessageBox.Show("DONATION COMPLETE");
                                sqlCon.Close();
                                Clear();
                            }
                        }
                        else
                        {
                            string update = "UPDATE BookTable SET Cantitate=Cantitate + " + ((int)numUpDown.Value) + " WHERE Titlu = '" + txtTitle.Text + "' and Autor = '" + txtAutor.Text + "'";
                            using (SqlCommand updateCmd = new SqlCommand(update, sqlCon))
                            {
                                updateCmd.Parameters.AddWithValue("@Titlu", txtTitle.Text.Trim());
                                updateCmd.Parameters.AddWithValue("@Autor", txtAutor.Text.Trim());
                                updateCmd.Parameters.AddWithValue("@Cantitate", ((int)numUpDown.Value));
                                updateCmd.ExecuteNonQuery();
                                MessageBox.Show("DONATION COMPLETE");
                                sqlCon.Close();
                                Clear();
                            }
                        }
                    }
                    
                }
            }
        }

        void Clear()
        {
            txtTitle.Text = "";
            txtAutor.Text = "";
            numUpDown.Value = 0;
            txtTitle.Focus();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void titleAdd_Click(object sender, EventArgs e)
        {

        }

        private void autorLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
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
    public partial class Returnare : Form
    {
        private string username;
        private string conectionStringBook = @"Data Source = DESKTOP-QALE503; Initial Catalog = BookDB; Integrated Security=True;";
        private string conectionStringRent = @"Data Source = DESKTOP-QALE503; Initial Catalog = RentDB; Integrated Security=True;";
        public Returnare( string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void Clear()
        {
            txtTitle.Text = "";
            txtAutor.Text = "";
            txtTitle.Focus();
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
            if (txtTitle.Text.Equals("1") || txtAutor.Text.Equals("1"))
            {
                MessageBox.Show("All fields must be filled", "Return Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (!rentExist)
                {
                    MessageBox.Show("You don't have this book", "Return Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
                else
                {
                    Boolean bookExist = false;
                    using (SqlConnection sqlCon = new SqlConnection(conectionStringBook))
                    {
                        sqlCon.Open();
                        string checkBook = "SELECT * FROM BookTable WHERE Titlu = '" + txtTitle.Text + "' and Autor = '" + txtAutor.Text + "'";
                        using (SqlCommand cmd = new SqlCommand(checkBook, sqlCon))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read() == true)
                                {
                                    bookExist = true;
                                }
                            }
                        }
                        if (!bookExist)
                        {
                            Clear();
                            MessageBox.Show("The Library doesn't have this book yet", "Return Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show("RETURN COMPLETE");
                            }
                        }
                    }
                    if (bookExist)
                    {
                        using (SqlConnection sqlCon = new SqlConnection(conectionStringRent))
                        {
                            sqlCon.Open();
                            string delete = "DELETE FROM RentTable WHERE Username = '" + username + "' and Carte = '" +txtTitle.Text + "'";
                            using (SqlCommand deleteCmd = new SqlCommand(delete, sqlCon))
                            {
                                deleteCmd.ExecuteNonQuery();
                            }
                            sqlCon.Close();
                        }
                        Clear();
                    }
                }

            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            void Clear()
            {
                txtTitle.Text = "";
                txtAutor.Text = "";
                txtTitle.Focus();
            }
        }

        private void Returnare_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void autorlbl_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

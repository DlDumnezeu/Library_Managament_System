using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Library_Renting_System
{
    public partial class frmRegister : Form
    {
        string conectionString = @"Data Source = (local); Initial Catalog = UserRegistrationDB; Integrated Security=True;";

        public frmRegister()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtParola.Text == "" || txtConfirmare.Text == "")
            {
                MessageBox.Show("All fields must be filled", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(txtUsername.Text.Length < 5)
            {
                MessageBox.Show("The username must contain 5 characters", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtParola.Text.Length < 5)
            {
                MessageBox.Show("The password must contain 5 characters", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!txtParola.Text.Equals(txtConfirmare.Text))
            {
                MessageBox.Show("Passwords don't match", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmare.Text = "";
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(conectionString))
                {
                    sqlCon.Open();
                    Boolean exist = false;
                    string check = "SELECT * FROM tblUser WHERE Username = '" + txtUsername.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(check, sqlCon))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                exist = true;
                            }
                        }
                    }
                    if (!exist)
                    {
                        SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", txtParola.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Inregistrare completa");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("This Username is already taken", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            
        }

        void Clear()
        {
            txtUsername.Text = "";
            txtParola.Text = "";
            txtConfirmare.Text = "";
        }

        private void checkBxArataParola_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxArataParola.Checked)
            {
                txtParola.PasswordChar = '\0';
                txtConfirmare.PasswordChar = '\0';
            }
            else
            {
                txtParola.PasswordChar = '*';
                txtConfirmare.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
            txtUsername.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

    }
}
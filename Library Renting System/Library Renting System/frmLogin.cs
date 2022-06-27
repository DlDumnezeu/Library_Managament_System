using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Library_Renting_System
{
    public partial class frmLogin : Form
    {

        string conectionString = @"Data Source = DESKTOP-QALE503; Initial Catalog = UserRegistrationDB; Integrated Security=True;";
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtConfirmare_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conectionString))
            {
                sqlCon.Open();
                string login = "SELECT * FROM tblUser WHERE Username = '" + txtUsername.Text + "' and Password = '" + txtParola.Text + "'";
                SqlCommand cmd = new SqlCommand(login, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read() == true)
                {
                    new dashboard(txtUsername.Text, txtParola.Text).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username Password Combination", "Log In Failed" +
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void Clear()
        {
            txtUsername.Text = "";
            txtParola.Text = "";
            txtUsername.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void checkBxArataParola_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxArataParola.Checked)
            {
                txtParola.PasswordChar = '\0';
            }
            else
            {
                txtParola.PasswordChar = '*';
            }
        }

        private void txtParola_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }
    }
}

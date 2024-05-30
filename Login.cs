using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Connect DB
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBase2.mdb"); 
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
       


        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                PasswordTB.PasswordChar = '\0';
                ConfirmPasswordTB.PasswordChar = '\0';

            }else
            {
                PasswordTB.PasswordChar = '*';
                ConfirmPasswordTB.PasswordChar = '*';
            }
            
        }

        private void ClearBTN_Click(object sender, EventArgs e)
        {
            UsernameTB.Text = string.Empty;
            PasswordTB.Text = string.Empty;
            ConfirmPasswordTB.Text = string.Empty;

        }

        private void BackToLoginBTN_Click(object sender, EventArgs e)
        {
            // button event in your form 1

            //Method 1
           // Form2 f2 = new Form2();
           // f2.ShowDialog();

            //Method 2
            //new Form2().ShowDialog();

            //Method 3
            new Form2().Show();
            this.Hide();

        }

        private void RegisterBTN_Click(object sender, EventArgs e)
        {
            //Validate to deny empty fields
            if (string.IsNullOrWhiteSpace (UsernameTB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Text) || string.IsNullOrWhiteSpace(ConfirmPasswordTB.Text))
            {
                MessageBox.Show("One of the field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } 
            // Check if the password match
            else if (PasswordTB.Text == ConfirmPasswordTB.Text)
            {
                conn.Open();
                String register ="INSERT INTO Table1 VALUES ('" + UsernameTB.Text + "','" + PasswordTB.Text + "')";
                command = new OleDbCommand(register, conn);
                command.ExecuteNonQuery();
                conn.Close();

                //Clear
                UsernameTB.Text = string.Empty;
                PasswordTB.Text = string.Empty;
                ConfirmPasswordTB.Text = string.Empty;

                MessageBox.Show("Registered", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            else
            {

                MessageBox.Show("Password and confirm password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ConfirmPasswordTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

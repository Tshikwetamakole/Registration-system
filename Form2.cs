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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBase2.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                PasswordTB.PasswordChar = '\0';
            }
            else
            {
                PasswordTB.PasswordChar = '*';
            }
        }

        private void RegisterBTN_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
            this.Hide();
        }

        private void ClearBTN_Click(object sender, EventArgs e)
        {
            UsernameTB.Text = string.Empty;
            PasswordTB.Text = string.Empty;
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            conn.Open();
            String Login = "SELECT * FROM Table1 WHERE username = '" + UsernameTB.Text + "' and  password = '" + PasswordTB.Text + "'";
            cmd = new OleDbCommand(Login, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            if (string.IsNullOrWhiteSpace(UsernameTB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Text))
            {
                MessageBox.Show("One of the field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (reader.Read() == true)
            {
                new Form3().ShowDialog();
                this.Hide();
            }else
            {
                MessageBox.Show("You need to register", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UsernameTB.Text = string.Empty;
                PasswordTB.Text = string.Empty;
            }
            conn.Close();
        }
    }
}

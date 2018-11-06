using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DatabaseWarga
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Username(object sender, EventArgs e)
        {

        }

        private void Password(object sender, EventArgs e)
        {

        }


        private void Login_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = WargaDatabase.accdb";

            try
            {
                dbconnection.Open();
                String cmdText = "SELECT count(*)from Account where Username=" + "? and [Password]=" + "?";
                OleDbCommand cmd = new OleDbCommand(cmdText, dbconnection);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                   
                    String Username = textBox1.Text.ToString();
                    String myquery = "INSERT into Log(Username)values('" + Username + "')";
                    OleDbCommand store = new OleDbCommand(myquery, dbconnection);
                    store.ExecuteNonQuery();
                    Hide();
                    Menu MainMenu = new Menu();
                    MainMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                dbconnection.Close();
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Citizen Connection is an application to connect citizen about any news from the city.");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Faizal Muhammad Priyowibowo \n16/395/394/TK/44686 \nfaizalpriyowibowo@gmail.com");
        }
    }
}

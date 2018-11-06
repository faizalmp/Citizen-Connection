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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = WargaDatabase.accdb";
            try
            {
                dbconnection.Open();
                String query = "SELECT * from NewsData ORDER BY ID DESC";
                OleDbCommand cmd = new OleDbCommand(query, dbconnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["NewsTitle"].ToString());
                }
            }
            catch (Exception error)
            {

            }
            finally
            {
                dbconnection.Close();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            WriteNews news = new WriteNews();
            news.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_Profile up = new User_Profile();
            up.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Citizens_Profile cp = new Citizens_Profile();
            cp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = WargaDatabase.accdb";
            try
            {
                dbconnection.Open();
                String query = "SELECT * from NewsData ORDER BY ID DESC";
                OleDbCommand cmd = new OleDbCommand(query, dbconnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    listBox1.Items.Add(reader["NewsTitle"].ToString());
                }
            }
            catch (Exception error)
            {

            }
            finally
            {
                dbconnection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = WargaDatabase.accdb";
            try
            {
                dbconnection.Open();
                String query = "DELETE * from Log";
                OleDbCommand delete = new OleDbCommand(query, dbconnection);
                delete.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Logout failed!" + error.Message);
            }
            finally
            {
                dbconnection.Close();
            }
            Hide();
            Login HomePage = new Login();
            HomePage.ShowDialog();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data source = WargaDatabase.accdb";
            try
            {
                dbconnection.Open();
                String myquery = "INSERT into NewsLog(NewsTitle)values('" + listBox1.SelectedItem.ToString() + "')";
                OleDbCommand store = new OleDbCommand(myquery, dbconnection);
                store.ExecuteNonQuery();
                store.ExecuteNonQuery();
                ShowNews sn = new ShowNews();
                sn.Show();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Write News -> Write any news \nUpdate -> Update News \nProfile -> Your Profile \nCitizenProfiles -> Search citizen profile \nSelect News -> click on the text and see the content \nLogout -> Logout");
        }
    }
}

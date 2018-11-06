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
    public partial class ShowNews : Form
    {
        public ShowNews()
        {
            InitializeComponent();           
        }

        private void ShowNews_Load(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = WargaDatabase.accdb";
            try
            {
                dbconnection.Open();
                String dbquery = "SELECT * from NewsLog";
                OleDbCommand searchdata = new OleDbCommand(dbquery, dbconnection);
                searchdata.CommandType = CommandType.Text;
                OleDbDataReader reader = searchdata.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["NewsTitle"].ToString();
                }
                String query = "SELECT * from NewsData WHERE NewsTitle = '" + textBox1.Text.ToString() + "'";
                OleDbCommand searchdata2 = new OleDbCommand(query, dbconnection);
                searchdata2.CommandType = CommandType.Text;
                OleDbDataReader reader2 = searchdata2.ExecuteReader();
                while (reader2.Read())
                {
                    richTextBox1.Text = reader2["NewsContent"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data source = WargaDatabase.accdb";
            try
            {
                dbconnection.Open();
                String query = "DELETE * from NewsLog";
                OleDbCommand delete = new OleDbCommand(query, dbconnection);
                delete.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                dbconnection.Close();
            }
            Close();
        }
    }
}

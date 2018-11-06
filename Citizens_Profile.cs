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
    public partial class Citizens_Profile : Form
    {
        public Citizens_Profile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = WargaDatabase.accdb";
            try
            {
                dbconnection.Open();
                String dbquery = "SELECT * from Account WHERE Nama = '" + textBox7.Text.ToString() + "'";
                OleDbCommand searchdata2 = new OleDbCommand(dbquery, dbconnection);
                searchdata2.CommandType = CommandType.Text;
                OleDbDataReader reader2 = searchdata2.ExecuteReader();
                while (reader2.Read())
                {
                    byte[] bytes = (byte[])reader2["Picture"];
                    ImageConverter converter = new ImageConverter();
                    pictureBox1.Image = (Image)converter.ConvertFrom(bytes);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    textBox1.Text = reader2["Nama"].ToString();
                    textBox2.Text = reader2["TempatLahir"].ToString();
                    textBox3.Text = reader2["TanggalLahir"].ToString();
                    textBox4.Text = reader2["Pekerjaan"].ToString();
                    textBox5.Text = reader2["Agama"].ToString();
                    textBox6.Text = reader2["Alamat"].ToString();
                    textBox9.Text = reader2["Email"].ToString();
                    textBox10.Text = reader2["NoHP"].ToString();
                    label7.Text = reader2["Gender"].ToString();                   
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

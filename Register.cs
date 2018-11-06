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
using System.IO;
using System.Drawing.Imaging;

namespace DatabaseWarga
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool rb1checked = radioButton1.Checked;
            bool rb2checked = radioButton2.Checked;
            if (textBox1.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox2.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox3.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox4.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox5.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox6.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox7.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox8.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox9.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (textBox10.TextLength == 0) MessageBox.Show("Please complete your registration");
            else if (rb1checked == false && rb2checked == false) MessageBox.Show("Please complete your registration");
            else
            {
                OleDbConnection dbconnection = new OleDbConnection();
                dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source = WargaDatabase.accdb";
                try
                {
                    dbconnection.Open();
                    string Gender = "";
                    bool Checked1 = radioButton1.Checked;
                    bool Checked2 = radioButton2.Checked;
                    if (Checked1)
                    {
                        Gender = radioButton1.Text;
                    }
                    else if(Checked2)
                    {
                        Gender = radioButton2.Text;
                    }
                    String Nama = textBox1.Text.ToString();
                    String TempatLahir = textBox2.Text.ToString();
                    String TanggalLahir = textBox3.Text.ToString();
                    String Pekerjaan = textBox4.Text.ToString();
                    String Agama = textBox5.Text.ToString();
                    String Alamat = textBox6.Text.ToString();
                    String Email = textBox9.Text.ToString();
                    String NoHP = textBox10.Text.ToString();
                    String Username = textBox7.Text.ToString();
                    String Password = textBox8.Text.ToString();

                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Jpeg);
                    byte[] imagebytes = ms.ToArray();
                                             
                    String dbquery = "INSERT into Account (Picture, Nama, TempatLahir, TanggalLahir, Pekerjaan, Agama, Alamat, Gender, Email, NoHP, Username, [Password]) values (@IMG, '" + Nama + "', '" + TempatLahir + "', '" + TanggalLahir + "', '" + Pekerjaan + "', '" + Agama + "', '" + Alamat + "', '" + Gender + "','" + Email + "', '" + NoHP + "', '" + Username + "', '" + Password + "')";
                    OleDbCommand storedata = new OleDbCommand(dbquery, dbconnection);
                    storedata.Parameters.AddWithValue("@IMG", imagebytes);
                    storedata.ExecuteNonQuery();

                    MessageBox.Show("Registration complete!");
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Registration failed!" + error.Message);
                }
                finally
                {
                    dbconnection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

 

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog selectpic = new OpenFileDialog();
            if (selectpic.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(selectpic.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}

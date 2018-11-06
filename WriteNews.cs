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
using System.Net;
using System.Net.Mail;

namespace DatabaseWarga
{
    
    public partial class WriteNews : Form
    {
        
        public WriteNews()
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
                String dbquery = "INSERT into NewsData(NewsTitle, NewsContent) values('"+ textBox1.Text.ToString() + "', '" + richTextBox1.Text.ToString() + "')";
                OleDbCommand storenews = new OleDbCommand(dbquery, dbconnection);
                storenews.ExecuteNonQuery();
                
                MessageBox.Show("Your Post have been Posted");
                Close();

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

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data source = WargaDatabase.accdb";
            try
            {
                dbconnection.Open();
                
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "connectioncitizen@gmail.com";
                string password = "citizenconnection123";
                String query = "SELECT * from Account";
                OleDbCommand send = new OleDbCommand(query, dbconnection);
                OleDbDataReader reader = send.ExecuteReader();
                
                string subject = textBox1.Text.ToString();
                string body = richTextBox1.Text.ToString();

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    while (reader.Read())
                    {
                        string emailTo = reader["Email"].ToString();
                        mail.To.Add(emailTo);
                    }
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
                MessageBox.Show("Message Sent!");
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Browser
{
    
    public partial class Form1 : Form
    {
        public static string conString = "", user = "";
        public Form1()
        {
            InitializeComponent();
            hostName.Text = "DESKITTYTOP";
            dataBaseName.Text = "MEI_TRAB";
            userName.Text = "test";
            userPassword.Text = "testiculo";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void hostName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host_name = hostName.Text, data_base_name = dataBaseName.Text, password = userPassword.Text;
            user = userName.Text;

            conString = "Data Source=" + host_name + "; Initial Catalog = " + data_base_name + "; User ID = " + user + "; Password = " + password;
            SqlConnection DataBaseConnection = new SqlConnection(conString);

            //try to connect né é a vida
            try
            {
                DataBaseConnection.Open();
                MessageBox.Show("Connected!");

                DataBaseConnection.Close();
                Form2 form2 = new Form2();
                form2.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Button clickedButton = (Button)sender;
                clickedButton.Text = " Tentar Conectar Novamente... ";
                clickedButton.Enabled = true;
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logTempo
{
    public partial class Form1 : Form
    {
        public static string Connection = "", user = "";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDB.Text = "MEI_TRAB";
            cboServer.Items.Add(".");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.SelectedIndex = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = user_name.Text;
            Connection = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtDB.Text, user, password.Text);

            SqlConnection Connections = new SqlConnection(Connection);

            try
            {
                Connections.Open();
                MessageBox.Show("Success.......");
                Connections.Close();
                Form2 form2 = new Form2();
                form2.Show();
            }
            catch
            {
                MessageBox.Show("Erro.......");
            }
        }
    }
}

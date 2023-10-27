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

namespace ApplicationLog
{
    public partial class Form3 : Form
    {
        public string numLinhas = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            numLinhas = nLinhas.Text;
            SqlConnection sqlConnection = new SqlConnection(Form1.connectionString);
            string query = "SELECT TOP " + numLinhas + " * FROM LogOperations WHERE EventType = 'I' OR  EventType = 'U' OR  EventType = 'D' ;";

            //dataGrid com o resultado da query
            var sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

        }

        private void nLinhas_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(Form1.connectionString);
            string query = "SELECT * FROM LogOperations WHERE EventType = 'I' OR  EventType = 'U' OR  EventType = 'D' LIMIT ;";

            //dataGrid com o resultado da query
            var sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}


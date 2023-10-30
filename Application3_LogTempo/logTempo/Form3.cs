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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(Form1.Connection);


            string query = @"
                            SELECT LO1.UserId, LO1.Objecto as EncId, DATEDIFF(SS, LO1.Valor, LO2.Valor) as Tempo
                            FROM LogOperations LO1
                            JOIN LogOperations LO2 ON LO1.Referencia = LO2.Referencia
                            WHERE LO1.DCriacao < LO2.DCriacao
                            AND LO1.EventType = 'O'
                            AND LO2.EventType = 'O'
                            ";

            var sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

    }
}

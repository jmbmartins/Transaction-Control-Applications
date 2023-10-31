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
using System.Threading;

namespace Browser
{
    public partial class Form2 : Form
    {
        bool second_table = false;
        string selected_id = "1";
        public Form2()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {

            Updater();

           

        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("");
            //string query2 = "SELECT * FROM EncLinha WHERE EncId = " + DataGridView1.SelectedCells[0].RowIndex.ToString() + " ORDER BY EncId DESC ;"; //query sql
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Worker));
            thread.Start();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            second_table = true;
            int row = DataGridView1.SelectedCells[0].RowIndex;
            selected_id = DataGridView1.Rows[row].Cells[0].Value.ToString();
            Updaterino();
        }

        void Worker()
        {
            try
            {
                // Do some work in the worker thread
                while (true)
                {
                    DataGridView1.Invoke((MethodInvoker)delegate
                    {
                        Updater();
                    });
                    Thread.Sleep(1);
                    if (second_table)
                    {
                        DataGridView2.Invoke((MethodInvoker)delegate
                        {
                            Updaterino();
                        });
                    }
                }
            }
            catch
            {

            }
        }
        public void Updater()
        {
            // importar string con. da base de dados 
            string conString = Form1.conString;
            SqlConnection DataBaseConnection = new SqlConnection(conString);
            DataBaseConnection.Open();

            string query = "SELECT * FROM Encomenda ORDER BY EncID ASC;"; //query sql
                                                                          //    string query2 = "SELECT * FROM EncLinha WHERE EncId = 1 ORDER BY EncId DESC ;"; //query sql

            //dataGrid com o resultado da query
            var sqlDataAdapter = new SqlDataAdapter(query, DataBaseConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            DataGridView1.DataSource = dataTable;
        }
        public void Updaterino()
        {
            string query2 = "SELECT * FROM EncLinha WHERE EncId = " + selected_id + " ORDER BY EncId DESC ;"; //query sql
                                                                                                                                                    //dataGrid2 com o resultado da query2

            string conString = Form1.conString;
            SqlConnection DataBaseConnection = new SqlConnection(conString);
            DataBaseConnection.Open();

            var sqlDataAdapter2 = new SqlDataAdapter(query2, DataBaseConnection);
            var dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            DataGridView2.DataSource = dataTable2;
        }
    }
}

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
        // importar string con. da base de dados 
        static string conString = Form1.conString;
        SqlConnection DataBaseConnection = new SqlConnection(conString);
        System.Data.DataTable old1, old2;
        public Form2()
        {
            InitializeComponent();
            Updater();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
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
            try
            {
                DataBaseConnection.Open();
            }
            catch
            {
                MessageBox.Show("Erro (a BD foi abaixo provavelmente)");
                System.Windows.Forms.Application.ExitThread();
            }
            
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
                    if(checkBox1.Checked)
                    DataGridView1.Invoke((MethodInvoker)delegate
                    {
                        Updater();
                    });
                    int timer = 100;
                    try
                    {
                        timer = int.Parse(textBox1.Text);
                    }
                    catch
                    {

                    }
                    Thread.Sleep(timer);
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
            string query = "SELECT * FROM Encomenda ORDER BY EncID DESC;"; //query sql

            System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, DataBaseConnection);
            System.Data.DataTable dataTable = new DataTable();
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch
            {
                MessageBox.Show("Erro (a BD foi abaixo provavelmente)");
                System.Windows.Forms.Application.ExitThread();
            }
            if (!DataTablesAreEqual(dataTable, old1))
            {
                
                DataGridView1.DataSource = dataTable;
                DataGridView1.AutoResizeColumns();
                old1 = dataTable;
            }
        }
        public void Updaterino()
        {
            string query2 = "SELECT * FROM EncLinha WHERE EncId = " + selected_id + " ORDER BY EncId DESC ;"; //query sql

            string conString = Form1.conString;
            SqlConnection DataBaseConnection = new SqlConnection(conString);
            var sqlDataAdapter2 = new SqlDataAdapter(query2, DataBaseConnection);
            try
            {
                DataBaseConnection.Open();
                System.Data.DataTable dataTable2 = new DataTable();
                sqlDataAdapter2.Fill(dataTable2);
                if (!DataTablesAreEqual(dataTable2, old2))
                {
                    DataGridView2.DataSource = dataTable2;
                    DataGridView2.AutoResizeColumns();
                    old2 = dataTable2;
                }
            }
            catch
            {
                MessageBox.Show("Erro (a BD foi abaixo provavelmente)");
                System.Windows.Forms.Application.ExitThread();
            }

        }


        private bool DataTablesAreEqual(DataTable table1, DataTable table2)
        {
            if (table1 == null || table2 == null)
            {
                return false;
            }
            if (table1.Rows.Count != table2.Rows.Count || table1.Columns.Count != table2.Columns.Count)
            {
                return false;
            }

            for (int i = 0; i < table1.Rows.Count; i++)
            {
                for (int j = 0; j < table1.Columns.Count; j++)
                {
                    if (!object.Equals(table1.Rows[i][j], table2.Rows[i][j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

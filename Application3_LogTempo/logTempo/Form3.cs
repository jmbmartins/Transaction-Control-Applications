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
        String user = Form1.user;
        string form2isolationLevel = Form2.nivel_isolamento;

        public Form3()
        {
            InitializeComponent();
            this.Name = Form1.databaseConnectionString;
            
        }

        private void PopulateDataGrid()
        {
            string connectionString = Form1.databaseConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted; // Default

                switch (form2isolationLevel)
                {
                    case "Read Uncommitted":
                        isolationLevel = IsolationLevel.ReadUncommitted;
                        break;
                    case "Read Committed":
                        isolationLevel = IsolationLevel.ReadCommitted;
                        break;
                    case "Repeatable Read":
                        isolationLevel = IsolationLevel.RepeatableRead;
                        break;
                    case "Serializable":
                        isolationLevel = IsolationLevel.Serializable;
                        break;
                }

                // Display the result of a query on the DataGridView
                DataTable dataTable = new DataTable();

                using (SqlTransaction transaction = connection.BeginTransaction(isolationLevel))
                {
                    try
                    {
                        string query = @"
                        SELECT LO1.UserId, LO1.Objecto as EncId, DATEDIFF(SS, LO1.Valor, LO2.Valor) as Tempo
                        FROM LogOperations LO1
                        JOIN LogOperations LO2 ON LO1.Referencia = LO2.Referencia
                        WHERE LO1.DCriacao <= LO2.DCriacao
                        AND LO1.EventType = 'O'
                        AND LO2.EventType = 'O' ";
                        // Execute your SQL transaction
                        SqlCommand command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandText = query;
                        command.ExecuteNonQuery();

                        // Commit the transaction to save the changes.
                        transaction.Commit();

                        // Perform your query to retrieve results
                        SqlCommand queryCommand = connection.CreateCommand();
                        queryCommand.Transaction = transaction;
                      
                        using (SqlCommand selectCommand = new SqlCommand(query, connection))

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand))
                        {
                            dataAdapter.Fill(dataTable);
                        }

                        // Bind the DataTable to the DataGridView to display the results
                        dataGridView1.DataSource = dataTable;


                    }
                    catch (Exception ex)
                    {
                        // An error occurred, so roll back the transaction.
                        MessageBox.Show("Error: " + ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }
        
        private void RefreshDataGrid()
        {
            int sec_counter = (int)numericUpDown1.Value;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = sec_counter * 1000+1; // Set the Timer's interval
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Update the Timer's interval for subsequent ticks
                int sec_counter = (int)numericUpDown1.Value;
                timer1.Interval = sec_counter * 1000;
                PopulateDataGrid();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
         
            //função para popular a data grid
            PopulateDataGrid();
            //tempo de refesh
            RefreshDataGrid();
            label4.Text = form2isolationLevel;

           
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateDataGrid();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

    }
}

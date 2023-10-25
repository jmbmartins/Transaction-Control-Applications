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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string nivel_isolamento = Form2.nivel_isolamento;

            // Deteção de Erro (Alterar a quantidade sem selecionar o produto e vice-versa)
            if (string.IsNullOrEmpty(txtBoxQtd.Text) && (!(string.IsNullOrEmpty(txtBoxProdutoId.Text)))
                || (!(string.IsNullOrEmpty(txtBoxQtd.Text)) && string.IsNullOrEmpty(txtBoxProdutoId.Text))) {
                
                MessageBox.Show("Selecione o produto e a quatidade que pretende alterar.");
                return;
            }
                

                using (SqlConnection connection = new SqlConnection(FormLogin.connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();


                    switch (nivel_isolamento)
                    {
                        case "Read Uncommitted":

                            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                            break;

                        case "Read Committed":

                            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                            break;

                        case "Repeatable Read":

                            transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);

                            break;

                        case "Snapshot":

                            transaction = connection.BeginTransaction(IsolationLevel.Snapshot);

                            break;

                        case "Serializable":

                            transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                            break;

                    }

                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        // Alterar a Morada da Encomenda
                        string query = "UPDATE Encomenda SET Morada = '" + txtBoxMorada.Text + "' WHERE Encomenda.EncID = " + Form2.IdEnc + " ;";

                        command.CommandText = query;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Alteração da morada foi feita com sucesso");
                        connection.Close();

                    }
                    catch
                    {
                        try
                        {
                            MessageBox.Show("A transação falhou, foi feito um rollback");
                            transaction.Rollback();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Não foi possivél fazer rollback");
                        }
                    }

                    //faz registo na base de dados
                    connection.Open();

                    string user = FormLogin.user;
                    DateTime date_now = DateTime.UtcNow;
                    string User_Reference = "G1-" + date_now.ToString("yyMMddHmmss");
                    string ínsertRegisterQuery = "INSERT INTO LogOperations (EventType, Objecto, Valor, Referencia) Values('O', '" + Form2.IdEnc + "'" + " , " + "'" + date_now + "'" + " , " + "'" + User_Reference + "'" + ")";

                    SqlCommand insertRegister = new SqlCommand(ínsertRegisterQuery, command.Connection);
                    insertRegister.ExecuteNonQuery();

                    connection.Close();


                    //atualizar a balelazinha
                    SqlConnection sqlConnection = new SqlConnection(FormLogin.connectionString);
                    string selectAll = "SELECT * FROM EncLinha FULL JOIN Encomenda ON EncLinha.EncId = Encomenda.EncID WHERE EncLinha.EncId = " + Form2.IdEnc + ";";

                    //dataGrid com o resultado da query
                    var sqlDataAdapter = new SqlDataAdapter(selectAll, sqlConnection);
                    var dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                }
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(FormLogin.connectionString);
            string query = "SELECT * FROM EncLinha FULL JOIN Encomenda ON EncLinha.EncId = Encomenda.EncID WHERE EncLinha.EncId = " + Form2.IdEnc + ";";

            //dataGrid com o resultado da query
            var sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

    }
}

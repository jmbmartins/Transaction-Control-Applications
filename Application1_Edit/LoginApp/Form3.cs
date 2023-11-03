using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        SqlConnection sqlConnection;
        SqlTransaction transaction;
        SqlCommand command;

        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Form3_Load_1 called."); // Add this line for debugging

                string nivel_isolamento = Form2.nivel_isolamento;

                Debug.WriteLine("Connection string: " + FormLogin.connectionString); // Debug the connection string

                // Initialize the sqlConnection here
                sqlConnection = new SqlConnection(FormLogin.connectionString);

                Debug.WriteLine("SqlConnection object created.");

                using (sqlConnection)
                {
                    try
                    {
                        Debug.WriteLine("Attempting to open the connection.");

                        sqlConnection.Open(); // Attempt to open the connection

                        if (sqlConnection.State == ConnectionState.Open)
                        {
                            // Connection was successfully opened
                            Debug.WriteLine("Connection successfully opened.");
                        }
                        else
                        {
                            // Connection is not in the expected open state
                            Debug.WriteLine("Begin Transaction: Connection is not open as expected.");
                            // Handle this situation or display an error message to the user
                        }

                        command = sqlConnection.CreateCommand();

                        switch (nivel_isolamento)
                        {
                            case "Read Uncommitted":

                                transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

                                break;

                            case "Read Committed":

                                transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

                                break;

                            case "Repeatable Read":

                                transaction = sqlConnection.BeginTransaction(IsolationLevel.RepeatableRead);

                                break;

                            case "Snapshot":

                                transaction = sqlConnection.BeginTransaction(IsolationLevel.Snapshot);

                                break;

                            case "Serializable":

                                transaction = sqlConnection.BeginTransaction(IsolationLevel.Serializable);

                                break;
                            default:
                                transaction = sqlConnection.BeginTransaction();
                                break;
                        }

                        command.Connection = sqlConnection;
                        command.Transaction = transaction;
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions that may occur during the connection attempt
                        Debug.WriteLine("Begin Transaction: An error occurred: " + ex.Message);
                        // Optionally, display an error message to the user.
                    }
                }

            }
            catch (SqlException ex)
            {
                // Handle SQL-specific exceptions
                Debug.WriteLine("SQL Exception: " + ex.Message);
                // Optionally, you can display an error message to the user here.
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Debug.WriteLine("An error occurred: " + ex.Message);
                // Optionally, you can display an error message to the user here.
            }

            try
            {
                string query = "SELECT * FROM EncLinha FULL JOIN Encomenda ON EncLinha.EncId = Encomenda.EncID WHERE EncLinha.EncId = " + Form2.IdEnc + ";";
                Debug.WriteLine("SQL Query: " + query);

                if (sqlConnection.ConnectionString != FormLogin.connectionString)
                {
                    // Configurar a cadeia de conexão se necessário
                    sqlConnection.ConnectionString = FormLogin.connectionString;
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                var dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                Debug.WriteLine("SQL Query executed successfully.");
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("SQL Exception: " + ex.Message);
                // Lide com exceções do SQL
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while executing the SQL query: " + ex.Message);
                // Lide com exceções gerais
            }

        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string nivel_isolamento = Form2.nivel_isolamento;

            // Deteção de Erro (Alterar a quantidade sem selecionar o produto e vice-versa)
            if (string.IsNullOrEmpty(txtBoxQtd.Text) && (!(string.IsNullOrEmpty(txtBoxProdutoId.Text)))
                || (!(string.IsNullOrEmpty(txtBoxQtd.Text)) && string.IsNullOrEmpty(txtBoxProdutoId.Text)))
            {

                MessageBox.Show("Selecione o produto e a quatidade que pretende alterar.");
                return;
            }

            int produtoId = -1;
            int quantidade = -1;


            // Verificação todos os campos vazios
            bool moradaEditada = !string.IsNullOrEmpty(txtBoxMorada.Text);
            bool produtoEditado = !string.IsNullOrEmpty(txtBoxQtd.Text);

            if (produtoEditado)
            {
                // Verificar se o campo txtBoxIdProduto é válido
                if (!int.TryParse(txtBoxProdutoId.Text, out produtoId))
                {
                    MessageBox.Show("ID do produto inválido.");
                    return;
                }

                // Verificar se o campo txtBoxQtd é válido
                if (!int.TryParse(txtBoxQtd.Text, out quantidade))
                {
                    MessageBox.Show("Quantidade inválida.");
                    return;
                }
            }

            // Verificar as condições especificadas
            if (moradaEditada && produtoEditado)
            {
                AtualizarMoradaEQuantidade(txtBoxMorada.Text, produtoId, quantidade, sqlConnection, transaction, command);
            }
            else if (moradaEditada)
            {
                AtualizarMorada(txtBoxMorada.Text, sqlConnection, transaction, command);
            }
            else if (produtoEditado)
            {
                AtualizarQuantidade(produtoId, quantidade, sqlConnection, transaction, command);
            }
            else
            {
                MessageBox.Show("Indique o que pretende alterar!");
            }
        }

        private void AtualizarQuantidade(int produtoId, int quantidade, SqlConnection connection, SqlTransaction transaction, SqlCommand command)
        {
            try
            {
                // Alterar a Quantidade
                // Executa a consulta SQL para atualizar a quantidade na tabela EncLinha
                string query = "UPDATE EncLinha SET Qtd = " + quantidade + " WHERE EncId = " + Form2.IdEnc + " AND ProdutoId = " + produtoId + ";";
                command.CommandText = query;
                command.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Alteração da quantidade foi feita com sucesso");
                connection.Close();

            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("A transação de mudança de quantidade falhou, foi feito um rollback");
                    Debug.WriteLine("Erro ao atualizar a quantidade: " + ex.Message);
                    transaction.Rollback();
                    connection.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possivél fazer rollback na transação de mudança de quantidade");
                    connection.Close();
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

            //Atualizar a datagrid
            SqlConnection sqlConnection = new SqlConnection(FormLogin.connectionString);
            string selectAll = "SELECT * FROM EncLinha FULL JOIN Encomenda ON EncLinha.EncId = Encomenda.EncID WHERE EncLinha.EncId = " + Form2.IdEnc + ";";

            //dataGrid com o resultado da query
            var sqlDataAdapter = new SqlDataAdapter(selectAll, sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();

        }

        private void AtualizarMorada(string morada, SqlConnection connection, SqlTransaction transaction, SqlCommand command)
        {
            try
            {
                // Alterar a Morada da Encomenda
                string query = "UPDATE Encomenda SET Morada = '" + morada + "' WHERE Encomenda.EncID = " + Form2.IdEnc + " ;";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open(); // Abra a conexão se não estiver aberta
                }

                command.CommandText = query;
                command.ExecuteNonQuery();

                // Se a transação ainda está ativa, execute o commit
                if (transaction.Connection != null && transaction.Connection.State == ConnectionState.Open)
                {
                    transaction.Commit();
                    MessageBox.Show("Alteração da morada foi feita com sucesso");
                }
            }
            catch
            {
                try
                {
                    // Tratar erro de commit
                    MessageBox.Show("Erro ao confirmar a transação da alteração da morada");
                }
                finally
                {
                    if (transaction.Connection != null && transaction.Connection.State == ConnectionState.Open)
                    {
                        transaction.Rollback();
                        MessageBox.Show("A transação da alteração da morada falhou e foi feito um rollback");
                    }
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close(); // Certifique-se de fechar a conexão após o uso
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


            //Atualizar datagrid
            SqlConnection sqlConnection = new SqlConnection(FormLogin.connectionString);
            string selectAll = "SELECT * FROM EncLinha FULL JOIN Encomenda ON EncLinha.EncId = Encomenda.EncID WHERE EncLinha.EncId = " + Form2.IdEnc + ";";

            //dataGrid com o resultado da query
            var sqlDataAdapter = new SqlDataAdapter(selectAll, sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }


        private void AtualizarMoradaEQuantidade(string morada, int produtoId, int quantidade, SqlConnection connection, SqlTransaction transaction, SqlCommand command)
        {
            Debug.WriteLine("Op Alterar Quantidade / Morada : Morada: " + morada + "ProdutoID: " + produtoId + " Qtd: " + quantidade);
            try
            {
                // Executa a consulta SQL para atualizar a morada na tabela Encomenda
                string queryMorada = "UPDATE Encomenda SET Morada = @Morada WHERE EncId = @EncId";
                SqlCommand commandMorada = new SqlCommand(queryMorada, connection, transaction);
                commandMorada.Parameters.AddWithValue("@Morada", morada);
                commandMorada.Parameters.AddWithValue("@EncId", Form2.IdEnc);
                commandMorada.ExecuteNonQuery();


                // Alterar a Quantidade
                // Executa a consulta SQL para atualizar a quantidade na tabela EncLinha
                string query = "UPDATE EncLinha SET Qtd = " + quantidade + " WHERE EncId = " + Form2.IdEnc + " AND ProdutoId = " + produtoId + ";";
                command.CommandText = query;
                command.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Alteração da quantidade foi feita com sucesso");
                connection.Close();

            }
            catch
            {
                try
                {
                    MessageBox.Show("A transação da alteração da morada e da quantidade falhou, foi feito um rollback");
                    transaction.Rollback();
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possivél fazer rollback na transação da alteração da morada e da quantidade ");
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


            //Atualizar datagrid
            SqlConnection sqlConnection = new SqlConnection(FormLogin.connectionString);
            string selectAll = "SELECT * FROM EncLinha FULL JOIN Encomenda ON EncLinha.EncId = Encomenda.EncID WHERE EncLinha.EncId = " + Form2.IdEnc + ";";

            //dataGrid com o resultado da query
            var sqlDataAdapter = new SqlDataAdapter(selectAll, sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rollback in transaction.");
            transaction.Rollback();
            Application.ExitThread();
        }
    }
}
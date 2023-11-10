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
        IsolationLevel isolationLevel;

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
                        switch (nivel_isolamento)
                        {
                            case "Read Uncommitted":
                                isolationLevel = IsolationLevel.ReadUncommitted;
                                transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

                                break;

                            case "Read Committed":
                                isolationLevel = IsolationLevel.ReadCommitted;
                                break;

                            case "Repeatable Read":

                                break;

                            case "Serializable":
                                isolationLevel = IsolationLevel.Serializable;
                                isolationLevel = IsolationLevel.ReadUncommitted;
                            default:
                                transaction = sqlConnection.BeginTransaction();
                                break;
                        Debug.WriteLine("Attempting to open the connection.");

                        sqlConnection.Open(); // Attempt to open the connection

                        if (sqlConnection.State == ConnectionState.Open)
                        {
                            // Connection was successfully opened
                            Debug.WriteLine("Connection successfully opened.");

                            using (transaction = sqlConnection.BeginTransaction(isolationLevel))
                            {
                                try
                                {
                                    command = sqlConnection.CreateCommand();
                                    command.Connection = sqlConnection;
                                    command.Transaction = transaction;

                                    string query = "SELECT * FROM EncLinha FULL JOIN Encomenda ON EncLinha.EncId = Encomenda.EncID WHERE EncLinha.EncId = @IdEnc;";
                                    command.CommandText = query;
                                    command.Parameters.AddWithValue("@IdEnc", Form2.IdEnc); // Assuming Form2.IdEnc is an integer

                                    Debug.WriteLine("SQL Query: " + query);

                                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                                    sqlDataAdapter.SelectCommand = command;

                                    var dataTable = new DataTable();
                                    sqlDataAdapter.Fill(dataTable);
                                    dataGridView1.DataSource = dataTable;

                                    Debug.WriteLine("SQL Query executed successfully.");

                                    transaction.Commit(); // Commit the transaction after successful execution
                                }
                                catch (SqlException ex)
                                {
                                    Debug.WriteLine("SQL Exception: " + ex.Message);
                                    // Handle SQL exceptions
                                    transaction.Rollback(); // Rollback the transaction in case of SQL exceptions
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("An error occurred while executing the SQL query: " + ex.Message);
                                    // Handle general exceptions
                                    transaction.Rollback(); // Rollback the transaction in case of general exceptions
                                }
                            }
                        }
                        else
                        {
                            // Connection is not in the expected open state
                            Debug.WriteLine("Connection is not open as expected.");
                            // Handle this situation or display an error message to the user
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions that may occur during the connection attempt
                        Debug.WriteLine("An error occurred: " + ex.Message);
                        // Optionally, display an error message to the user.
                    }

                    // Configurar a cadeia de conexão se necessário
                    sqlConnection.ConnectionString = FormLogin.connectionString;
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
                AtualizarMoradaEQuantidade(txtBoxMorada.Text, produtoId, quantidade);
            }
            else if (moradaEditada)
            {
                AtualizarMorada(txtBoxMorada.Text);
            }
            else if (produtoEditado)
            {
                AtualizarQuantidade(produtoId, quantidade);
            }
            else
            {
                MessageBox.Show("Indique o que pretende alterar!");
            }
        }

        private void AtualizarQuantidade(int produtoId, int quantidade)
        {
            using (SqlConnection connection = new SqlConnection(FormLogin.connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open(); // Open the connection

                        transaction = connection.BeginTransaction(isolationLevel);
                        command.Transaction = transaction;

                        // Execute the SQL query to update the quantity in the EncLinha table
                        string query = "UPDATE EncLinha SET Qtd = @quantidade WHERE EncId = @encId AND ProdutoId = @produtoId";

                        command.CommandText = query;
                        command.Parameters.AddWithValue("@quantidade", quantidade);
                        command.Parameters.AddWithValue("@encId", Form2.IdEnc);
                        command.Parameters.AddWithValue("@produtoId", produtoId);

                        command.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Alteração da quantidade foi feita com sucesso");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            MessageBox.Show("Erro ao confirmar a transação da alteração da quantidade: " + ex.Message);
                            Debug.Write("Erro ao confirmar a transação da alteração da quantidade: " + ex.Message);
                            transaction?.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            // Handle rollback exception if needed
                            Debug.Write("Rollback Exception: " + rollbackEx.Message);
                        }
                    }
                    finally
                    {
                        connection.Close(); // Close the connection
                    }
                }
                //faz registo na base de dados
                connection.Open();
                string user = FormLogin.user;
                DateTime date_now = DateTime.UtcNow;
                string User_Reference = "G1-" + date_now.ToString("yyMMddHmmss");
                string ínsertRegisterQuery = "INSERT INTO LogOperations (EventType, Objecto, Valor, Referencia) Values('O', '" + Form2.IdEnc + "'" + " , " + "'" + date_now + "'" + " , " + "'" + User_Reference + "'" + ")";

                SqlCommand insertRegister = new SqlCommand(ínsertRegisterQuery, connection);
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
        }

        private void AtualizarMorada(string morada)
        {
            using (SqlConnection connection = new SqlConnection(FormLogin.connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open(); // Open the connection

                        transaction = connection.BeginTransaction(isolationLevel);
                        command.Transaction = transaction;

                        // Alterar a Morada da Encomenda
                        string query = "UPDATE Encomenda SET Morada = @morada WHERE Encomenda.EncID = @encId";
                        command.CommandText = query;
                        command.Parameters.AddWithValue("@morada", morada);
                        command.Parameters.AddWithValue("@encId", Form2.IdEnc);

                        command.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Alteração da morada foi feita com sucesso");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            MessageBox.Show("Erro ao confirmar a transação da alteração da morada: " + ex.Message);
                            Debug.Write("Erro ao confirmar a transação da alteração da morada: " + ex.Message);
                            transaction?.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            // Handle rollback exception if needed
                            Debug.Write("Rollback Exception: " + rollbackEx.Message);
                        }
                    }
                    finally
                    {
                        connection.Close(); // Close the connection
                    }

                    //faz registo na base de dados
                    connection.Open();

                    string user = FormLogin.user;
                    DateTime date_now = DateTime.UtcNow;
                    string User_Reference = "G1-" + date_now.ToString("yyMMddHmmss");
                    string ínsertRegisterQuery = "INSERT INTO LogOperations (EventType, Objecto, Valor, Referencia) Values('O', '" + Form2.IdEnc + "'" + " , " + "'" + date_now + "'" + " , " + "'" + User_Reference + "'" + ")";

                    SqlCommand insertRegister = new SqlCommand(ínsertRegisterQuery, connection);
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
            }
        }

        private void AtualizarMoradaEQuantidade(string morada, int produtoId, int quantidade)
        {
            using (SqlConnection connection = new SqlConnection(FormLogin.connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open(); // Open the connection

                        transaction = connection.BeginTransaction(isolationLevel);
                        command.Transaction = transaction;

                        // Alterar a Morada da Encomenda
                        string queryM = "UPDATE Encomenda SET Morada = @morada WHERE Encomenda.EncID = @encId";
                        command.CommandText = queryM;
                        command.Parameters.AddWithValue("@morada", morada);
                        command.Parameters.AddWithValue("@encId", Form2.IdEnc);

                        command.ExecuteNonQuery();

                        // Clear parameters before using the same command for a different query
                        command.Parameters.Clear();

                        // Execute the SQL query to update the quantity in the EncLinha table
                        string queryQ = "UPDATE EncLinha SET Qtd = @quantidade WHERE EncId = @encId AND ProdutoId = @produtoId";

                        command.CommandText = queryQ;
                        command.Parameters.AddWithValue("@quantidade", quantidade);
                        command.Parameters.AddWithValue("@encId", Form2.IdEnc);
                        command.Parameters.AddWithValue("@produtoId", produtoId);

                        command.ExecuteNonQuery();



                        transaction.Commit();
                        MessageBox.Show("Alteração da morada e da quantidade foi feita com sucesso");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            MessageBox.Show("Erro ao confirmar a transação da alteração da morada e quantidade: " + ex.Message);
                            Debug.Write("Erro ao confirmar a transação da alteração da morada e quantidade: " + ex.Message);
                            transaction?.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            // Handle rollback exception if needed
                            Debug.Write("Rollback Exception: " + rollbackEx.Message);
                        }
                    }
                    finally
                    {
                        connection.Close(); // Close the connection
                    }

                    //faz registo na base de dados
                    connection.Open();

                    string user = FormLogin.user;
                    DateTime date_now = DateTime.UtcNow;
                    string User_Reference = "G1-" + date_now.ToString("yyMMddHmmss");
                    string ínsertRegisterQuery = "INSERT INTO LogOperations (EventType, Objecto, Valor, Referencia) Values('O', '" + Form2.IdEnc + "'" + " , " + "'" + date_now + "'" + " , " + "'" + User_Reference + "'" + ")";

                    SqlCommand insertRegister = new SqlCommand(ínsertRegisterQuery, connection);
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
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            RollbackAndCloseForm();
        }

        private void RollbackAndCloseForm()
        {
            try
            {
                // Faça o rollback da transação, se estiver ativa
                if (transaction != null)
                {
                    if (transaction.Connection != null)
                    {
                        if (transaction.Connection.State == ConnectionState.Open)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Lide com qualquer exceção que ocorra durante o rollback, se necessário
                MessageBox.Show("Erro durante o rollback: " + ex.Message);
            }
            finally
            {
                // Certifique-se de que a conexão está fechada
                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                }

                // Feche o formulário
                this.Close();
            }
        }

    }
}
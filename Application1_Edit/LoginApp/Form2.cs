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
using System.Windows.Forms.VisualStyles;

namespace LoginApp
{
    public partial class Form2 : Form
    {
        public static string nivel_isolamento = "";
        public static string IdEnc = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void labelProductId_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DomainUpDown.DomainUpDownItemCollection collection = this.domainIsolLevl.Items;
            collection.Add("Read Uncommitted");
            collection.Add("Read Committed");
            collection.Add("Repeatable Read");
            collection.Add("Snapshot");
            collection.Add("Serializable");

            this.domainIsolLevl.Text = "Read Uncomitted";
        }

        private void btnAcessEnc_Click(object sender, EventArgs e)
        {
            IdEnc = txtBox.Text;

            // Registo do Acesso à Encomenda Pretendida
            using (SqlConnection connection = new SqlConnection(FormLogin.connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;

                string user = FormLogin.user;

                DateTime date_now = DateTime.UtcNow;
                string User_Reference = "G1-" + date_now.ToString("yyMMddHmmss");

                string logReguisterQuery = "INSERT INTO LogOperations (EventType, Objecto, Valor, Referencia) Values('O', '" + IdEnc + "'" + " , " + "'" + date_now + "'" + " , " + "'" + User_Reference + "'" + ")";
                command.CommandText = logReguisterQuery;
                command.ExecuteNonQuery();

                connection.Close();
            }


            nivel_isolamento = domainIsolLevl.Text;
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}

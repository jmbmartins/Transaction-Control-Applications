using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{

    public partial class FormLogin : Form
    {

        public static string connectionString = "", user = "";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            user = txtUsername.Text;
            connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtDB.Text, txtUsername.Text, txtPassword.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 form2 = new Form2();
                form2.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtDB.Text = "MEI_TRAB";
            cboServer.Items.Add(".");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.SelectedIndex = 3;

        }
    }
}
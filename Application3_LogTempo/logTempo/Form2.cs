using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logTempo
{
    public partial class Form2 : Form
    {
        public static string nivel_isolamento = "";
        public Form2()
        {
            InitializeComponent();
        }

     
        private void domainIsolLevl_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void btnAcessEnc_Click_1(object sender, EventArgs e)
        {
            nivel_isolamento = domainIsolLevl.Text;

            Form3 form3 = new Form3();
            form3.Show();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            DomainUpDown.DomainUpDownItemCollection collection = this.domainIsolLevl.Items;
            collection.Add("Read Uncommitted");
            collection.Add("Read Committed");
            collection.Add("Repeatable Read");
            collection.Add("Snapshot");
            collection.Add("Serializable");

            this.domainIsolLevl.Text = "Read Uncomitted";
        }
    }
}

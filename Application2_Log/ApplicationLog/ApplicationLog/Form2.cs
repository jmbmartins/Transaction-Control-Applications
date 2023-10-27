using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationLog
{
    public partial class Form2 : Form
    {
        public static string nivel_isolamento = "";
        public Form2()
        {
            InitializeComponent();
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
            nivel_isolamento = domainIsolLevl.Text;

            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}

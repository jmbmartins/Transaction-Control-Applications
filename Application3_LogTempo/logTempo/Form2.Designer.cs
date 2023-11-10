using System.Drawing;
using System.Windows.Forms;

namespace logTempo
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelIsolation = new System.Windows.Forms.Label();
            this.domainIsolLevl = new System.Windows.Forms.DomainUpDown();
            this.btnAcessEnc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIsolation
            // 
            this.labelIsolation.AutoSize = true;
            this.labelIsolation.Location = new System.Drawing.Point(10, 25);
            this.labelIsolation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIsolation.Name = "labelIsolation";
            this.labelIsolation.Size = new System.Drawing.Size(92, 13);
            this.labelIsolation.TabIndex = 1;
            this.labelIsolation.Text = "Nivel de Isolação:";
            // 
            // domainIsolLevl
            // 
            this.domainIsolLevl.Location = new System.Drawing.Point(118, 21);
            this.domainIsolLevl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainIsolLevl.Name = "domainIsolLevl";
            this.domainIsolLevl.Size = new System.Drawing.Size(127, 20);
            this.domainIsolLevl.TabIndex = 2;
            this.domainIsolLevl.Text = "Select Isolation Level";
            this.domainIsolLevl.SelectedItemChanged += new System.EventHandler(this.domainIsolLevl_SelectedItemChanged);
            // 
            // btnAcessEnc
            // 
            this.btnAcessEnc.Location = new System.Drawing.Point(271, 22);
            this.btnAcessEnc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAcessEnc.Name = "btnAcessEnc";
            this.btnAcessEnc.Size = new System.Drawing.Size(70, 19);
            this.btnAcessEnc.TabIndex = 4;
            this.btnAcessEnc.Text = "Aceder";
            this.btnAcessEnc.UseVisualStyleBackColor = true;
            this.btnAcessEnc.Click += new System.EventHandler(this.btnAcessEnc_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 52);
            this.Controls.Add(this.btnAcessEnc);
            this.Controls.Add(this.domainIsolLevl);
            this.Controls.Add(this.labelIsolation);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelIsolation;
        private DomainUpDown domainIsolLevl;
        private Button btnAcessEnc;
    }
}
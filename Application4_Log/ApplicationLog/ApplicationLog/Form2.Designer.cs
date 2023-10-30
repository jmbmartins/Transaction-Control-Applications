namespace ApplicationLog
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
            labelIsolation = new Label();
            domainIsolLevl = new DomainUpDown();
            btnAcessEnc = new Button();
            SuspendLayout();
            // 
            // labelIsolation
            // 
            labelIsolation.AutoSize = true;
            labelIsolation.Location = new Point(133, 79);
            labelIsolation.Name = "labelIsolation";
            labelIsolation.Size = new Size(99, 15);
            labelIsolation.TabIndex = 1;
            labelIsolation.Text = "Nivel de Isolação:";
            // 
            // domainIsolLevl
            // 
            domainIsolLevl.Location = new Point(253, 79);
            domainIsolLevl.Margin = new Padding(3, 2, 3, 2);
            domainIsolLevl.Name = "domainIsolLevl";
            domainIsolLevl.Size = new Size(148, 23);
            domainIsolLevl.TabIndex = 2;
            domainIsolLevl.Text = "Select Isolation Level";
            // 
            // btnAcessEnc
            // 
            btnAcessEnc.Location = new Point(192, 164);
            btnAcessEnc.Margin = new Padding(3, 2, 3, 2);
            btnAcessEnc.Name = "btnAcessEnc";
            btnAcessEnc.Size = new Size(82, 22);
            btnAcessEnc.TabIndex = 4;
            btnAcessEnc.Text = "Aceder";
            btnAcessEnc.UseVisualStyleBackColor = true;
            btnAcessEnc.Click += btnAcessEnc_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 291);
            Controls.Add(btnAcessEnc);
            Controls.Add(domainIsolLevl);
            Controls.Add(labelIsolation);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelIsolation;
        private DomainUpDown domainIsolLevl;
        private Button btnAcessEnc;
    }
}
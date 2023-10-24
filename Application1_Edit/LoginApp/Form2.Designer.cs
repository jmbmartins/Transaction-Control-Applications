namespace LoginApp
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
            labelProductId = new Label();
            labelIsolation = new Label();
            domainIsolLevl = new DomainUpDown();
            txtBox = new TextBox();
            btnAcessEnc = new Button();
            SuspendLayout();
            // 
            // labelProductId
            // 
            labelProductId.AutoSize = true;
            labelProductId.Location = new Point(177, 104);
            labelProductId.Name = "labelProductId";
            labelProductId.Size = new Size(106, 20);
            labelProductId.TabIndex = 0;
            labelProductId.Text = "ID Encomenda";
            labelProductId.Click += labelProductId_Click;
            // 
            // labelIsolation
            // 
            labelIsolation.AutoSize = true;
            labelIsolation.Location = new Point(170, 204);
            labelIsolation.Name = "labelIsolation";
            labelIsolation.Size = new Size(126, 20);
            labelIsolation.TabIndex = 1;
            labelIsolation.Text = "Nivel de Isolação:";
            // 
            // domainIsolLevl
            // 
            domainIsolLevl.Location = new Point(327, 197);
            domainIsolLevl.Name = "domainIsolLevl";
            domainIsolLevl.Size = new Size(169, 27);
            domainIsolLevl.TabIndex = 2;
            domainIsolLevl.Text = "Select Isolation Level";
            // 
            // txtBox
            // 
            txtBox.Location = new Point(327, 101);
            txtBox.Name = "txtBox";
            txtBox.Size = new Size(125, 27);
            txtBox.TabIndex = 3;
            // 
            // btnAcessEnc
            // 
            btnAcessEnc.Location = new Point(358, 322);
            btnAcessEnc.Name = "btnAcessEnc";
            btnAcessEnc.Size = new Size(94, 29);
            btnAcessEnc.TabIndex = 4;
            btnAcessEnc.Text = "Aceder";
            btnAcessEnc.UseVisualStyleBackColor = true;
            btnAcessEnc.Click += btnAcessEnc_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAcessEnc);
            Controls.Add(txtBox);
            Controls.Add(domainIsolLevl);
            Controls.Add(labelIsolation);
            Controls.Add(labelProductId);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelProductId;
        private Label labelIsolation;
        private DomainUpDown domainIsolLevl;
        private TextBox txtBox;
        private Button btnAcessEnc;
    }
}
namespace LoginApp
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOk = new Button();
            btnCancel = new Button();
            labelHostName = new Label();
            labelDB = new Label();
            labelUser = new Label();
            labelPW = new Label();
            txtDB = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            cboServer = new ComboBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(195, 327);
            btnOk.Margin = new Padding(3, 4, 3, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(114, 31);
            btnOk.TabIndex = 0;
            btnOk.Tag = "";
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(358, 327);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 31);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // labelHostName
            // 
            labelHostName.AutoSize = true;
            labelHostName.Location = new Point(203, 69);
            labelHostName.Name = "labelHostName";
            labelHostName.Size = new Size(87, 20);
            labelHostName.TabIndex = 2;
            labelHostName.Text = "Host Name:";
            // 
            // labelDB
            // 
            labelDB.AutoSize = true;
            labelDB.Location = new Point(203, 119);
            labelDB.Name = "labelDB";
            labelDB.Size = new Size(119, 20);
            labelDB.TabIndex = 3;
            labelDB.Text = "Database Name:";
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(203, 168);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(82, 20);
            labelUser.TabIndex = 4;
            labelUser.Text = "User Name";
            // 
            // labelPW
            // 
            labelPW.AutoSize = true;
            labelPW.Location = new Point(203, 219);
            labelPW.Name = "labelPW";
            labelPW.Size = new Size(70, 20);
            labelPW.TabIndex = 5;
            labelPW.Text = "Password";
            // 
            // txtDB
            // 
            txtDB.Location = new Point(317, 115);
            txtDB.Margin = new Padding(3, 4, 3, 4);
            txtDB.Name = "txtDB";
            txtDB.Size = new Size(173, 27);
            txtDB.TabIndex = 7;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(317, 168);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(89, 27);
            txtUsername.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(317, 219);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(173, 27);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // cboServer
            // 
            cboServer.FormattingEnabled = true;
            cboServer.Location = new Point(317, 65);
            cboServer.Margin = new Padding(3, 4, 3, 4);
            cboServer.Name = "cboServer";
            cboServer.Size = new Size(173, 28);
            cboServer.TabIndex = 10;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 412);
            Controls.Add(cboServer);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtDB);
            Controls.Add(labelPW);
            Controls.Add(labelUser);
            Controls.Add(labelDB);
            Controls.Add(labelHostName);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLogin";
            Text = "Login...";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Button btnCancel;
        private Label labelHostName;
        private Label labelDB;
        private Label labelUser;
        private Label labelPW;
        private TextBox txtDB;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cboServer;
    }
}
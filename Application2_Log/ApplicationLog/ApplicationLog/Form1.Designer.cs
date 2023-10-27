namespace ApplicationLog
{
    partial class Form1
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
            btnOk.Location = new Point(171, 245);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 23);
            btnOk.TabIndex = 0;
            btnOk.Tag = "";
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(313, 245);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // labelHostName
            // 
            labelHostName.AutoSize = true;
            labelHostName.Location = new Point(178, 52);
            labelHostName.Name = "labelHostName";
            labelHostName.Size = new Size(70, 15);
            labelHostName.TabIndex = 2;
            labelHostName.Text = "Host Name:";
            // 
            // labelDB
            // 
            labelDB.AutoSize = true;
            labelDB.Location = new Point(178, 89);
            labelDB.Name = "labelDB";
            labelDB.Size = new Size(93, 15);
            labelDB.TabIndex = 3;
            labelDB.Text = "Database Name:";
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(178, 126);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(65, 15);
            labelUser.TabIndex = 4;
            labelUser.Text = "User Name";
            // 
            // labelPW
            // 
            labelPW.AutoSize = true;
            labelPW.Location = new Point(178, 164);
            labelPW.Name = "labelPW";
            labelPW.Size = new Size(57, 15);
            labelPW.TabIndex = 5;
            labelPW.Text = "Password";
            // 
            // txtDB
            // 
            txtDB.Location = new Point(277, 86);
            txtDB.Name = "txtDB";
            txtDB.Size = new Size(152, 23);
            txtDB.TabIndex = 7;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(277, 126);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(78, 23);
            txtUsername.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(277, 164);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(152, 23);
            txtPassword.TabIndex = 9;
            // 
            // cboServer
            // 
            cboServer.FormattingEnabled = true;
            cboServer.Location = new Point(277, 49);
            cboServer.Name = "cboServer";
            cboServer.Size = new Size(152, 23);
            cboServer.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 309);
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
            Name = "Form1";
            Text = "Login...";
            Load += Form1_Load;
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
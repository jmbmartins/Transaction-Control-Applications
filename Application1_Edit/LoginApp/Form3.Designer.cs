namespace LoginApp
{
    partial class Form3
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
            labelMorada = new Label();
            labelQuantidade = new Label();
            txtBoxMorada = new TextBox();
            txtBoxQtd = new TextBox();
            dataGridView1 = new DataGridView();
            btnAlterMorada = new Button();
            btnAlterQtd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelMorada
            // 
            labelMorada.AutoSize = true;
            labelMorada.Location = new Point(66, 33);
            labelMorada.Name = "labelMorada";
            labelMorada.Size = new Size(64, 20);
            labelMorada.TabIndex = 0;
            labelMorada.Text = "Morada:";
            // 
            // labelQuantidade
            // 
            labelQuantidade.AutoSize = true;
            labelQuantidade.Location = new Point(66, 87);
            labelQuantidade.Name = "labelQuantidade";
            labelQuantidade.Size = new Size(90, 20);
            labelQuantidade.TabIndex = 1;
            labelQuantidade.Text = "Quantidade:";
            // 
            // txtBoxMorada
            // 
            txtBoxMorada.Location = new Point(185, 30);
            txtBoxMorada.Name = "txtBoxMorada";
            txtBoxMorada.Size = new Size(100, 27);
            txtBoxMorada.TabIndex = 7;
            // 
            // txtBoxQtd
            // 
            txtBoxQtd.Location = new Point(185, 80);
            txtBoxQtd.Name = "txtBoxQtd";
            txtBoxQtd.Size = new Size(213, 27);
            txtBoxQtd.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 135);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1253, 380);
            dataGridView1.TabIndex = 4;
            // 
            // btnAlterMorada
            // 
            btnAlterMorada.Location = new Point(626, 30);
            btnAlterMorada.Name = "btnAlterMorada";
            btnAlterMorada.Size = new Size(94, 29);
            btnAlterMorada.TabIndex = 5;
            btnAlterMorada.Text = "Submeter";
            btnAlterMorada.UseVisualStyleBackColor = true;
            btnAlterMorada.Click += btnAlterMorada_Click_1;
            // 
            // btnAlterQtd
            // 
            btnAlterQtd.Location = new Point(626, 78);
            btnAlterQtd.Name = "btnAlterQtd";
            btnAlterQtd.Size = new Size(94, 29);
            btnAlterQtd.TabIndex = 6;
            btnAlterQtd.Text = "Submeter";
            btnAlterQtd.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 517);
            Controls.Add(btnAlterQtd);
            Controls.Add(btnAlterMorada);
            Controls.Add(dataGridView1);
            Controls.Add(txtBoxQtd);
            Controls.Add(txtBoxMorada);
            Controls.Add(labelQuantidade);
            Controls.Add(labelMorada);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMorada;
        private Label labelQuantidade;
        private TextBox txtBoxMorada;
        private TextBox txtBoxQtd;
        private DataGridView dataGridView1;
        private Button btnAlterMorada;
        private Button btnAlterQtd;
    }
}
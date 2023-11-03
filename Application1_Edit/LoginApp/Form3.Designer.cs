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
            btnSubmit = new Button();
            labelProduto = new Label();
            txtBoxProdutoId = new TextBox();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelMorada
            // 
            labelMorada.AutoSize = true;
            labelMorada.Location = new Point(10, 25);
            labelMorada.Name = "labelMorada";
            labelMorada.Size = new Size(51, 15);
            labelMorada.TabIndex = 0;
            labelMorada.Text = "Morada:";
            // 
            // labelQuantidade
            // 
            labelQuantidade.AutoSize = true;
            labelQuantidade.Location = new Point(590, 59);
            labelQuantidade.Name = "labelQuantidade";
            labelQuantidade.Size = new Size(72, 15);
            labelQuantidade.TabIndex = 1;
            labelQuantidade.Text = "Quantidade:";
            // 
            // txtBoxMorada
            // 
            txtBoxMorada.Location = new Point(72, 22);
            txtBoxMorada.Margin = new Padding(3, 2, 3, 2);
            txtBoxMorada.Name = "txtBoxMorada";
            txtBoxMorada.Size = new Size(380, 23);
            txtBoxMorada.TabIndex = 7;
            // 
            // txtBoxQtd
            // 
            txtBoxQtd.Location = new Point(684, 54);
            txtBoxQtd.Margin = new Padding(3, 2, 3, 2);
            txtBoxQtd.Name = "txtBoxQtd";
            txtBoxQtd.Size = new Size(78, 23);
            txtBoxQtd.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 94);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1096, 285);
            dataGridView1.TabIndex = 4;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(956, 15);
            btnSubmit.Margin = new Padding(3, 2, 3, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(82, 22);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "Submeter";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // labelProduto
            // 
            labelProduto.AutoSize = true;
            labelProduto.Location = new Point(590, 22);
            labelProduto.Name = "labelProduto";
            labelProduto.Size = new Size(60, 15);
            labelProduto.TabIndex = 8;
            labelProduto.Text = "ProdutoId";
            // 
            // txtBoxProdutoId
            // 
            txtBoxProdutoId.Location = new Point(684, 20);
            txtBoxProdutoId.Margin = new Padding(3, 2, 3, 2);
            txtBoxProdutoId.Name = "txtBoxProdutoId";
            txtBoxProdutoId.Size = new Size(78, 23);
            txtBoxProdutoId.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(956, 59);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 388);
            Controls.Add(btnCancel);
            Controls.Add(txtBoxProdutoId);
            Controls.Add(labelProduto);
            Controls.Add(btnSubmit);
            Controls.Add(dataGridView1);
            Controls.Add(txtBoxQtd);
            Controls.Add(txtBoxMorada);
            Controls.Add(labelQuantidade);
            Controls.Add(labelMorada);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button btnSubmit;
        private Label labelProduto;
        private TextBox txtBoxProdutoId;
        private Button btnCancel;
    }
}
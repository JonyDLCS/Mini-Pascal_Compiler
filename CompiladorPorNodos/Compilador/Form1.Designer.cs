namespace Compilador
{
    partial class compilador_Form
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ejecutar_btn = new System.Windows.Forms.Button();
            this.Error_dataGridView = new System.Windows.Forms.DataGridView();
            this.valorError_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineaError_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoFuente_richBox = new System.Windows.Forms.RichTextBox();
            this.Tokens_dataGridView = new System.Windows.Forms.DataGridView();
            this.n = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lexema_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linea_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semanticoErrors_dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.polish_dataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Error_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tokens_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.semanticoErrors_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.polish_dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ejecutar_btn
            // 
            this.ejecutar_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ejecutar_btn.Location = new System.Drawing.Point(155, 386);
            this.ejecutar_btn.Name = "ejecutar_btn";
            this.ejecutar_btn.Size = new System.Drawing.Size(116, 41);
            this.ejecutar_btn.TabIndex = 0;
            this.ejecutar_btn.Text = "Ejecutar";
            this.ejecutar_btn.UseVisualStyleBackColor = true;
            this.ejecutar_btn.Click += new System.EventHandler(this.ejecutar_btn_Click);
            // 
            // Error_dataGridView
            // 
            this.Error_dataGridView.AllowUserToAddRows = false;
            this.Error_dataGridView.AllowUserToDeleteRows = false;
            this.Error_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Error_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valorError_columna,
            this.descripcion_columna,
            this.lineaError_columna});
            this.Error_dataGridView.Location = new System.Drawing.Point(3, 22);
            this.Error_dataGridView.Name = "Error_dataGridView";
            this.Error_dataGridView.ReadOnly = true;
            this.Error_dataGridView.RowHeadersVisible = false;
            this.Error_dataGridView.Size = new System.Drawing.Size(198, 158);
            this.Error_dataGridView.TabIndex = 1;
            // 
            // valorError_columna
            // 
            this.valorError_columna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valorError_columna.FillWeight = 15F;
            this.valorError_columna.HeaderText = "Valor";
            this.valorError_columna.Name = "valorError_columna";
            this.valorError_columna.ReadOnly = true;
            // 
            // descripcion_columna
            // 
            this.descripcion_columna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion_columna.FillWeight = 60F;
            this.descripcion_columna.HeaderText = "Descripcion";
            this.descripcion_columna.Name = "descripcion_columna";
            this.descripcion_columna.ReadOnly = true;
            // 
            // lineaError_columna
            // 
            this.lineaError_columna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lineaError_columna.FillWeight = 15F;
            this.lineaError_columna.HeaderText = "Linea";
            this.lineaError_columna.Name = "lineaError_columna";
            this.lineaError_columna.ReadOnly = true;
            // 
            // codigoFuente_richBox
            // 
            this.codigoFuente_richBox.AcceptsTab = true;
            this.codigoFuente_richBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codigoFuente_richBox.Location = new System.Drawing.Point(3, 3);
            this.codigoFuente_richBox.Name = "codigoFuente_richBox";
            this.codigoFuente_richBox.Size = new System.Drawing.Size(371, 430);
            this.codigoFuente_richBox.TabIndex = 2;
            this.codigoFuente_richBox.Text = "";
            // 
            // Tokens_dataGridView
            // 
            this.Tokens_dataGridView.AllowUserToAddRows = false;
            this.Tokens_dataGridView.AllowUserToDeleteRows = false;
            this.Tokens_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tokens_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Tokens_dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Tokens_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tokens_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.n,
            this.valor_columna,
            this.lexema_columna,
            this.tipo_columna,
            this.linea_columna});
            this.Tokens_dataGridView.Location = new System.Drawing.Point(3, 22);
            this.Tokens_dataGridView.Name = "Tokens_dataGridView";
            this.Tokens_dataGridView.ReadOnly = true;
            this.Tokens_dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Tokens_dataGridView.RowHeadersVisible = false;
            this.Tokens_dataGridView.Size = new System.Drawing.Size(198, 157);
            this.Tokens_dataGridView.TabIndex = 1;
            // 
            // n
            // 
            this.n.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.n.FillWeight = 8F;
            this.n.HeaderText = "#";
            this.n.Name = "n";
            this.n.ReadOnly = true;
            // 
            // valor_columna
            // 
            this.valor_columna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valor_columna.FillWeight = 17F;
            this.valor_columna.HeaderText = "Valor";
            this.valor_columna.MinimumWidth = 3;
            this.valor_columna.Name = "valor_columna";
            this.valor_columna.ReadOnly = true;
            // 
            // lexema_columna
            // 
            this.lexema_columna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lexema_columna.FillWeight = 25F;
            this.lexema_columna.HeaderText = "Lexema";
            this.lexema_columna.Name = "lexema_columna";
            this.lexema_columna.ReadOnly = true;
            // 
            // tipo_columna
            // 
            this.tipo_columna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipo_columna.FillWeight = 35F;
            this.tipo_columna.HeaderText = "Tipo";
            this.tipo_columna.Name = "tipo_columna";
            this.tipo_columna.ReadOnly = true;
            // 
            // linea_columna
            // 
            this.linea_columna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.linea_columna.FillWeight = 15F;
            this.linea_columna.HeaderText = "Linea";
            this.linea_columna.Name = "linea_columna";
            this.linea_columna.ReadOnly = true;
            this.linea_columna.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // semanticoErrors_dataGridView
            // 
            this.semanticoErrors_dataGridView.AllowUserToAddRows = false;
            this.semanticoErrors_dataGridView.AllowUserToDeleteRows = false;
            this.semanticoErrors_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.semanticoErrors_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.semanticoErrors_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Lexema,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.semanticoErrors_dataGridView.Location = new System.Drawing.Point(3, 20);
            this.semanticoErrors_dataGridView.Name = "semanticoErrors_dataGridView";
            this.semanticoErrors_dataGridView.ReadOnly = true;
            this.semanticoErrors_dataGridView.RowHeadersVisible = false;
            this.semanticoErrors_dataGridView.Size = new System.Drawing.Size(199, 160);
            this.semanticoErrors_dataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 15F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Lexema
            // 
            this.Lexema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Lexema.FillWeight = 25F;
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            this.Lexema.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 45F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.FillWeight = 15F;
            this.dataGridViewTextBoxColumn3.HeaderText = "#Tkn";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lista de Tokens";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lista de Errores Lexico y Sintactico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Errores Semanticos";
            // 
            // polish_dataGridView
            // 
            this.polish_dataGridView.AllowUserToAddRows = false;
            this.polish_dataGridView.AllowUserToDeleteRows = false;
            this.polish_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.polish_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.polish_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.polish_dataGridView.Location = new System.Drawing.Point(3, 21);
            this.polish_dataGridView.Name = "polish_dataGridView";
            this.polish_dataGridView.ReadOnly = true;
            this.polish_dataGridView.RowHeadersVisible = false;
            this.polish_dataGridView.Size = new System.Drawing.Size(199, 158);
            this.polish_dataGridView.TabIndex = 4;
            this.polish_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.polish_dataGridView_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lista de Polish";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(421, 377);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Tokens_dataGridView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 182);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.polish_dataGridView);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(213, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(205, 182);
            this.panel4.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.Error_dataGridView);
            this.panel3.Location = new System.Drawing.Point(3, 191);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(204, 183);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.semanticoErrors_dataGridView);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(213, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 183);
            this.panel2.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ejecutar_btn, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(380, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.18322F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.81678F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(427, 430);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.58255F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.41745F));
            this.tableLayoutPanel3.Controls.Add(this.codigoFuente_richBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(810, 436);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 25F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Salto";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.FillWeight = 75F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Nodo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // compilador_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 460);
            this.Controls.Add(this.tableLayoutPanel3);
            this.MinimumSize = new System.Drawing.Size(850, 343);
            this.Name = "compilador_Form";
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.compilador_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Error_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tokens_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.semanticoErrors_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.polish_dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ejecutar_btn;
        private System.Windows.Forms.DataGridView Error_dataGridView;
        private System.Windows.Forms.RichTextBox codigoFuente_richBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorError_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineaError_columna;
        private System.Windows.Forms.DataGridView Tokens_dataGridView;
        private System.Windows.Forms.DataGridView semanticoErrors_dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView polish_dataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn n;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn lexema_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn linea_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}


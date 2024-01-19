namespace Exemplo_GriedView
{
    partial class frm_Livro
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tblResultado = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEditora = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblEdição = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDisponibilidade = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblAutores = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblSinopse = new System.Windows.Forms.Label();
            this.lstExemplares = new System.Windows.Forms.ListBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.btnEmprestar = new System.Windows.Forms.Button();
            this.btnTirarCliente = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.pcbCapa = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocalizacao = new System.Windows.Forms.Label();
            this.chkFixo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCapa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // tblResultado
            // 
            this.tblResultado.AllowUserToAddRows = false;
            this.tblResultado.AllowUserToDeleteRows = false;
            this.tblResultado.AllowUserToResizeColumns = false;
            this.tblResultado.AllowUserToResizeRows = false;
            this.tblResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblResultado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblResultado.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblResultado.Location = new System.Drawing.Point(12, 43);
            this.tblResultado.Name = "tblResultado";
            this.tblResultado.ReadOnly = true;
            this.tblResultado.RowHeadersVisible = false;
            this.tblResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblResultado.Size = new System.Drawing.Size(784, 227);
            this.tblResultado.TabIndex = 2;
            this.tblResultado.SelectionChanged += new System.EventHandler(this.tblResultado_SelectionChanged);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Código";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 65;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ISBN";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 57;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Titulo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Editora";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 65;
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(12, 12);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(373, 20);
            this.txtBusca.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(391, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(64, 20);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Título:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitulo.Location = new System.Drawing.Point(259, 294);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(537, 18);
            this.lblTitulo.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(186, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Código:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCodigo.Location = new System.Drawing.Point(189, 294);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(64, 18);
            this.lblCodigo.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(186, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "ISBN:";
            // 
            // lblISBN
            // 
            this.lblISBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblISBN.Location = new System.Drawing.Point(188, 334);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(164, 18);
            this.lblISBN.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(355, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Editora:";
            // 
            // lblEditora
            // 
            this.lblEditora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEditora.Location = new System.Drawing.Point(358, 334);
            this.lblEditora.Name = "lblEditora";
            this.lblEditora.Size = new System.Drawing.Size(206, 18);
            this.lblEditora.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(567, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Ano Edição:";
            // 
            // lblEdição
            // 
            this.lblEdição.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdição.Location = new System.Drawing.Point(570, 334);
            this.lblEdição.Name = "lblEdição";
            this.lblEdição.Size = new System.Drawing.Size(116, 18);
            this.lblEdição.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(689, 320);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Disponibilidade:";
            // 
            // lblDisponibilidade
            // 
            this.lblDisponibilidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisponibilidade.Location = new System.Drawing.Point(692, 334);
            this.lblDisponibilidade.Name = "lblDisponibilidade";
            this.lblDisponibilidade.Size = new System.Drawing.Size(104, 18);
            this.lblDisponibilidade.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(809, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Exemplares:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(186, 361);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 26;
            // 
            // lblCategoria
            // 
            this.lblCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCategoria.Location = new System.Drawing.Point(189, 372);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(299, 18);
            this.lblCategoria.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(186, 358);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Categorias:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(497, 359);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Autores:";
            // 
            // lblAutores
            // 
            this.lblAutores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAutores.Location = new System.Drawing.Point(497, 372);
            this.lblAutores.Name = "lblAutores";
            this.lblAutores.Size = new System.Drawing.Size(299, 18);
            this.lblAutores.TabIndex = 30;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(186, 398);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "Sinopse:";
            // 
            // lblSinopse
            // 
            this.lblSinopse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSinopse.Location = new System.Drawing.Point(189, 412);
            this.lblSinopse.Name = "lblSinopse";
            this.lblSinopse.Size = new System.Drawing.Size(607, 107);
            this.lblSinopse.TabIndex = 32;
            // 
            // lstExemplares
            // 
            this.lstExemplares.FormattingEnabled = true;
            this.lstExemplares.Location = new System.Drawing.Point(812, 58);
            this.lstExemplares.Name = "lstExemplares";
            this.lstExemplares.Size = new System.Drawing.Size(98, 212);
            this.lstExemplares.TabIndex = 4;
            this.lstExemplares.SelectedIndexChanged += new System.EventHandler(this.lstExemplares_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(480, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(316, 13);
            this.lblCliente.TabIndex = 35;
            this.lblCliente.Text = "Cliente não identificado";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Location = new System.Drawing.Point(632, 16);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(0, 13);
            this.lblCodigoCliente.TabIndex = 36;
            this.lblCodigoCliente.Visible = false;
            // 
            // btnEmprestar
            // 
            this.btnEmprestar.Enabled = false;
            this.btnEmprestar.Location = new System.Drawing.Point(812, 496);
            this.btnEmprestar.Name = "btnEmprestar";
            this.btnEmprestar.Size = new System.Drawing.Size(98, 23);
            this.btnEmprestar.TabIndex = 6;
            this.btnEmprestar.Text = "Emprestar";
            this.btnEmprestar.UseVisualStyleBackColor = true;
            this.btnEmprestar.Click += new System.EventHandler(this.btnEmprestar_Click);
            // 
            // btnTirarCliente
            // 
            this.btnTirarCliente.BackgroundImage = global::Exemplo_GriedView.Properties.Resources.OutIcon;
            this.btnTirarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTirarCliente.Location = new System.Drawing.Point(875, 4);
            this.btnTirarCliente.Name = "btnTirarCliente";
            this.btnTirarCliente.Size = new System.Drawing.Size(35, 35);
            this.btnTirarCliente.TabIndex = 7;
            this.btnTirarCliente.UseVisualStyleBackColor = true;
            this.btnTirarCliente.Click += new System.EventHandler(this.btnTirarCliente_Click);
            // 
            // btnIcon
            // 
            this.btnIcon.BackgroundImage = global::Exemplo_GriedView.Properties.Resources.UserIcon;
            this.btnIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcon.Location = new System.Drawing.Point(834, 4);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(35, 35);
            this.btnIcon.TabIndex = 3;
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // pcbCapa
            // 
            this.pcbCapa.Location = new System.Drawing.Point(12, 281);
            this.pcbCapa.Name = "pcbCapa";
            this.pcbCapa.Size = new System.Drawing.Size(159, 238);
            this.pcbCapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCapa.TabIndex = 12;
            this.pcbCapa.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(809, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Localização:";
            // 
            // lblLocalizacao
            // 
            this.lblLocalizacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocalizacao.Location = new System.Drawing.Point(812, 294);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new System.Drawing.Size(98, 173);
            this.lblLocalizacao.TabIndex = 40;
            // 
            // chkFixo
            // 
            this.chkFixo.AutoSize = true;
            this.chkFixo.Enabled = false;
            this.chkFixo.Location = new System.Drawing.Point(830, 474);
            this.chkFixo.Name = "chkFixo";
            this.chkFixo.Size = new System.Drawing.Size(67, 17);
            this.chkFixo.TabIndex = 5;
            this.chkFixo.Text = "Consulta";
            this.chkFixo.UseVisualStyleBackColor = true;
            // 
            // frm_Livro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 530);
            this.Controls.Add(this.chkFixo);
            this.Controls.Add(this.lblLocalizacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTirarCliente);
            this.Controls.Add(this.btnEmprestar);
            this.Controls.Add(this.lblCodigoCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.lstExemplares);
            this.Controls.Add(this.lblSinopse);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblAutores);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblDisponibilidade);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblEdição);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblEditora);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pcbCapa);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.tblResultado);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Livro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GriedView";
            ((System.ComponentModel.ISupportInitialize)(this.tblResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblResultado;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.PictureBox pcbCapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEditora;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblEdição;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDisponibilidade;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblAutores;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblSinopse;
        private System.Windows.Forms.ListBox lstExemplares;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.Button btnEmprestar;
        private System.Windows.Forms.Button btnTirarCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocalizacao;
        private System.Windows.Forms.CheckBox chkFixo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}


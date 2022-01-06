
namespace ptoVenta
{
    partial class devoluciones
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(devoluciones));
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            this.txtBoletaFactura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMontoNota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGrid1 = new System.Windows.Forms.DataGridView();
            this.Posi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cButton39 = new CButtonLib.CButton();
            this.cButton40 = new CButtonLib.CButton();
            this.printDocumento = new System.Drawing.Printing.PrintDocument();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoletaFactura
            // 
            this.txtBoletaFactura.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoletaFactura.Location = new System.Drawing.Point(342, 80);
            this.txtBoletaFactura.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoletaFactura.Name = "txtBoletaFactura";
            this.txtBoletaFactura.ReadOnly = true;
            this.txtBoletaFactura.Size = new System.Drawing.Size(91, 30);
            this.txtBoletaFactura.TabIndex = 4;
            this.txtBoletaFactura.TabStop = false;
            this.txtBoletaFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(227, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Boleta Nro.:";
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(177)))), ((int)(((byte)(230)))));
            this.panel15.Controls.Add(this.label12);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(2);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1058, 46);
            this.panel15.TabIndex = 108;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(459, 7);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(141, 32);
            this.label12.TabIndex = 7;
            this.label12.Text = "Devolución";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMontoNota
            // 
            this.txtMontoNota.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoNota.Location = new System.Drawing.Point(878, 353);
            this.txtMontoNota.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoNota.Name = "txtMontoNota";
            this.txtMontoNota.ReadOnly = true;
            this.txtMontoNota.Size = new System.Drawing.Size(169, 30);
            this.txtMontoNota.TabIndex = 109;
            this.txtMontoNota.TabStop = false;
            this.txtMontoNota.Text = "0";
            this.txtMontoNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(799, 357);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 110;
            this.label1.Text = "Monto.:";
            // 
            // dgvGrid1
            // 
            this.dgvGrid1.AllowUserToAddRows = false;
            this.dgvGrid1.AllowUserToDeleteRows = false;
            this.dgvGrid1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Posi,
            this.Caja,
            this.Dia,
            this.Fecha,
            this.Codigo,
            this.Producto,
            this.Compra,
            this.Cantidad,
            this.Precio,
            this.Total,
            this.Codid});
            this.dgvGrid1.Location = new System.Drawing.Point(11, 114);
            this.dgvGrid1.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGrid1.Name = "dgvGrid1";
            this.dgvGrid1.RowHeadersVisible = false;
            this.dgvGrid1.RowHeadersWidth = 10;
            this.dgvGrid1.RowTemplate.Height = 25;
            this.dgvGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvGrid1.Size = new System.Drawing.Size(1036, 235);
            this.dgvGrid1.TabIndex = 1;
            this.dgvGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrid1_CellClick);
            this.dgvGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrid1_CellContentClick);
            this.dgvGrid1.CurrentCellChanged += new System.EventHandler(this.dgvGrid1_CurrentCellChanged);
            this.dgvGrid1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvGrid1_EditingControlShowing);
            // 
            // Posi
            // 
            this.Posi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Posi.DefaultCellStyle = dataGridViewCellStyle2;
            this.Posi.HeaderText = "Linea";
            this.Posi.Name = "Posi";
            this.Posi.Width = 50;
            // 
            // Caja
            // 
            this.Caja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Caja.HeaderText = "Caja";
            this.Caja.Name = "Caja";
            this.Caja.ReadOnly = true;
            // 
            // Dia
            // 
            this.Dia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dia.HeaderText = "Dia";
            this.Dia.Name = "Dia";
            this.Dia.ReadOnly = true;
            this.Dia.Width = 40;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 120;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 120;
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 240;
            // 
            // Compra
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Compra.DefaultCellStyle = dataGridViewCellStyle3;
            this.Compra.HeaderText = "Cantidad Comprada";
            this.Compra.Name = "Compra";
            this.Compra.Width = 80;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cantidad.HeaderText = "Cantidad a Devolver";
            this.Cantidad.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cantidad.Width = 80;
            // 
            // Precio
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle5;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle6;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Codid
            // 
            this.Codid.HeaderText = "Codid";
            this.Codid.Name = "Codid";
            this.Codid.Visible = false;
            // 
            // cButton39
            // 
            this.cButton39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cButton39.BackColor = System.Drawing.Color.Transparent;
            this.cButton39.BorderColor = System.Drawing.Color.Transparent;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(139)))), ((int)(((byte)(68)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        1F};
            this.cButton39.ColorFillBlend = cBlendItems1;
            this.cButton39.Corners.All = 8;
            this.cButton39.Corners.LowerLeft = 8;
            this.cButton39.Corners.LowerRight = 8;
            this.cButton39.Corners.UpperLeft = 8;
            this.cButton39.Corners.UpperRight = 8;
            this.cButton39.DesignerSelected = false;
            this.cButton39.DimFactorClick = 0;
            this.cButton39.DimFactorHover = -25;
            this.cButton39.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cButton39.Image = ((System.Drawing.Image)(resources.GetObject("cButton39.Image")));
            this.cButton39.ImageIndex = 0;
            this.cButton39.ImageSize = new System.Drawing.Size(35, 30);
            this.cButton39.Location = new System.Drawing.Point(898, 415);
            this.cButton39.Name = "cButton39";
            this.cButton39.Size = new System.Drawing.Size(148, 48);
            this.cButton39.TabIndex = 310;
            this.cButton39.TabStop = false;
            this.cButton39.Text = "Aceptar";
            this.cButton39.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cButton39.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // cButton40
            // 
            this.cButton40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cButton40.BackColor = System.Drawing.Color.Transparent;
            this.cButton40.BorderColor = System.Drawing.Color.Transparent;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        1F};
            this.cButton40.ColorFillBlend = cBlendItems2;
            this.cButton40.Corners.All = 8;
            this.cButton40.Corners.LowerLeft = 8;
            this.cButton40.Corners.LowerRight = 8;
            this.cButton40.Corners.UpperLeft = 8;
            this.cButton40.Corners.UpperRight = 8;
            this.cButton40.DesignerSelected = false;
            this.cButton40.DimFactorClick = 0;
            this.cButton40.DimFactorHover = -25;
            this.cButton40.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cButton40.Image = ((System.Drawing.Image)(resources.GetObject("cButton40.Image")));
            this.cButton40.ImageIndex = 0;
            this.cButton40.ImageSize = new System.Drawing.Size(35, 30);
            this.cButton40.Location = new System.Drawing.Point(11, 415);
            this.cButton40.Name = "cButton40";
            this.cButton40.Size = new System.Drawing.Size(148, 48);
            this.cButton40.TabIndex = 309;
            this.cButton40.TabStop = false;
            this.cButton40.Text = "Regresar";
            this.cButton40.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cButton40.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // devoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1058, 475);
            this.ControlBox = false;
            this.Controls.Add(this.cButton39);
            this.Controls.Add(this.cButton40);
            this.Controls.Add(this.dgvGrid1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMontoNota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoletaFactura);
            this.Controls.Add(this.panel15);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "devoluciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.devoluciones_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.devoluciones_KeyPress);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBoletaFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox txtMontoNota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Compra;
        private System.Windows.Forms.DataGridViewComboBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codid;
        private CButtonLib.CButton cButton39;
        private CButtonLib.CButton cButton40;
        private System.Drawing.Printing.PrintDocument printDocumento;
    }
}
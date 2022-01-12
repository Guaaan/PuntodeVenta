
namespace ptoVenta
{
    partial class CambiarContraseña
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
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContraseña));
            this.label1 = new System.Windows.Forms.Label();
            this.txtContraseñaA = new System.Windows.Forms.TextBox();
            this.txtContraseñaN = new System.Windows.Forms.TextBox();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cButton39 = new CButtonLib.CButton();
            this.cButton40 = new CButtonLib.CButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Gadugi", 16.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(99, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cambio de Contraseña";
            // 
            // txtContraseñaA
            // 
            this.txtContraseñaA.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseñaA.Location = new System.Drawing.Point(174, 94);
            this.txtContraseñaA.Name = "txtContraseñaA";
            this.txtContraseñaA.Size = new System.Drawing.Size(171, 29);
            this.txtContraseñaA.TabIndex = 1;
            this.txtContraseñaA.UseSystemPasswordChar = true;
            this.txtContraseñaA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseñaA_KeyPress);
            // 
            // txtContraseñaN
            // 
            this.txtContraseñaN.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseñaN.Location = new System.Drawing.Point(174, 178);
            this.txtContraseñaN.Name = "txtContraseñaN";
            this.txtContraseñaN.Size = new System.Drawing.Size(171, 29);
            this.txtContraseñaN.TabIndex = 2;
            this.txtContraseñaN.UseSystemPasswordChar = true;
            this.txtContraseñaN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseñaN_KeyPress);
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmar.Location = new System.Drawing.Point(174, 212);
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Size = new System.Drawing.Size(171, 29);
            this.txtConfirmar.TabIndex = 3;
            this.txtConfirmar.UseSystemPasswordChar = true;
            this.txtConfirmar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmar_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Gadugi", 16.25F);
            this.label2.Location = new System.Drawing.Point(47, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Gadugi", 16.25F);
            this.label3.Location = new System.Drawing.Point(47, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 52);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nueva \r\nContraseña:\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("Gadugi", 16.25F);
            this.label4.Location = new System.Drawing.Point(47, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Confirmar:";
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
            this.cButton39.ImageIndex = 0;
            this.cButton39.ImageSize = new System.Drawing.Size(35, 30);
            this.cButton39.Location = new System.Drawing.Point(304, 263);
            this.cButton39.Name = "cButton39";
            this.cButton39.Size = new System.Drawing.Size(100, 35);
            this.cButton39.TabIndex = 312;
            this.cButton39.TabStop = false;
            this.cButton39.Text = "Aceptar";
            this.cButton39.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.cButton40.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cButton40.DimFactorClick = 0;
            this.cButton40.DimFactorHover = -25;
            this.cButton40.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cButton40.ImageIndex = 0;
            this.cButton40.ImageSize = new System.Drawing.Size(35, 30);
            this.cButton40.Location = new System.Drawing.Point(12, 263);
            this.cButton40.Name = "cButton40";
            this.cButton40.Size = new System.Drawing.Size(100, 35);
            this.cButton40.TabIndex = 311;
            this.cButton40.TabStop = false;
            this.cButton40.Text = "Cancelar";
            this.cButton40.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cButton40.Click += new System.EventHandler(this.cButton40_Click);
            // 
            // CambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cButton40;
            this.ClientSize = new System.Drawing.Size(416, 310);
            this.ControlBox = false;
            this.Controls.Add(this.cButton39);
            this.Controls.Add(this.cButton40);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.txtContraseñaN);
            this.Controls.Add(this.txtContraseñaA);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "CambiarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CambiarContraseña_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContraseñaA;
        private System.Windows.Forms.TextBox txtContraseñaN;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CButtonLib.CButton cButton39;
        private CButtonLib.CButton cButton40;
    }
}
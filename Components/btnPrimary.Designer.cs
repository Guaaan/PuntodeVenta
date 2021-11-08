namespace btnLib
{
    partial class btnPrimary
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

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.botonPrimary = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonPrimary
            // 
            this.botonPrimary.Animated = true;
            this.botonPrimary.AnimationHoverSpeed = 0.07F;
            this.botonPrimary.AnimationSpeed = 0.03F;
            this.botonPrimary.BackColor = System.Drawing.Color.Transparent;
            this.botonPrimary.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(209)))));
            this.botonPrimary.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(148)))), ((int)(((byte)(166)))));
            this.botonPrimary.BorderColor = System.Drawing.Color.Black;
            this.botonPrimary.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonPrimary.FocusedColor = System.Drawing.Color.Empty;
            this.botonPrimary.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPrimary.ForeColor = System.Drawing.Color.White;
            this.botonPrimary.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonPrimary.Image = null;
            this.botonPrimary.ImageSize = new System.Drawing.Size(20, 20);
            this.botonPrimary.Location = new System.Drawing.Point(0, 0);
            this.botonPrimary.Name = "botonPrimary";
            this.botonPrimary.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(124)))), ((int)(((byte)(139)))));
            this.botonPrimary.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(124)))), ((int)(((byte)(139)))));
            this.botonPrimary.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonPrimary.OnHoverForeColor = System.Drawing.Color.White;
            this.botonPrimary.OnHoverImage = null;
            this.botonPrimary.OnPressedColor = System.Drawing.Color.Black;
            this.botonPrimary.OnPressedDepth = 50;
            this.botonPrimary.Radius = 8;
            this.botonPrimary.Size = new System.Drawing.Size(175, 50);
            this.botonPrimary.TabIndex = 0;
            this.botonPrimary.Text = "Botón";
            this.botonPrimary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonPrimary.UseTransfarantBackground = true;
            // 
            // btnPrimary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonPrimary);
            this.Name = "btnPrimary";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonPrimary;
    }
}

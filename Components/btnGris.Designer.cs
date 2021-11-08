
namespace btnLib
{
    partial class btnGris
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
            this.botonGris = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonGris
            // 
            this.botonGris.Animated = true;
            this.botonGris.AnimationHoverSpeed = 0.07F;
            this.botonGris.AnimationSpeed = 0.03F;
            this.botonGris.BackColor = System.Drawing.Color.Transparent;
            this.botonGris.BaseColor1 = System.Drawing.Color.White;
            this.botonGris.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.botonGris.BorderColor = System.Drawing.Color.Black;
            this.botonGris.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonGris.FocusedColor = System.Drawing.Color.Empty;
            this.botonGris.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold);
            this.botonGris.ForeColor = System.Drawing.Color.Black;
            this.botonGris.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonGris.Image = null;
            this.botonGris.ImageSize = new System.Drawing.Size(35, 35);
            this.botonGris.Location = new System.Drawing.Point(0, 0);
            this.botonGris.Name = "botonGris";
            this.botonGris.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.botonGris.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botonGris.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonGris.OnHoverForeColor = System.Drawing.Color.White;
            this.botonGris.OnHoverImage = null;
            this.botonGris.OnPressedColor = System.Drawing.Color.Black;
            this.botonGris.OnPressedDepth = 50;
            this.botonGris.Radius = 8;
            this.botonGris.Size = new System.Drawing.Size(175, 50);
            this.botonGris.TabIndex = 241;
            this.botonGris.Text = "Botón";
            this.botonGris.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonGris.UseTransfarantBackground = true;
            // 
            // btnGris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonGris);
            this.Name = "btnGris";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonGris;
    }
}

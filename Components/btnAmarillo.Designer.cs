
namespace btnLib
{
    partial class btnAmarillo
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
            this.botonAmarillo = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonAmarillo
            // 
            this.botonAmarillo.Animated = true;
            this.botonAmarillo.AnimationHoverSpeed = 0.07F;
            this.botonAmarillo.AnimationSpeed = 0.03F;
            this.botonAmarillo.BackColor = System.Drawing.Color.Transparent;
            this.botonAmarillo.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(181)))), ((int)(((byte)(30)))));
            this.botonAmarillo.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(149)))), ((int)(((byte)(9)))));
            this.botonAmarillo.BorderColor = System.Drawing.Color.Black;
            this.botonAmarillo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonAmarillo.FocusedColor = System.Drawing.Color.Empty;
            this.botonAmarillo.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAmarillo.ForeColor = System.Drawing.Color.White;
            this.botonAmarillo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonAmarillo.Image = null;
            this.botonAmarillo.ImageSize = new System.Drawing.Size(20, 20);
            this.botonAmarillo.Location = new System.Drawing.Point(0, 0);
            this.botonAmarillo.Name = "botonAmarillo";
            this.botonAmarillo.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(139)))), ((int)(((byte)(5)))));
            this.botonAmarillo.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(139)))), ((int)(((byte)(5)))));
            this.botonAmarillo.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonAmarillo.OnHoverForeColor = System.Drawing.Color.White;
            this.botonAmarillo.OnHoverImage = null;
            this.botonAmarillo.OnPressedColor = System.Drawing.Color.Black;
            this.botonAmarillo.OnPressedDepth = 50;
            this.botonAmarillo.Radius = 8;
            this.botonAmarillo.Size = new System.Drawing.Size(175, 50);
            this.botonAmarillo.TabIndex = 4;
            this.botonAmarillo.Text = "Botón";
            this.botonAmarillo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonAmarillo.UseTransfarantBackground = true;
            // 
            // btnAmarillo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonAmarillo);
            this.Name = "btnAmarillo";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonAmarillo;
    }
}

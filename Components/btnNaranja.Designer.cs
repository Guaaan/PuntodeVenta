
namespace btnLib
{
    partial class btnNaranja
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
            this.botonNaranja = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonNaranja
            // 
            this.botonNaranja.Animated = true;
            this.botonNaranja.AnimationHoverSpeed = 0.07F;
            this.botonNaranja.AnimationSpeed = 0.03F;
            this.botonNaranja.BackColor = System.Drawing.Color.Transparent;
            this.botonNaranja.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.botonNaranja.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(117)))), ((int)(((byte)(0)))));
            this.botonNaranja.BorderColor = System.Drawing.Color.Black;
            this.botonNaranja.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonNaranja.FocusedColor = System.Drawing.Color.Empty;
            this.botonNaranja.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonNaranja.ForeColor = System.Drawing.Color.White;
            this.botonNaranja.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonNaranja.Image = null;
            this.botonNaranja.ImageSize = new System.Drawing.Size(20, 20);
            this.botonNaranja.Location = new System.Drawing.Point(0, 0);
            this.botonNaranja.Name = "botonNaranja";
            this.botonNaranja.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            this.botonNaranja.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            this.botonNaranja.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonNaranja.OnHoverForeColor = System.Drawing.Color.White;
            this.botonNaranja.OnHoverImage = null;
            this.botonNaranja.OnPressedColor = System.Drawing.Color.Black;
            this.botonNaranja.OnPressedDepth = 50;
            this.botonNaranja.Radius = 8;
            this.botonNaranja.Size = new System.Drawing.Size(175, 50);
            this.botonNaranja.TabIndex = 6;
            this.botonNaranja.Text = "Botón";
            this.botonNaranja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonNaranja.UseTransfarantBackground = true;
            // 
            // btnNaranja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonNaranja);
            this.Name = "btnNaranja";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonNaranja;
    }
}

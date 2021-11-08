
namespace btnLib
{
    partial class btnRosa
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
            this.botonAquamarina = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonAquamarina
            // 
            this.botonAquamarina.Animated = true;
            this.botonAquamarina.AnimationHoverSpeed = 0.07F;
            this.botonAquamarina.AnimationSpeed = 0.03F;
            this.botonAquamarina.BackColor = System.Drawing.Color.Transparent;
            this.botonAquamarina.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(96)))), ((int)(((byte)(108)))));
            this.botonAquamarina.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(66)))), ((int)(((byte)(78)))));
            this.botonAquamarina.BorderColor = System.Drawing.Color.Black;
            this.botonAquamarina.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonAquamarina.FocusedColor = System.Drawing.Color.Empty;
            this.botonAquamarina.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAquamarina.ForeColor = System.Drawing.Color.White;
            this.botonAquamarina.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonAquamarina.Image = null;
            this.botonAquamarina.ImageSize = new System.Drawing.Size(20, 20);
            this.botonAquamarina.Location = new System.Drawing.Point(0, 0);
            this.botonAquamarina.Name = "botonAquamarina";
            this.botonAquamarina.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(42)))), ((int)(((byte)(50)))));
            this.botonAquamarina.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(42)))), ((int)(((byte)(50)))));
            this.botonAquamarina.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonAquamarina.OnHoverForeColor = System.Drawing.Color.White;
            this.botonAquamarina.OnHoverImage = null;
            this.botonAquamarina.OnPressedColor = System.Drawing.Color.Black;
            this.botonAquamarina.OnPressedDepth = 50;
            this.botonAquamarina.Radius = 8;
            this.botonAquamarina.Size = new System.Drawing.Size(175, 50);
            this.botonAquamarina.TabIndex = 6;
            this.botonAquamarina.Text = "Botón";
            this.botonAquamarina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonAquamarina.UseTransfarantBackground = true;
            // 
            // btnRosa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonAquamarina);
            this.Name = "btnRosa";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonAquamarina;
    }
}

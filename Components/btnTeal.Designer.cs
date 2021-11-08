
namespace btnLib
{
    partial class btnTeal
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
            this.botonTeal = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonTeal
            // 
            this.botonTeal.Animated = true;
            this.botonTeal.AnimationHoverSpeed = 0.07F;
            this.botonTeal.AnimationSpeed = 0.03F;
            this.botonTeal.BackColor = System.Drawing.Color.Transparent;
            this.botonTeal.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(101)))), ((int)(((byte)(133)))));
            this.botonTeal.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.botonTeal.BorderColor = System.Drawing.Color.Black;
            this.botonTeal.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonTeal.FocusedColor = System.Drawing.Color.Empty;
            this.botonTeal.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonTeal.ForeColor = System.Drawing.Color.White;
            this.botonTeal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonTeal.Image = null;
            this.botonTeal.ImageSize = new System.Drawing.Size(20, 20);
            this.botonTeal.Location = new System.Drawing.Point(0, 0);
            this.botonTeal.Name = "botonTeal";
            this.botonTeal.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(44)))), ((int)(((byte)(58)))));
            this.botonTeal.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(44)))), ((int)(((byte)(58)))));
            this.botonTeal.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonTeal.OnHoverForeColor = System.Drawing.Color.White;
            this.botonTeal.OnHoverImage = null;
            this.botonTeal.OnPressedColor = System.Drawing.Color.Black;
            this.botonTeal.OnPressedDepth = 50;
            this.botonTeal.Radius = 8;
            this.botonTeal.Size = new System.Drawing.Size(175, 50);
            this.botonTeal.TabIndex = 3;
            this.botonTeal.Text = "Botón";
            this.botonTeal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonTeal.UseTransfarantBackground = true;
            // 
            // btnTeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonTeal);
            this.Name = "btnTeal";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonTeal;
    }
}


namespace btnLib
{
    partial class btnAzul
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
            this.botonAzul = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonAzul
            // 
            this.botonAzul.Animated = true;
            this.botonAzul.AnimationHoverSpeed = 0.07F;
            this.botonAzul.AnimationSpeed = 0.03F;
            this.botonAzul.BackColor = System.Drawing.Color.Transparent;
            this.botonAzul.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.botonAzul.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(142)))));
            this.botonAzul.BorderColor = System.Drawing.Color.Black;
            this.botonAzul.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonAzul.FocusedColor = System.Drawing.Color.Empty;
            this.botonAzul.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAzul.ForeColor = System.Drawing.Color.White;
            this.botonAzul.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonAzul.Image = null;
            this.botonAzul.ImageSize = new System.Drawing.Size(20, 20);
            this.botonAzul.Location = new System.Drawing.Point(0, 0);
            this.botonAzul.Name = "botonAzul";
            this.botonAzul.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(94)))));
            this.botonAzul.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(94)))));
            this.botonAzul.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonAzul.OnHoverForeColor = System.Drawing.Color.White;
            this.botonAzul.OnHoverImage = null;
            this.botonAzul.OnPressedColor = System.Drawing.Color.Black;
            this.botonAzul.OnPressedDepth = 50;
            this.botonAzul.Radius = 8;
            this.botonAzul.Size = new System.Drawing.Size(175, 50);
            this.botonAzul.TabIndex = 1;
            this.botonAzul.Text = "Botón";
            this.botonAzul.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonAzul.UseTransfarantBackground = true;
            // 
            // btnAzul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonAzul);
            this.Name = "btnAzul";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonAzul;
    }
}


namespace btnLib
{
    partial class btnAceptar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnAceptar));
            this.botonAceptar = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonAceptar
            // 
            this.botonAceptar.Animated = true;
            this.botonAceptar.AnimationHoverSpeed = 0.07F;
            this.botonAceptar.AnimationSpeed = 0.03F;
            this.botonAceptar.BackColor = System.Drawing.Color.Transparent;
            this.botonAceptar.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.botonAceptar.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(139)))), ((int)(((byte)(68)))));
            this.botonAceptar.BorderColor = System.Drawing.Color.Black;
            this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonAceptar.FocusedColor = System.Drawing.Color.Empty;
            this.botonAceptar.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold);
            this.botonAceptar.ForeColor = System.Drawing.Color.White;
            this.botonAceptar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonAceptar.Image = ((System.Drawing.Image)(resources.GetObject("botonAceptar.Image")));
            this.botonAceptar.ImageOffsetX = -5;
            this.botonAceptar.ImageSize = new System.Drawing.Size(25, 25);
            this.botonAceptar.Location = new System.Drawing.Point(0, 0);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(100)))), ((int)(((byte)(48)))));
            this.botonAceptar.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(100)))), ((int)(((byte)(48)))));
            this.botonAceptar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonAceptar.OnHoverForeColor = System.Drawing.Color.White;
            this.botonAceptar.OnHoverImage = null;
            this.botonAceptar.OnPressedColor = System.Drawing.Color.Black;
            this.botonAceptar.Radius = 8;
            this.botonAceptar.Size = new System.Drawing.Size(105, 30);
            this.botonAceptar.TabIndex = 210;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.botonAceptar.UseTransfarantBackground = true;
            // 
            // btnAceptar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonAceptar);
            this.Name = "btnAceptar";
            this.Size = new System.Drawing.Size(105, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonAceptar;
    }
}

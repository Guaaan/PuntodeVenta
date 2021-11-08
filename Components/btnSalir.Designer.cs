
namespace btnLib
{
    partial class btnSalir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnSalir));
            this.botonSalir = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonSalir
            // 
            this.botonSalir.Animated = true;
            this.botonSalir.AnimationHoverSpeed = 0.07F;
            this.botonSalir.AnimationSpeed = 0.03F;
            this.botonSalir.BackColor = System.Drawing.Color.Transparent;
            this.botonSalir.BaseColor1 = System.Drawing.Color.Red;
            this.botonSalir.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.botonSalir.BorderColor = System.Drawing.Color.Black;
            this.botonSalir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonSalir.FocusedColor = System.Drawing.Color.Empty;
            this.botonSalir.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSalir.ForeColor = System.Drawing.Color.White;
            this.botonSalir.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonSalir.Image = ((System.Drawing.Image)(resources.GetObject("botonSalir.Image")));
            this.botonSalir.ImageSize = new System.Drawing.Size(25, 25);
            this.botonSalir.Location = new System.Drawing.Point(0, 0);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.botonSalir.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.botonSalir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonSalir.OnHoverForeColor = System.Drawing.Color.White;
            this.botonSalir.OnHoverImage = null;
            this.botonSalir.OnPressedColor = System.Drawing.Color.Black;
            this.botonSalir.Radius = 8;
            this.botonSalir.Size = new System.Drawing.Size(90, 30);
            this.botonSalir.TabIndex = 278;
            this.botonSalir.Text = "Salir";
            this.botonSalir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // btnSalir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonSalir);
            this.Name = "btnSalir";
            this.Size = new System.Drawing.Size(90, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonSalir;
    }
}

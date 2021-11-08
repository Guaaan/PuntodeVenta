
namespace btnLib
{
    partial class btnVerde
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
            this.botonVerde = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonVerde
            // 
            this.botonVerde.Animated = true;
            this.botonVerde.AnimationHoverSpeed = 0.07F;
            this.botonVerde.AnimationSpeed = 0.03F;
            this.botonVerde.BackColor = System.Drawing.Color.Transparent;
            this.botonVerde.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.botonVerde.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(123)))), ((int)(((byte)(56)))));
            this.botonVerde.BorderColor = System.Drawing.Color.Black;
            this.botonVerde.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonVerde.FocusedColor = System.Drawing.Color.Empty;
            this.botonVerde.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVerde.ForeColor = System.Drawing.Color.White;
            this.botonVerde.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonVerde.Image = null;
            this.botonVerde.ImageSize = new System.Drawing.Size(20, 20);
            this.botonVerde.Location = new System.Drawing.Point(0, 0);
            this.botonVerde.Name = "botonVerde";
            this.botonVerde.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(82)))), ((int)(((byte)(37)))));
            this.botonVerde.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(82)))), ((int)(((byte)(37)))));
            this.botonVerde.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonVerde.OnHoverForeColor = System.Drawing.Color.White;
            this.botonVerde.OnHoverImage = null;
            this.botonVerde.OnPressedColor = System.Drawing.Color.Black;
            this.botonVerde.OnPressedDepth = 50;
            this.botonVerde.Radius = 8;
            this.botonVerde.Size = new System.Drawing.Size(175, 50);
            this.botonVerde.TabIndex = 2;
            this.botonVerde.Text = "Botón";
            this.botonVerde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonVerde.UseTransfarantBackground = true;
            // 
            // btnVerde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonVerde);
            this.Name = "btnVerde";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonVerde;
    }
}

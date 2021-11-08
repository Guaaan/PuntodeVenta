
namespace btnLib
{
    partial class UserControl1
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
            this.botonAheredar = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonAheredar
            // 
            this.botonAheredar.Animated = true;
            this.botonAheredar.AnimationHoverSpeed = 0.07F;
            this.botonAheredar.AnimationSpeed = 0.03F;
            this.botonAheredar.BackColor = System.Drawing.Color.Transparent;
            this.botonAheredar.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(125)))));
            this.botonAheredar.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(83)))));
            this.botonAheredar.BorderColor = System.Drawing.Color.Black;
            this.botonAheredar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonAheredar.FocusedColor = System.Drawing.Color.Empty;
            this.botonAheredar.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAheredar.ForeColor = System.Drawing.Color.White;
            this.botonAheredar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonAheredar.Image = null;
            this.botonAheredar.ImageSize = new System.Drawing.Size(20, 20);
            this.botonAheredar.Location = new System.Drawing.Point(0, 0);
            this.botonAheredar.Name = "botonAheredar";
            this.botonAheredar.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(77)))), ((int)(((byte)(55)))));
            this.botonAheredar.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(77)))), ((int)(((byte)(55)))));
            this.botonAheredar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonAheredar.OnHoverForeColor = System.Drawing.Color.White;
            this.botonAheredar.OnHoverImage = null;
            this.botonAheredar.OnPressedColor = System.Drawing.Color.Black;
            this.botonAheredar.OnPressedDepth = 50;
            this.botonAheredar.Radius = 8;
            this.botonAheredar.Size = new System.Drawing.Size(175, 50);
            this.botonAheredar.TabIndex = 6;
            this.botonAheredar.Text = "Botón";
            this.botonAheredar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonAheredar.UseTransfarantBackground = true;
            // 
            // UserControl1
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.botonAheredar);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(321, 186);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonAheredar;
    }
}

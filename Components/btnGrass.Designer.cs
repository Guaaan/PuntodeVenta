
namespace btnLib
{
    partial class btnGrass
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
            this.botonGrass = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // botonGrass
            // 
            this.botonGrass.Animated = true;
            this.botonGrass.AnimationHoverSpeed = 0.07F;
            this.botonGrass.AnimationSpeed = 0.03F;
            this.botonGrass.BackColor = System.Drawing.Color.Transparent;
            this.botonGrass.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(188)))), ((int)(((byte)(95)))));
            this.botonGrass.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(125)))), ((int)(((byte)(63)))));
            this.botonGrass.BorderColor = System.Drawing.Color.Black;
            this.botonGrass.DialogResult = System.Windows.Forms.DialogResult.None;
            this.botonGrass.FocusedColor = System.Drawing.Color.Empty;
            this.botonGrass.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonGrass.ForeColor = System.Drawing.Color.White;
            this.botonGrass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.botonGrass.Image = null;
            this.botonGrass.ImageSize = new System.Drawing.Size(20, 20);
            this.botonGrass.Location = new System.Drawing.Point(0, 0);
            this.botonGrass.Name = "botonGrass";
            this.botonGrass.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(83)))), ((int)(((byte)(42)))));
            this.botonGrass.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(83)))), ((int)(((byte)(42)))));
            this.botonGrass.OnHoverBorderColor = System.Drawing.Color.Black;
            this.botonGrass.OnHoverForeColor = System.Drawing.Color.White;
            this.botonGrass.OnHoverImage = null;
            this.botonGrass.OnPressedColor = System.Drawing.Color.Black;
            this.botonGrass.OnPressedDepth = 50;
            this.botonGrass.Radius = 8;
            this.botonGrass.Size = new System.Drawing.Size(175, 50);
            this.botonGrass.TabIndex = 6;
            this.botonGrass.Text = "Botón";
            this.botonGrass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botonGrass.UseTransfarantBackground = true;
            // 
            // btnGrass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.botonGrass);
            this.Name = "btnGrass";
            this.Size = new System.Drawing.Size(175, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton botonGrass;
    }
}

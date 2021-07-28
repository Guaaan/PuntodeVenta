
namespace ptoVenta
{
    partial class clases
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnExistenciaenLocales = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(145)))), ((int)(((byte)(189)))));
            this.panel15.Location = new System.Drawing.Point(12, 122);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(185, 13);
            this.panel15.TabIndex = 73;
            // 
            // btnExistenciaenLocales
            // 
            this.btnExistenciaenLocales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(229)))));
            this.btnExistenciaenLocales.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(177)))), ((int)(((byte)(230)))));
            this.btnExistenciaenLocales.FlatAppearance.BorderSize = 3;
            this.btnExistenciaenLocales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExistenciaenLocales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExistenciaenLocales.ForeColor = System.Drawing.Color.White;
            this.btnExistenciaenLocales.IconChar = FontAwesome.Sharp.IconChar.NetworkWired;
            this.btnExistenciaenLocales.IconColor = System.Drawing.Color.White;
            this.btnExistenciaenLocales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExistenciaenLocales.IconSize = 50;
            this.btnExistenciaenLocales.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnExistenciaenLocales.Location = new System.Drawing.Point(12, 12);
            this.btnExistenciaenLocales.Name = "btnExistenciaenLocales";
            this.btnExistenciaenLocales.Size = new System.Drawing.Size(185, 116);
            this.btnExistenciaenLocales.TabIndex = 72;
            this.btnExistenciaenLocales.Text = "Existencia en Locales";
            this.btnExistenciaenLocales.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExistenciaenLocales.UseVisualStyleBackColor = false;
            // 
            // clases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.btnExistenciaenLocales);
            this.Name = "clases";
            this.Text = "clases";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel15;
        private FontAwesome.Sharp.IconButton btnExistenciaenLocales;
    }
}
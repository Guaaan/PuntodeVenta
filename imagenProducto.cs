using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ptoVenta
{
    public partial class imagenProducto : Form
    {
        public imagenProducto()
        {
            InitializeComponent();
            //pictureBox1.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+ lblLinea.Text.ToString());
        }

        private void imagenProducto_Load(object sender, EventArgs e)
        {
            Top = Form1.ftop;
            Left = 150;
        }
       

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imagenProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        
    }
}

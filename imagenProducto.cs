using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void imagenProducto_Load(object sender, EventArgs e)
        {
            
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

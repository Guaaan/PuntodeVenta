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
            var _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            Top = _point.Y;
            Left = _point.X;
        }
       

        private void imagenProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void imagenProducto_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imagenProducto_MouseLeave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

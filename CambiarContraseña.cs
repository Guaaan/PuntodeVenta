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
    public partial class CambiarContraseña : Form
    {
        public CambiarContraseña()
        {
            InitializeComponent();
        }

        private void CambiarContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
            if (e.KeyChar == 27)
            {
                cButton40_Click(sender, e);
            }
        }

        public void cButton40_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContraseñaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
            if (e.KeyChar == 13)
            {
                txtContraseñaN.Focus();
            }
        }

        private void txtContraseñaN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
            if (e.KeyChar == 13)
            {
                //agregar la función para cambiar de contraseña
            }
        }
    }
}

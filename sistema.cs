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
    public partial class sistema : Form
    {
        public sistema()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tabControlChico.SelectTab(0);
        }

        private void rbReporteConsumo_CheckedChanged(object sender, EventArgs e)
        {
            tabControlChico.SelectTab(1);
        }

        private void rbCierreCaja_CheckedChanged(object sender, EventArgs e)
        {
            tabControlChico.SelectTab(2);
        }

        private void rbConsolaFiscal_CheckedChanged(object sender, EventArgs e)
        {
            tabControlChico.SelectTab(3);
        }

        private void rbReporteVentas_CheckedChanged(object sender, EventArgs e)
        {
            tabControlChico.SelectTab(4);
        }
                
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

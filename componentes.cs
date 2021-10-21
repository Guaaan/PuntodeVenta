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
    public partial class componentes : Form
    {
        public componentes()
        {
            InitializeComponent();

        }

        private void componentes_Load(object sender, EventArgs e)
        {
            btnLiberarCaja.Text = "Liberar" + Environment.NewLine + "Caja";
            btnGuardarDocumento.Text = "Guardar" + Environment.NewLine + "Documento";
            btnCargarDocumento.Text = "Cargar" + Environment.NewLine + "Documento";
            btnProductosFaltantes.Text = "Productos" + Environment.NewLine + "Faltantes";
            btnStock.Text = "Stock en" + Environment.NewLine + "Tiendas";
            btnProcesarBoleta.Text = "Procesar" + Environment.NewLine + "Boleta";
            btnCambioPrecio.Text = "Cambio" + Environment.NewLine + "de Precio";
        }

        

    }
}

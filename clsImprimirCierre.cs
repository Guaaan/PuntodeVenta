using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ptoVenta
{
    //texto izquierda
    //e.Graphics.DrawString("Total:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
    //texto Derecha
    //e.Graphics.DrawString(montoTotal.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato
    class ClsImprimirCierre
    {
        SqlCommand com;
        SqlDataReader Dr;
        public PrintPageEventHandler CargarImprimir(PrintDocument impresiondocument/*DataGridView dgVariable, PrintDocument impresiondocument, string documc, string tipo*/)
        {
            
            
            impresiondocument = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            impresiondocument.PrinterSettings = ps;
            impresiondocument.PrintPage += Imprimir;
            impresiondocument.Print();
            void Imprimir(object sender, PrintPageEventArgs e)
            {
                //variables
                Font titulo = new Font("Arial", 16, FontStyle.Bold);
                Font header = new Font("Courier", 14);
                Font linea = new Font("Courier", 14, FontStyle.Bold);
                Font font = new Font("Courier", 11);
                Font fuente = new Font("Courier", 8);
                Font espaciado = new Font("Arial", 2);
                //alinear al centro
                StringFormat alineadoCentro = new StringFormat();
                alineadoCentro.LineAlignment = StringAlignment.Center;
                alineadoCentro.Alignment = StringAlignment.Center;

                int y = 20;
                int ancho = 270;
                var dateAndTime = DateTime.Now;
                var Date = dateAndTime.ToLongDateString();
                string hora = DateTime.Now.ToString("hh:mm:ss");

                int de20Mil = 1;
                int de10Mil = 1;
                int de5Mil = 1;
                int de2Mil = 1;
                int deMil = 1;
                int de500  = 1;
                int de100  = 1;
                int de50   = 1;
                int de10 = 1;
                int totalBilletes = de20Mil + de10Mil + de5Mil + de2Mil + deMil + de500 + de100 + de50 + de10;

                int aperturaCaja = 50000;
                int ventasEfectivo = 50000;
                int otrosIngresos = 0;
                int totalEfectivo = ventasEfectivo + otrosIngresos;

                int totalCredito = 0;
                int totalDebito = 0;
                int totalTransferencias = 0;



                StringFormat formato1 = new StringFormat(StringFormatFlags.NoClip);
                StringFormat formato2 = new StringFormat(formato1);
                string NombLoc = Form1.nombreFarmacia;
                formato1.LineAlignment = StringAlignment.Near;
                formato1.Alignment = StringAlignment.Center;
                formato2.LineAlignment = StringAlignment.Center;
                formato2.Alignment = StringAlignment.Far;

                //header
                e.Graphics.DrawString("FARMACIAS GEMINIS", titulo, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString(NombLoc, linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Rut: " + Form1.erif, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 2, ancho, 20));
                e.Graphics.DrawString(Date, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("hora: "+ hora, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 2, ancho, 20));
                //billetes
                e.Graphics.DrawString("De 20.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de20Mil.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("De 10.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de10Mil.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("De 5.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de5Mil.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("De 2.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de2Mil.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("De 1.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(deMil.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("De 500 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de500.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("De 100 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de100.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("De 50 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de50.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("De 10 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de10.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                //fin de los billetes
                e.Graphics.DrawString("Total: ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalBilletes.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                //----------------------------------//
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString("Transferencias", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Cierre de caja", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(iniciarSesion.unombre.Trim(), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Ventas del día "+ DateTime.Now.ToString("dd"), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Entrada en efectivo", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                //----------------------------------//
                e.Graphics.DrawString("Apertura de Caja:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(aperturaCaja.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("Ventas Efectivo:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(ventasEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("Otros Ingresos:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(otrosIngresos.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                //total 
                e.Graphics.DrawString("Total Ingresos:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                //----------------------------------//
                //fin efectivo
                e.Graphics.DrawString("Entrada en Tarjetas", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Débito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("Arqueo Débito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalDebito.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);

                e.Graphics.DrawString("Crédito", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("Arqueo Crédito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalCredito.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);

                e.Graphics.DrawString("Transferencia:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("arqueo Transferencia:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalTransferencias.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
            }


            return Imprimir;

        }
    }
}

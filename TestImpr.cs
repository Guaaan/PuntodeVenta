using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ptoVenta
{
    class TestImpr
    {
        public PrintPageEventHandler CargarImprimir(PrintDocument impresiondocument)
        {
            impresiondocument = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            impresiondocument.PrinterSettings = ps;
            impresiondocument.PrintPage += Imprimir;
            impresiondocument.Print();
            void Imprimir(object sender, PrintPageEventArgs e)
            {
                Font titulo = new Font("Arial", 16, System.Drawing.FontStyle.Bold);
                Font header = new Font("Courier", 14);
                Font linea = new Font("Courier", 14);
                Font font = new Font("Courier", 11);
                Font fuente = new Font("Courier", 8);
                int y = 20;
                int ancho = 270;
                var dateAndTime = DateTime.Now;
                var Date = dateAndTime.ToLongDateString();
                string hora = DateTime.Now.ToString("hh:mm:ss");

                StringFormat formato1 = new StringFormat(StringFormatFlags.NoClip);
                StringFormat formato2 = new StringFormat(formato1);
                StringFormat alineadoCentro = new StringFormat();

                alineadoCentro.LineAlignment = StringAlignment.Center;
                alineadoCentro.Alignment = StringAlignment.Center;
                formato1.LineAlignment = StringAlignment.Near;
                formato1.Alignment = StringAlignment.Center;
                formato2.LineAlignment = StringAlignment.Center;
                formato2.Alignment = StringAlignment.Far;

                string Nombre = "este es el nombre de un medicamento particularmente largo para probar un feature necesario para las boletas";
                double Precio = 19.990;

                e.Graphics.DrawString("1"
                + "   |   " + Nombre.ToString()/*.Substring(0, Nombre.Length > 30 ? 30 : Nombre.Length)*/, fuente, Brushes.Black, new RectangleF(0, y += 40, ancho, 40));
                e.Graphics.DrawString("|$" + Precio.ToString(), fuente, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("1"
                + "   |   " + Nombre.ToString()/*.Substring(0, Nombre.Length > 30 ? 30 : Nombre.Length)*/, fuente, Brushes.Black, new RectangleF(0, y += 40, ancho, 40));
                e.Graphics.DrawString("|$" + Precio.ToString(), fuente, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("1"
                + "   |   " + Nombre.ToString()/*.Substring(0, Nombre.Length > 30 ? 30 : Nombre.Length)*/, fuente, Brushes.Black, new RectangleF(0, y += 40, ancho, 40));
                e.Graphics.DrawString("|$" + Precio.ToString(), fuente, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("1"
                + "   |   " + Nombre.ToString()/*.Substring(0, Nombre.Length > 30 ? 30 : Nombre.Length)*/, fuente, Brushes.Black, new RectangleF(0, y += 40, ancho, 40));
                e.Graphics.DrawString("|$" + Precio.ToString(), fuente, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
            }
            return Imprimir;
        }
    }
}

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
    class ClsImprimirValeC
    {
        public PrintPageEventHandler ImprimirCoti(PrintDocument impresiondocument,string cont, string monto, string persona)
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
                int anchob = 200;
                var dateAndTime = DateTime.Now;
                var Date = dateAndTime.ToLongDateString();
                string hora = DateTime.Now.ToString("hh:mm:ss");
                string montoS = monto;
                string contenido = cont;
                string person = persona;
                int montoI = Convert.ToInt32(montoS);

                StringFormat formato1 = new StringFormat(StringFormatFlags.NoClip);
                StringFormat formato2 = new StringFormat(formato1);
                string NombLoc = Form1.nombreFarmacia;
                formato1.LineAlignment = StringAlignment.Near;
                formato1.Alignment = StringAlignment.Center;
                formato2.LineAlignment = StringAlignment.Center;
                formato2.Alignment = StringAlignment.Far;
                //header
                e.Graphics.DrawString("FARMACIAS GEMINIS", titulo, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString(NombLoc, linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Rut: " + Form1.erif, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 2, ancho, 20));
                e.Graphics.DrawString(Date, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("hora: " + hora, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("Autorizado por: " + person, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                //fin del header 
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString("Egreso Nro: ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(contenido, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 110), alineadoCentro);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 80, ancho, 20));

                e.Graphics.DrawString("Total: ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(montoI.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //----------------------------------//
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20)); 
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20)); 
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20)); 
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20)); 
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString("Firmas: ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));


            }
            return Imprimir;
        }

    }
}

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
    class clsApertura
    {
        public static string documc = "";
        private string comsql1, comsql2;
        public static string vnum;
        public static SqlConnection cn, locn;
        SqlCommand com;
        SqlDataReader Dr;

        public PrintPageEventHandler CargarImprimir(string monto, PrintDocument impresiondocument, string tipo)
        {
            impresiondocument = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            impresiondocument.PrinterSettings = ps;
            impresiondocument.PrintPage += Imprimir;
            impresiondocument.Print();
            void Imprimir(object sender, PrintPageEventArgs e)
            {
                Font titulo = new Font("Arial", 10, FontStyle.Bold);
                Font header = new Font("Courier", 10);
                Font linea = new Font("Courier", 10, FontStyle.Bold);
                Font font = new Font("Courier", 7);
                Font fuente = new Font("Courier", 7);
                Font espaciado = new Font("Arial", 1);

                int y = 20;
                string v1 = Convert.ToString((int)Math.Round(Form1.colimpre*3.375));
                int ancho = Convert.ToInt32(v1);
                int anchoB = ancho-25;
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

                //Rectangle displayRectangle = new Rectangle(new Point(0, 20), new Size(240, 20));

                string LineEncabezado = "Cant  Articulo‎‎‎‎‏‏‎";   // agrega lineas de  encabezados
                string telef = Form1.telefono;

                //header
                Image logoG = Image.FromFile("pfp\\LogoGeminis.png");
                //header
                e.Graphics.DrawImage(logoG, new PointF(0, y));
                e.Graphics.DrawString("   ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(telef, titulo, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                //e.Graphics.DrawString("FARMACIAS GEMINIS", titulo, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                //e.Graphics.DrawString("———Punto de Venta———", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Rut: " + Form1.erif, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(Date, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("hora: " + hora, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("Caja: " + iniciarSesion.ucodigo, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(tipo, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20),alineadoCentro);
                e.Graphics.DrawString("—————————————————————", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(LineEncabezado, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("Valor", font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("—————————————————————", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                //e.Graphics.DrawString("   ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

                double montoTotal = 0;
               
                    //agregar total de la boleta
                
                //----fin del header
                //e.Graphics.DrawString("PRODUCTOS:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString("————————————————————————", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Total:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("$"+montoTotal.ToString("N0"), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("GRACIAS POR SU VISITA", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("HASTA PRONTO", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("  ", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("www.farmaciasgeminis.cl", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
            }


            return Imprimir;
            
        }
    }
}
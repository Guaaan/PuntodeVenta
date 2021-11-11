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
    class ClsImprimir
    {
        public static PrintPageEventHandler imprimirevento() 
        
        //public PrintPageEventHandler;
        public Imprimir()
        {
            
            datosGrid = null;
            //vnumero = "";
        }

        public DataGridViewRowCollection datosGrid;
        //public String vnumero;

        public void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font header = new Font("Arial", 14);
            Font font = new Font("Arial", 11);
            Font fuente = new Font("Arial", 8);
            int y = 20;
            int ancho = 270;

            StringFormat formato1 = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formato2 = new StringFormat(formato1);

            formato1.LineAlignment = StringAlignment.Near;
            formato1.Alignment = StringAlignment.Center;
            formato2.LineAlignment = StringAlignment.Center;
            formato2.Alignment = StringAlignment.Far;


            //Rectangle displayRectangle = new Rectangle(new Point(0, 20), new Size(240, 20));

            string LineEncabezado = "Cant  Articulo‎‎‎‎‏‏‎";   // agrega lineas de  encabezados

            //header
            e.Graphics.DrawString("FARMACIAS GEMINIS", header, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("————Punto de Venta————————————————————————", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Rut: " + Form1.erif, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToString(), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Caja: " + iniciarSesion.ucodigo, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("COTIZACIÓN", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("————Productos—————————————————————————", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString(LineEncabezado, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Valor", font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
            e.Graphics.DrawString("   ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));



            //----fin del header
            double montoTotal = 0;

            foreach (DataGridViewRow row in datosGrid)
            {

                TicketDatos dato = new TicketDatos();
                dato.Codigo = row.Cells["codigo"].Value.ToString();
                dato.Nombre = row.Cells["producto"].Value.ToString();
                dato.Cantidad = row.Cells["cantidad"].Value.ToString();
                dato.Precio = row.Cells["precio"].Value.ToString();
                //agregar total de la boleta
                double precioN = Convert.ToDouble(dato.Precio.ToString());
                double cantidadN = Convert.ToDouble(dato.Cantidad.ToString());
                montoTotal = montoTotal + (precioN * cantidadN);




                e.Graphics.DrawString(dato.Cantidad.ToString()
                + "  |   " + dato.Nombre.ToString().Substring(0, dato.Nombre.Length > 30 ? 30 : dato.Nombre.Length), fuente, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("|$" + dato.Precio.ToString(), fuente, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);

            }


            e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("PRODUCTOS:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("—————————————————————", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Total:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString(montoTotal.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
            e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Pago con:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Su cambio:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("GRACIAS POR SU VISITA", font, Brushes.Black, new RectangleF(25, y += 20, ancho, 20));
            e.Graphics.DrawString("HASTA PRONTO", font, Brushes.Black, new RectangleF(70, y += 20, ancho, 20));

        }

    }
   
}

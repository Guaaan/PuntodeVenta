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
    class clsImprimir
    {
        public static string documc = "";
        private string comsql1, comsql2;
        public static string vnum;
        public static SqlConnection cn, locn;
        SqlCommand com;
        SqlDataReader Dr;


        public PrintPageEventHandler CargarImprimir(DataGridView dgVariable, PrintDocument impresiondocument, string documc, string tipo)
        {
            impresiondocument = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            impresiondocument.PrinterSettings = ps;
            impresiondocument.PrintPage += Imprimir;
            impresiondocument.Print();
            void Imprimir(object sender, PrintPageEventArgs e)
            {
                
                    /*string comsql = "SELECT M.CODIGO,M.DESCRIP NOMBRE,E.CANTIDAD STOCK,CONVERT(numeric(10,0),ROUND(M.MONTO*1.19,-1)) PRECIO1,CONVERT(numeric(10,0),ROUND(I.PRECIO2*1.19,-1)) PRECIO2,I.PRINCIPIO,I.FOTO FROM dbo.MFACTURAS M LEFT JOIN INVENTARIO I ON I.CODIGO=M.CODIGO LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE M.NUMERO = '" + documc + "' ORDER BY M.POSI";
                    cn = Form1.cn;
                    com = new SqlCommand(comsql, cn);
                    TicketDatos tDatos = new TicketDatos();
                    List<TicketDatos> lista = new List<TicketDatos>();
                    com.ExecuteNonQuery();
                    Dr = com.ExecuteReader();*/


                    Font titulo = new Font("Arial", 16, System.Drawing.FontStyle.Bold);
                    Font header = new Font("Courier", 14);
                    Font linea = new Font("Courier", 14);
                    Font font = new Font("Courier", 11);
                    Font fuente = new Font("Courier", 8);
                    int y = 20;
                    int ancho = 270;

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

                    //header
                    e.Graphics.DrawString("FARMACIAS GEMINIS", titulo, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                    e.Graphics.DrawString("———Punto de Venta———", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20),alineadoCentro);
                    e.Graphics.DrawString("Rut: " + Form1.erif, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString("Fecha: " + DateTime.Now.ToString(), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString("Caja: " + iniciarSesion.ucodigo, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString(tipo, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString("———Productos———", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(LineEncabezado, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString("Valor", font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                    e.Graphics.DrawString("   ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

                double montoTotal = 0;
                foreach (DataGridViewRow row in dgVariable.Rows)
                {

                    
                        if (dgVariable.Columns.Contains("LINEA1"))
                        {
                            TicketDatos dato = new TicketDatos();
                            //dato.Codigo = row.Cells["codigo"].Value.ToString();
                            dato.Nombre = row.Cells["PRODUCTO1"].Value.ToString();
                            dato.Cantidad = row.Cells["CANTIDAD1"].Value.ToString();
                            dato.Precio = row.Cells["PRECIO1"].Value.ToString();
                            //obtener el total de la boleta

                            double precioN = Convert.ToDouble(dato.Precio.ToString());
                            double cantidadN = Convert.ToDouble(dato.Cantidad.ToString());
                            montoTotal = montoTotal + (precioN * cantidadN);

                            e.Graphics.DrawString(dato.Cantidad.ToString()
                            + "  |   " + dato.Nombre.ToString().Substring(0, dato.Nombre.Length > 30 ? 30 : dato.Nombre.Length), fuente, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                            e.Graphics.DrawString("|$" + dato.Precio.ToString(), fuente, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);

                        }
                        else if (dgVariable.Columns.Contains("numero"))
                        {
                            TicketDatos dato = new TicketDatos();
                            dato.Nombre = row.Cells["producto"].Value.ToString();
                            dato.Cantidad = row.Cells["cantidad"].Value.ToString();
                            dato.Precio = row.Cells["precio"].Value.ToString();
                            double precioN = Convert.ToDouble(dato.Precio.ToString());
                            double cantidadN = Convert.ToDouble(dato.Cantidad.ToString());
                            montoTotal = montoTotal + (precioN * cantidadN);
                            if (row.Cells["numero"].Value.ToString() == documc)
                            {
                                e.Graphics.DrawString(dato.Cantidad.ToString()
                                + "  |   " + dato.Nombre.ToString().Substring(0, dato.Nombre.Length > 30 ? 30 : dato.Nombre.Length), fuente, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                                e.Graphics.DrawString("|$" + dato.Precio.ToString(), fuente, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                            }
                        }
                    //agregar total de la boleta
                    

                    
                }

                //----fin del header
                       
                           


                    e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    //e.Graphics.DrawString("PRODUCTOS:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString("————————————————————————", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                    e.Graphics.DrawString("Total:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString(montoTotal.ToString(), font, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);
                    e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString("GRACIAS POR SU VISITA", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("HASTA PRONTO", linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);


            }


            return Imprimir;
            
        }
    }
}
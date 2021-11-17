using System;
using System.Collections.Generic;
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


        public PrintPageEventHandler CargarImprimir(PrintDocument impresiondocument, string documc)
        {
            void Imprimir(object sender, PrintPageEventArgs e)
            {
                /*if (documc != "")
                {*/
                    string comsql1 = "SELECT M.CODIGO,M.DESCRIP NOMBRE,E.CANTIDAD STOCK,CONVERT(numeric(10,0),ROUND(M.MONTO*1.19,-1)) PRECIO1,CONVERT(numeric(10,0),ROUND(I.PRECIO2*1.19,-1)) PRECIO2,I.PRINCIPIO,I.FOTO ";
                    string comsql2 = "FROM dbo.MFACTURAS M LEFT JOIN INVENTARIO I ON I.CODIGO=M.CODIGO LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE M.NUMERO = '" + documc + "' ORDER BY M.POSI";
                    string comsql = comsql1 + comsql2;
                    cn = Form1.cn;
                    com = new SqlCommand(comsql, cn);
                    TicketDatos tDatos = new TicketDatos();
                    List<TicketDatos> lista = new List<TicketDatos>();

                    com.ExecuteNonQuery();
                    Dr = com.ExecuteReader();

                    /*while (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            tDatos.Codigo = Dr.GetString(0);
                            tDatos.Nombre = Dr.GetString(1);
                            tDatos.Precio = Dr.GetString(3);
                            tDatos.Cantidad = Dr.GetString(4);
                            lista.Add(tDatos); 

                        }
                        Dr.Close();
                    }*/
                    
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
                        while (Dr.HasRows)
                        {
                            while (Dr.Read())
                            {
                                tDatos.Codigo = Dr.GetString(0);
                                tDatos.Nombre = Dr.GetString(1);
                                tDatos.Precio = Dr.GetString(3);
                                tDatos.Cantidad = Dr.GetString(4);
                                lista.Add(tDatos);
                                
                                double precioN = Convert.ToDouble(tDatos.Precio.ToString());
                                double cantidadN = Convert.ToDouble(tDatos.Cantidad.ToString());
                                montoTotal += (precioN * cantidadN);
                                e.Graphics.DrawString(tDatos.Cantidad.ToString()
                                + "  |   " + tDatos.Nombre.ToString().Substring(0, tDatos.Nombre.Length > 30 ? 30 : tDatos.Nombre.Length), fuente, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                                e.Graphics.DrawString("|$" + tDatos.Precio.ToString(), fuente, Brushes.Black, new RectangleF(0, y += -5, ancho, 20), formato2);

                            }
                        }
                        Dr.Close();
                        //agregar total de la boleta


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

                //}
                    impresiondocument = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    impresiondocument.PrinterSettings = ps;
                    impresiondocument.PrintPage += Imprimir;
                
            }
            return CargarImprimir(impresiondocument, documc);
            //void llamaImprimir()
            //{
            //    impresiondocument = new PrintDocument();
            //    PrinterSettings ps = new PrinterSettings();
            //    impresiondocument.PrinterSettings = ps;
            //    impresiondocument.PrintPage += Imprimir;
            //}
                //return llamaImprimir();
        }
    }
}
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
    //ESPACIADO
    //e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
    class ClsImprimirCierre
    {
        public static SqlConnection cn, locn;
        SqlCommand com;
        SqlDataReader Dr;
        public PrintPageEventHandler imprimirCierre(PrintDocument impresiondocument /*List< listaej*/)
        {
                string comsql = "SELECT [FECHA], [CONCEPTO], [MONTO] FROM [RECIBOS] WHERE FECHA >= CONVERT(DATETIME, '2021-11-24', 102) AND FECHA < CONVERT(DATETIME, '2021-11-25', 102) AND CODIGO IN ('62', '02', '29', '38', '63') ORDER BY CONCEPTO, FECHA DESC";
                cn = Form1.cn;
                com = new SqlCommand(comsql, cn);
                com.ExecuteNonQuery();
                Dr = com.ExecuteReader();
                
                //List<Egreso> egresos = new List<Egreso>();


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
                int de500 = 1;
                int de100 = 1;
                int de50 = 1;
                int de10 = 1;
                int totalBilletes = de20Mil + de10Mil + de5Mil + de2Mil + deMil + de500 + de100 + de50 + de10;

                int aperturaCaja = 50000;
                int ventasEfectivo = 50000;
                int otrosIngresos = 0;
                int totalEfectivo = ventasEfectivo + otrosIngresos;

                int credito = 0;
                int arqueoCredito = 0;
                int resultadoCredito = credito - arqueoCredito;

                int debito = 0;
                int arqueoDebito = 1230;
                int resultadoDebito = debito - arqueoDebito;

                int transferencias = 0;
                int arqueoTransf = 0;
                int resultadoTransf = transferencias - arqueoTransf;

                int difTarjetas = arqueoCredito + arqueoDebito + arqueoTransf;
                int totalDigitales = credito + debito + transferencias;

                int totalVentas = totalDigitales + totalEfectivo;
                int egresosCaja = 312;
                int remesas = 2;

                int efectivoFinal = totalEfectivo + difTarjetas;
                int arqueodeCaja = 32;
                int DiferenciaFinal = efectivoFinal - arqueodeCaja;

                

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
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                //billetes
                e.Graphics.DrawString("De 20.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de20Mil.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("De 10.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de10Mil.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("De 5.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de5Mil.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("De 2.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de2Mil.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("De 1.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(deMil.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("De 500 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de500.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("De 100 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de100.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("De 50 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de50.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("De 10 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(de10.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                //fin de los billetes
                e.Graphics.DrawString("Total: ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalBilletes.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //----------------------------------//
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                //e.Graphics.DrawString("Transferencias", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Cierre de caja", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(iniciarSesion.unombre.Trim(), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Ventas del día " + DateTime.Now.ToString("dd"), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Entrada en efectivo", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                //----------------------------------//
                e.Graphics.DrawString("Apertura de Caja:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(aperturaCaja.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Ventas Efectivo:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(ventasEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Otros Ingresos:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(otrosIngresos.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                //total 
                e.Graphics.DrawString("Total Ingresos:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                //----------------------------------//
                //fin efectivo
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString("Entrada en Tarjetas", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));

                e.Graphics.DrawString("Débito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(debito.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Arqueo Débito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(arqueoDebito.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(resultadoDebito.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);

                e.Graphics.DrawString("Crédito", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(credito.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Arqueo Crédito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(arqueoCredito.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(resultadoCredito.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);

                e.Graphics.DrawString("Transferencia:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(transferencias.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("arqueo Transferencia:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(arqueoTransf.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(resultadoTransf.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                e.Graphics.DrawString("Total Tarjetas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalDigitales.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                //fin tarjetas
                e.Graphics.DrawString("Total Ventas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalVentas.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //
                
                e.Graphics.DrawString("Egresos", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);

                //agregar acá los egresos de manera dinamica//
                while (Dr.Read())
                {

                    Egreso eg = new Egreso();

                    //var concept = Dr.GetString(1); //The 0 stands for "the 0'th column", so the first column of the result.
                    //var amount = Dr.GetString(2); //The 0 stands for "the 0'th column", so the first column of the result.
                
                    eg.Concepto = Dr.GetString(1);
                    eg.Monto = Dr.GetDecimal(2);

                    
                    e.Graphics.DrawString(eg.Concepto, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                    e.Graphics.DrawString(eg.Monto.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);



                }
                Dr.Close();
                



                ///////////////////////////////////////////////
                e.Graphics.DrawString("Dinero en Caja", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("Entrada Efectivo:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Egresos de Caja:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(egresosCaja.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Depositos/remesas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(remesas.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Dif en Tarjetas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(difTarjetas.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                e.Graphics.DrawString("Total Efectivo:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(efectivoFinal.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Arqueo de Caja:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("-" + arqueodeCaja.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                e.Graphics.DrawString("Diferencia:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(DiferenciaFinal.ToString(), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
            }
            return Imprimir;
        }
    }
}

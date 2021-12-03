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
        public static SqlConnection cn;
        SqlCommand com;
        SqlDataReader Dr;
        public PrintPageEventHandler imprimirCierre(PrintDocument impresiondocument, decimal efectivoIngresado, decimal tarjetasIngresadas, decimal transferenciasIngresadas)
        {
            //List<Egreso> egresos = new List<Egreso>();


            impresiondocument = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            impresiondocument.PrinterSettings = ps;
            impresiondocument.PrintPage += Imprimir;
            impresiondocument.Print();
            void Imprimir(object sender, PrintPageEventArgs e)
            {

                //var fechaE1 = DateTime.Today.ToString("yyyyMMdd");
                //var fechaE2 = DateTime.Today.AddDays(1).ToString("yyyyMMdd"); 
                
                var fechaE1 = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");
                var fechaE2 = DateTime.Today.ToString("yyyyMMdd");
                var caja = iniciarSesion.ucaja.Trim();
                //string comsql = 
                //"SELECT top 1 FECHADESDE,FECHAHASTA,MONTO,MONTO1,MONTO2,MONTO4,MONTO8,MONTO9,MONTO12,DIFERENCIA,monto14,monto15,monto16,monto18,MONTO20 FROM SAES_ADMINISTRATIVOFD.dbo.ARQUEO where FECHADESDE >= CONVERT(DATETIME, '" + fechaE1 + "', 102) and FECHAHASTA < CONVERT(DATETIME, '" + fechaE2 + "', 102) order by FECHADESDE DESC;" +
                //"SELECT [FECHA], [CONCEPTO], [MONTO] FROM [RECIBOS] WHERE CAJA = '"+ 15 + "'AND FECHA >= CONVERT(DATETIME, '" + fechaE1 + "', 102) AND FECHA < CONVERT(DATETIME, '" + fechaE2 + "', 102) AND CODIGO IN ('62', '02', '29', '38', '63') ORDER BY CONCEPTO, FECHA DESC";

                string comsql =
                "SELECT top 1 FECHADESDE,FECHAHASTA,MONTO,MONTO1,MONTO2,MONTO4,MONTO8,MONTO9,MONTO12,DIFERENCIA,monto14,monto15,monto16,monto18,MONTO20 FROM ARQUEO where CAJA = "+ caja + "AND FECHADESDE >= CONVERT(DATETIME, '" + fechaE1 + "', 102) and FECHAHASTA < CONVERT(DATETIME, '" + fechaE2 + "', 102) order by FECHADESDE DESC;" +
                "SELECT [FECHA], [CONCEPTO], [MONTO] FROM [RECIBOS] WHERE CAJA = '" + caja + " 'AND FECHA >= CONVERT(DATETIME, '" + fechaE1 + "', 102) AND FECHA < CONVERT(DATETIME, '" + fechaE2 + "', 102) AND CODIGO IN ('62', '02', '29', '38', '63') ORDER BY CONCEPTO, FECHA DESC";


                cn = Form1.cn;
                com = new SqlCommand(comsql, cn);
                com.ExecuteNonQuery();
                Dr = com.ExecuteReader();

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
                
                
                Dr.Read();
                
                decimal totalVentas = Dr.GetDecimal(2);
                decimal diferencia = Dr.GetDecimal(9);
                decimal arqueoDebito = Dr.GetDecimal(7);
                decimal arqueoCredito = Dr.GetDecimal(6);
                decimal arqueoTarjetas = arqueoDebito + arqueoCredito;
                decimal arqueoTransf = Dr.GetDecimal(8);
                decimal arqueo = Dr.GetDecimal(2);


                //int de20Mil = 1;
                //int de10Mil = 1;
                //int de5Mil = 1;
                //int de2Mil = 1;
                //int deMil = 1;
                //int de500 = 1;
                //int de100 = 1;
                //int de50 = 1;
                //int de10 = 1;
                //int totalBilletes = de20Mil + de10Mil + de5Mil + de2Mil + deMil + de500 + de100 + de50 + de10;

                decimal aperturaCaja = 50000;
                decimal ventasEfectivo = 50000;
                decimal otrosIngresos = 0;
                decimal totalEfectivo = ventasEfectivo + otrosIngresos;

                decimal credito = 0;
                //decimal arqueoCredito = 0;
                //decimal resultadoCredito = credito - arqueoCredito;

                decimal debito = 0;
                //decimal arqueoDebito = 1230;
                decimal resultadoDebito = debito - arqueoDebito;

                decimal resultadoTarjetas = tarjetasIngresadas - (arqueoDebito + arqueoCredito);

                decimal transferencias = 0;
                //decimal arqueoTransf = 0;
                decimal resultadoTransf = transferenciasIngresadas - arqueoTransf;

                decimal difTarjetas = arqueoCredito + arqueoDebito + arqueoTransf;
                decimal totalDigitales = credito + debito + transferencias;

                //decimal totalVentas = totalDigitales + totalEfectivo;
                //decimal egresosCaja = 312;
                decimal remesas = 2;

                decimal efectivoFinal = totalEfectivo + difTarjetas;
                decimal arqueodeCaja = 0;
                decimal DiferenciaFinal = efectivoFinal - arqueodeCaja;




                StringFormat formato1 = new StringFormat(StringFormatFlags.NoClip);
                StringFormat formato2 = new StringFormat(formato1);
                string NombLoc = Form1.nombreFarmacia;
                formato1.LineAlignment = StringAlignment.Near;
                formato1.Alignment = StringAlignment.Center;
                formato2.LineAlignment = StringAlignment.Center;
                formato2.Alignment = StringAlignment.Far;
                //header
                e.Graphics.DrawString("FARMACIAS GEMINIS", titulo, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                //e.Graphics.DrawString(totalVentas.ToString(), titulo, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString(NombLoc, linea, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Rut: " + Form1.erif, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 2, ancho, 20));
                e.Graphics.DrawString(Date, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("hora: " + hora, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                //billetes (aunque ya no sean necesarios)
                //e.Graphics.DrawString("De 20.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(de20Mil.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("De 10.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(de10Mil.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("De 5.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(de5Mil.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("De 2.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(de2Mil.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("De 1.000 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(deMil.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("De 500 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(de500.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("De 100 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(de100.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("De 50 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(de50.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("De 10 =", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(de10.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //-------------e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                //fin de los billetes
                e.Graphics.DrawString("Efectivo Ingresado: ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(efectivoIngresado.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
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
                e.Graphics.DrawString(aperturaCaja.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Ventas Efectivo:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(efectivoIngresado.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Otros Ingresos:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(otrosIngresos.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                //total 
                e.Graphics.DrawString("Total Ingresos:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                //----------------------------------//
                //fin efectivo
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));
                e.Graphics.DrawString("Entrada en Tarjetas", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 5, ancho, 20));

                e.Graphics.DrawString("Tarjetas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(tarjetasIngresadas.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Arqueo Tarjetas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(arqueoTarjetas.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(resultadoDebito.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);

                //e.Graphics.DrawString("Débito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(Debito.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("Arqueo Débito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(arqueoDebito.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(resultadoDebito.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);

                //e.Graphics.DrawString("Crédito", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(credito.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString("Arqueo Crédito:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(arqueoCredito.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(resultadoCredito.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);

                e.Graphics.DrawString("Transferencias:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(transferenciasIngresadas.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Arqueo Transferencias:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(arqueoTransf.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(resultadoTransf.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                e.Graphics.DrawString("Total Tarjetas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalDigitales.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString(" ", espaciado, Brushes.Black, new RectangleF(0, y += 15, ancho, 20));
                //fin tarjetas
                e.Graphics.DrawString("Total Ventas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalVentas.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //
                decimal totalEgresos = 0;
                Dr.NextResult();
                if (Dr.HasRows)
                {
                    e.Graphics.DrawString("Egresos", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);

                    //agregar acá los egresos de manera dinamica//
                    while (Dr.Read())
                    {
                        Egreso eg = new Egreso();
                        eg.Concepto = Dr.GetString(1);
                        eg.Monto = Dr.GetDecimal(2);

                        totalEgresos = totalEgresos + eg.Monto;

                        e.Graphics.DrawString(eg.Concepto, fuente, Brushes.Black, new RectangleF(0, y += 35, anchob, 35));
                        e.Graphics.DrawString(eg.Monto.ToString("C"), fuente, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                    }
                    Dr.Close();
                }



                ///////////////////////////////////////////////
                e.Graphics.DrawString(" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("Dinero en Caja", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), alineadoCentro);
                e.Graphics.DrawString("Entrada Efectivo:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEfectivo.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Egresos de Caja:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(totalEgresos.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Depositos/remesas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(remesas.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Dif en Tarjetas:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(resultadoTarjetas.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                //
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                e.Graphics.DrawString("Total Efectivo:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(efectivoFinal.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("Arqueo de Caja:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString("-" + arqueodeCaja.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
                e.Graphics.DrawString("――――――――――――――――――――――――――――――", linea, Brushes.Black, new RectangleF(0, y += 25, ancho, 20));
                e.Graphics.DrawString("Diferencia:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                e.Graphics.DrawString(DiferenciaFinal.ToString("C"), font, Brushes.Black, new RectangleF(0, y, ancho, 20), formato2);
            }
            return Imprimir;
        }
    }
}

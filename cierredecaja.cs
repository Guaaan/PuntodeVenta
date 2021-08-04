using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Drawing.Printing;

namespace ptoVenta
{
    public partial class cierredecaja : Form
    {
        SqlCommand com;
        SqlDataReader dr;

        private DateTime fec1 = DateTime.Now;
        private DateTime fec2 = DateTime.Now;
        private string comsql1, comsql2;
        private string caja = iniciarSesion.ucaja.Trim(), cajero = iniciarSesion.unombre.Trim();
        private double mont = 0, efec = 0, debt = 0, cred = 0, tran = 0, abon = 0, vuel = 0 ;

        public cierredecaja()
        {
            InitializeComponent();
        }

        private void cierredecaja_Load(object sender, EventArgs e)
        {
            totalventas();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fec1 = dateTimePicker1.Value;
            totalventas();
        }

        private void totalventas()
        {
            fec1 = dateTimePicker1.Value;
            fec2 = fec1.AddDays(+1);
            string f1 = fec1.ToString("yyyyMMdd");
            string f2 = fec2.ToString("yyyyMMdd");
            comsql1 = "SELECT F.NOMBRE CONCEPTO,F.NUMERO,F.IMPSERIAL,F.IMPUESTO,F.MONTO,F.TIPO,F.ABONO,R.TIPO,R.RECIBO,F.FECHA,R.CAJA,R.EFECTIVO,R.CHEQUE,R.DEBITO,R.CREDITO,R.OTROS,R.FACTURA,R.VUELTO,F.REGISTRO ";
            comsql2 = comsql1 + " FROM FACTURAS F LEFT JOIN RECIBOS R ON R.NUMERO = F.NUMERO AND F.ABONO = F.MONTO + F.IMPUESTO WHERE F.REGISTRO = 0 AND F.CAJAPERTUR = '"+caja+"' AND F.FECHA>='"+f1+"' AND F.FECHA<'"+f2+"'";
            com = new SqlCommand(comsql2, Form1.cn); 
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            int fila = 0;
            while (dr.Read())
            {
                fila += 1;
                mont = mont + (dr["MONTO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["MONTO"]));
                efec = efec + (dr["EFECTIVO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["EFECTIVO"]));
                debt = debt + (dr["DEBITO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["DEBITO"]));
                cred = cred + (dr["CREDITO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["CREDITO"]));
                tran = tran + (dr["OTROS"] == DBNull.Value ? 0 : Convert.ToDouble(dr["OTROS"]));
                abon = abon + (dr["ABONO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["ABONO"]));
                vuel = vuel + (dr["VUELTO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["VUELTO"]));
            }
            dr.Close();
            textBox1.Text = fila.ToString("N0");
        }

        private void txtEfectivo_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("^(a)");
        }

        private void txtDebito_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("^(a)");
        }

        private void txtCredito_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("^(a)");
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("DESEA USTED PROCESAR CIERRE DE CAJA", "CONFIRMAR CIERE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                fec1 = dateTimePicker1.Value;
                fec2 = fec1.AddDays(+1);
                string f1 = fec1.ToString("yyyyMMdd");
                string f2 = fec2.ToString("yyyyMMdd");
                DateTime fecd = DateTime.Now;
                DateTime fech = DateTime.Now;
                double me = Convert.ToDouble(txtEfectivo.Text);
                double md = Convert.ToDouble(txtDebito.Text);
                double mc = Convert.ToDouble(txtCredito.Text);
                double ta = (me + md + mc);
                double di = ta - mont;

                com = new SqlCommand("SELECT TOP 1 FECHA FROM RECIBOS WHERE REGISTRO = 0 AND FECHA>'" + f1 + "' AND FECHA<'" + f2 + "' AND CAJA='" + caja + "' ORDER BY FECHA", Form1.cn);
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    fecd = Convert.ToDateTime(dr["FECHA"]);
                }
                dr.Close();
                com = new SqlCommand("SELECT TOP 1 FECHA FROM RECIBOS WHERE REGISTRO = 0 AND FECHA > '" + f1 + "' AND FECHA < '" + f2 + "' AND CAJA = '" + caja + "' ORDER BY FECHA DESC", Form1.cn);
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    fech = Convert.ToDateTime(dr["FECHA"]);
                }
                dr.Close();

                com = new SqlCommand("SELECT * FROM ARQUEO WHERE FECHADESDE='" + fecd + "' AND CAJA='" + caja + "'", Form1.cn);
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                int arqueosi = 0;
                while (dr.Read())
                {
                    arqueosi = Convert.ToInt32(dr["REGISTRO"]);
                }
                dr.Close();
                if (arqueosi == 0)
                {
                    comsql1 = "INSERT INTO ARQUEO (FECHADESDE,FECHAHASTA,CAJA,NOMBRE,MONTO,MONTOA,DIFERENCIA,MONTO7,MONTO9,MONTO8,AUDITOR,FECHA,TURNO) ";
                    comsql1 = comsql1 + " VALUES (@fd,@fh,@caj,@nom,@mon,@mona,@mond,@mon7,@mon9,@mon8,@audi,@fech,@cerr)";
                }
                else
                {
                    comsql1 = "UPDATE ARQUEO SET FECHADESDE=@fd,FECHAHASTA=@fh,CAJA=@caj,NOMBRE=@nom,MONTO=@mon,MONTOA=@mona,DIFERENCIA=@mond,MONTO7=@mon7,";
                    comsql1 = comsql1 + " MONTO9=@mon9,MONTO8=@mon8,AUDITOR=@audi,FECHA=@fech,TURNO=@cerr WHERE REGISTRO = " +arqueosi ;
                }
                com = new SqlCommand(comsql1, Form1.cn);

                com.Parameters.AddWithValue("@fd", fecd);
                com.Parameters.AddWithValue("@fh", fech);
                com.Parameters.AddWithValue("@caj", caja);
                com.Parameters.AddWithValue("@nom", cajero);
                com.Parameters.AddWithValue("@mona", Convert.ToDouble(ta));
                com.Parameters.AddWithValue("@mond", Convert.ToDouble(di));
                com.Parameters.AddWithValue("@mon", Convert.ToDouble(mont));
                com.Parameters.AddWithValue("@mon7", Convert.ToDouble(txtEfectivo.Text));
                com.Parameters.AddWithValue("@mon9", Convert.ToDouble(txtDebito.Text));
                com.Parameters.AddWithValue("@mon8", Convert.ToDouble(txtCredito.Text));
                com.Parameters.AddWithValue("@audi", cajero);
                com.Parameters.AddWithValue("@fech", DateTime.Now);
                com.Parameters.AddWithValue("@cerr", "CERRADO");
                com.ExecuteNonQuery();

                com = new SqlCommand("UPDATE FACTURAS SET REGISTRO=" + arqueosi + " WHERE REGISTRO=0 AND STATUS=2 AND FECHA>='" + f1 + "' AND FECHA<'" + f2 + "' AND CAJAPERTUR = '" + caja + "'", Form1.cn);
                com.ExecuteNonQuery();
                com = new SqlCommand("UPDATE RECIBOS  SET REGISTRO=" + arqueosi + " WHERE REGISTRO=0 AND STATUS=0 AND FECHA>='" + f1 + "' AND FECHA<'" + f2 + "' AND CAJA = '" + caja + "' ", Form1.cn);
                com.ExecuteNonQuery();
                com = new SqlCommand("UPDATE CREDITOS SET REGISTRO=" + arqueosi + " WHERE REGISTRO=0 AND STATUS=0 AND FECHA>='" + f1 + "' AND FECHA<'" + f2 + "' AND CAJA = '" + caja + "' ", Form1.cn);
                com.ExecuteNonQuery();
                string vuser = iniciarSesion.ucodigo.Trim();
                com = new SqlCommand("UPDATE USUARIOS SET FORMATO = '' WHERE CODIGO = '" + vuser + "' ", Form1.cn);
                com.ExecuteNonQuery();
                // IMPRIME CIERRE
                MessageBox.Show("CIERRE DE CAJA SATISFACTORIO");
                Application.Exit();
                this.Close();
            }

            printCierre = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printCierre.PrinterSettings = ps;
            printCierre.PrintPage += Imprimir;
            printCierre.Print();
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 11);
            Font header = new Font("Arial", 14);
            Font fuente = new Font("Arial", 8);
            int ancho = 300;
            int y = 20;
            


            //header
            e.Graphics.DrawString("FARMACIAS GEMINIS", header, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

            e.Graphics.DrawString("LOCAL: ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToString(), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Caja: " + iniciarSesion.ucodigo, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("———————————————", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //----fin del header
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));




            e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("PRODUCTOS:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("———————————————", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Total:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Pago con:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Su cambio:", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                    ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("GRACIAS POR SU VISITA", font, Brushes.Black, new RectangleF(10, y += 20, ancho, 20));
            e.Graphics.DrawString("HASTA PRONTO", font, Brushes.Black, new RectangleF(45, y += 20, ancho, 20));

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

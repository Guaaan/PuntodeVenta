using System;
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

namespace ptoVenta
{
    public partial class cierreBoleta : Form
    {

        SqlCommand com;
        SqlDataReader dr;

        private int tf, te, td, tc, tt, tp, ta, tv;

        public cierreBoleta()
        {
            InitializeComponent();
            txtTotal.Text = Form1.totf.ToString("N0");
            txtSubTotal.Text = Form1.tots.ToString("N0");
            txtIva.Text = Form1.toti.ToString("N0");
            textBox1.Text = Form1.totp.ToString("N0");
            int toto = Form1.totp - Form1.totf;
            textBox2.Text = toto.ToString("N0");
        }

        private void cierreBoleta_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM USUARIOS ORDER BY NOMBRE", Form1.cn);
            da.Fill(ds, "USUARIOS");
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.ValueMember = "CODIGO";
        }

        private void calculaBoleta()
        {

            if (string.IsNullOrEmpty(txtEfectivo.Text))
            {
                txtEfectivo.Text = "0";
            }
            if (string.IsNullOrEmpty(txtDebito.Text))
            {
                txtDebito.Text = "0";
            }
            if (string.IsNullOrEmpty(txtCredito.Text))
            {
                txtCredito.Text = "0";
            }
            if (string.IsNullOrEmpty(txtTransferencia.Text))
            {
                txtTransferencia.Text = "0";
            }
            tf = Form1.totf;
            te = (int)Convert.ToInt32(txtEfectivo.Text);
            td = (int)Convert.ToInt32(txtDebito.Text);
            tc = (int)Convert.ToInt32(txtCredito.Text);
            tt = (int)Convert.ToInt32(txtTransferencia.Text);
            tp = te + td + tc + tt;
            ta = tf - tp;
            tv = tp - tf;
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }
        }

        private void txtDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }
        }

        private void txtTransferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }

        }

        private void iconButton1_Enter(object sender, EventArgs e)
        {
            calculaBoleta();
            if (tp == 0)
            {
                txtEfectivo.Focus();
                SendKeys.Send("^(a)");
            }
        }

        private void cierraBoleta()
        {
            InitializeComponent();
            string rec = "";
            string num = "";
            com = new SqlCommand("SELECT MAX(convert(int, RECIBO))+1 REXP FROM RECIBOS WHERE TIPO=1", Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                rec = Convert.ToString(dr["REXP"]);
            }
            dr.Close();

            //FACTURAS
            if (Form1.documc != "")
            {
                num = Form1.documc;
                com = new SqlCommand("DELETE FACTURAS WHERE NUMERO='"+ Form1.documc + "'",Form1.cn);
                com.ExecuteNonQuery();
                com = new SqlCommand("DELETE MFACTURAS WHERE NUMERO='" + Form1.documc + "'", Form1.cn);
                com.ExecuteNonQuery();
            }
            else
            {
                com = new SqlCommand("SELECT MAX(convert(int, NUMERO))+1 REXP FROM FACTURAS", Form1.cn);
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    num = Convert.ToString(dr["REXP"]);
                }
                dr.Close();
            }

            string nom = Form1.nombre.Trim();
            string con = "CANCELACION DE FATURA ";

            string sqlcom1 = "INSERT INTO RECIBOS (CODIGO,RECIBO,FECHA,NOMBRE,CONCEPTO,IVA,CAJA,MONTO,NUMERO,RIF,DIRECCION,TELEFONOS,TIPO,EFECTIVO,DEBITO,CREDITO,OTROS,VUELTO) ";
            string sqlcom2 = "VALUES ('CF','" + rec + "', '" + DateTime.Now + "','" + nom + "','" + con + "'," + 19 + ",'" + iniciarSesion.ucaja + "',";
            string sqlcom3 = Form1.totf + ",'" + num + "','" + Form1.rut + "','" + Form1.direccion + "','" + Form1.telefono + "'," + 1 + "," + te + "," + td + "," + tc + "," + tc + "," + (tp - Form1.totf) + ") ";

            string sqlcom = sqlcom1 + sqlcom2 + sqlcom3;

            com = new SqlCommand(sqlcom, Form1.cn);
            com.ExecuteNonQuery();

            int des;
            DateTime mfec = DateTime.Now;
            des = Form1.totp - Form1.totf;

            //FACTURA
            sqlcom1 = "INSERT INTO FACTURAS (MARCA,NUMERO,CODIGO,FECHA,MONTO,DESCUENTO,ABONO,IVA,IMPUESTO,CAJAPERTUR,RECIBO,STATUS) ";
            sqlcom2 = "VALUES ('GEMINIS','" + num + "','CONTADO','" + DateTime.Now + "'," + Form1.tots + "," + des + "," + tp + "," + 19 + ",";
            sqlcom3 = Form1.toti + ",'" + iniciarSesion.ucaja + "', '" + rec + "'," + 2 + ") ";

            sqlcom = sqlcom1 + sqlcom2 + sqlcom3;

            com = new SqlCommand(sqlcom, Form1.cn);
            com.ExecuteNonQuery();

            //MFACTURAS
            Form1 FRM1 = Owner as Form1;
            int mfila = 0;
            string mcod, mnom, mnum,malm, mgru = "";
            double mcan, msto, mofe, mtot, mtpr, mmon, mcid = 0;
            double mcos = 0;
            double mp1 = 0;
            double mp2 = 0;
            double mdes = 0;
            double mpre, mpr1,mpsi;

            foreach (DataGridViewRow row in FRM1.dgvGrid1.Rows)
            {
                if (row.Cells["CODIGO1"].Value != null)
                {
                    mfila += 1;
                    mcod = row.Cells["CODIGO1"].Value.ToString();
                    mnom = row.Cells["PRODUCTO1"].Value.ToString();
                    malm = row.Cells["ALMACEN1"].Value.ToString();
                    msto = Convert.ToInt32(row.Cells["STOCK1"].Value.ToString());
                    mcan = Convert.ToInt32(row.Cells["CANTIDAD1"].Value.ToString());
                    mpre = Convert.ToDouble(row.Cells["PRECIO1"].Value.ToString());
                    mpr1 = mpre;
                    mofe = Convert.ToInt32(row.Cells["OFERTA1"].Value.ToString());
                    if (mofe > 0 && mcan > 1)
                    {
                        mpre = mofe;
                    }
                    mtot = mcan * mpre;
                    mtpr = mcan * mpr1;
                    mmon = mtot;
                    mnum = num;
                    mpsi = mpre / 1.19;

                    com = new SqlCommand("SELECT E.CANTIDAD STOCK,I.COSTO,I.PRECIO1,I.PRECIO2,I.GRUPO,E.CODID,E.ALMACEN FROM INVENTARIO I LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE I.CODIGO = '" + mcod + "' AND E.ALMACEN='" + malm + "'", Form1.cn);
                    com.ExecuteNonQuery();
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        mcos = Convert.ToDouble(dr["COSTO"]);
                        mp1 = Convert.ToDouble(dr["PRECIO1"]);
                        mp2 = dr["PRECIO2"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PRECIO2"]);
                        msto = dr["STOCK"] == DBNull.Value ? 0 : Convert.ToDouble(dr["STOCK"]);
                        mgru = Convert.ToString(dr["GRUPO"]);
                        malm = dr["ALMACEN"] == DBNull.Value ? Form1.alma :  Convert.ToString(dr["ALMACEN"]);
                        mcid = Convert.ToInt32(dr["CODID"]);

                    }
                    dr.Close();

                    if (mcan > 1 && mp2 > 0) {  mdes = (mp1 - mp2); }
                   
                    sqlcom1 = "INSERT INTO MFACTURAS (NUMERO,FECHA,POSI,IVA3,CODIGO,DESCRIP,COSTO,MONTO,CANTIDAD,GRUPO,IVA,CACTUAL,CODID,MONTOFINAL,PRECIOA,ALMACEN) ";
                    sqlcom2 = "VALUES (@num,@mfec,@mfila,@mdes,@mcod,@mnom,@mcos,@mpsi,@mcan,@mgru,@miva,@msto,@mcid,@mtot,@mp1,@malma)";
                    sqlcom = sqlcom1 + sqlcom2;
                    com = new SqlCommand(sqlcom, Form1.cn);
                    com.Parameters.AddWithValue("@num", num);
                    com.Parameters.AddWithValue("@mfec", mfec);
                    com.Parameters.AddWithValue("@mfila", mfila);
                    com.Parameters.AddWithValue("@mdes", mdes);
                    com.Parameters.AddWithValue("@mcod", mcod);
                    com.Parameters.AddWithValue("@mnom", mnom);
                    com.Parameters.AddWithValue("@mcos", mcos);
                    com.Parameters.AddWithValue("@mpsi", mpsi);
                    com.Parameters.AddWithValue("@mcan", mcan);
                    com.Parameters.AddWithValue("@mgru", mgru);
                    com.Parameters.AddWithValue("@miva", 1);
                    com.Parameters.AddWithValue("@msto", msto);
                    com.Parameters.AddWithValue("@mcid", mcid);
                    com.Parameters.AddWithValue("@mtot", mtot);
                    com.Parameters.AddWithValue("@mp1", mp1);
                    com.Parameters.AddWithValue("@malma",malm);
                    com.ExecuteNonQuery();
                }
            }
            // IMPRIME TICKECT
            clsImprimir prnt = new clsImprimir();
            prnt.CargarImprimir(FRM1.dgvGrid1, printDocumento, null, "Venta");
            FRM1.dgvGrid1.Rows.Clear();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtEfectivo.Text= Form1.totf.ToString();
            txtDebito.Text = "0";
            txtCredito.Text = "0";
            txtTransferencia.Text = "0";
            cButton1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDebito.Text = Form1.totf.ToString();
            txtEfectivo.Text = "0";
            txtCredito.Text = "0";
            txtTransferencia.Text = "0";
            cButton1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtCredito.Text = Form1.totf.ToString();
            txtEfectivo.Text = "0";
            txtDebito.Text = "0";
            txtTransferencia.Text = "0";
            cButton1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtTransferencia.Text = Form1.totf.ToString();
            txtEfectivo.Text = "0";
            txtDebito.Text = "0";
            txtCredito.Text = "0";
            cButton1.Focus();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (tp == 0)
            {
                txtEfectivo.Focus();
            }
            else
            {
                cierraBoleta();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cierreBoleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void txtEfectivo_Enter(object sender, EventArgs e)
        {
            calculaBoleta();
            SendKeys.Send("^(a)");
            te = tf - (tp - te);
            txtEfectivo.Text = te.ToString();
            if (te == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDebito_Enter(object sender, EventArgs e)
        {
            calculaBoleta();
            SendKeys.Send("^(a)");
            td = tf - (tp - td);
            if (td < 1)
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                txtDebito.Text = td.ToString();
            }
        }

        private void txtCredito_Enter(object sender, EventArgs e)
        {
            calculaBoleta();
            SendKeys.Send("^(a)");
            tc = tf - (tp - tc);
            if (tc < 1)
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                txtCredito.Text = tc.ToString();
            }
        }

        private void txtTransferencia_Enter(object sender, EventArgs e)
        {
            calculaBoleta();
            SendKeys.Send("^(a)");
            tt = tf - (tp - tt);
            if (tt < 1)
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
               txtTransferencia.Text = tt.ToString();
            }
        }

    }
}

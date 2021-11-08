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
using Microsoft.Reporting.WinForms;

namespace ptoVenta
{
    public partial class egresoCaja : Form
    {
        SqlCommand com;
        SqlDataReader dr;

        public egresoCaja()
        {
            InitializeComponent();
        }

        private void egresoCaja_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CONCEPTOS ORDER BY NOMBRE", Form1.cn);
            da.Fill(ds, "CONCEPTOS");
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.ValueMember = "NOMBRE";

            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM USUARIOS ORDER BY NOMBRE", Form1.cn);
            da2.Fill(ds2, "CLIENTES");
            comboBox2.DataSource = ds2.Tables[0].DefaultView;
            comboBox2.ValueMember = "NOMBRE";
            comboBox3.SelectedIndex=0;
            int index = comboBox2.FindString(iniciarSesion.unombre.Trim());
            comboBox2.SelectedIndex = index;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vcon = comboBox1.Text;
            com = new SqlCommand("SELECT TOP 1 * FROM CONCEPTOS WHERE NOMBRE= '" + vcon + "' ", Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = Convert.ToString(dr["CODIGO"]);
            }
            dr.Close();
            comboBox2.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vcon = comboBox2.Text;
            com = new SqlCommand("SELECT TOP 1 * FROM USUARIOS WHERE NOMBRE= '" + vcon + "' ", Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = Convert.ToString(dr["CODIGO"]);
            }
            dr.Close();
            txtEfectivo.Focus();
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            int mon = Convert.ToInt32(txtEfectivo.Text);
            string cod = textBox1.Text.ToString();
            string asi = textBox2.Text.ToString();
            string con = textBox3.Text.ToString();
            int tip;
            if (mon > 0 && !string.IsNullOrEmpty(cod) && !string.IsNullOrEmpty(asi) && !string.IsNullOrEmpty(con))
            {
                string rec = "";
                string tit = comboBox3.Text.Trim();
                if (tit == "EGRESO")
                {
                    com = new SqlCommand("SELECT MAX(convert(int, RECIBO))+1 REXP FROM RECIBOS WHERE TIPO=2", Form1.cn);
                    tip = 2;
                }
                else
                {
                    com = new SqlCommand("SELECT MAX(convert(int, RECIBO))+1 REXP FROM RECIBOS WHERE TIPO=1", Form1.cn);
                    tip = 1;
                }

                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    rec = Convert.ToString(dr["REXP"]);
                }
                dr.Close();
                string usu = iniciarSesion.ucodigo.Trim();
                string caj = iniciarSesion.ucaja.Trim();
                string nom = comboBox2.Text.ToString();
                string comsql1 = "INSERT INTO RECIBOS(RECIBO, FECHA, CODIGO, CONCEPTO, MONTO, USUARIO, CAJA, NOMBRE, TIPO, EFECTIVO, ASIGNADO) ";
                string sqlcom2 = comsql1 + "VALUES (@num,@mfec,@mcod,@mcon,@mmon,@musu,@mcaj,@mnom,@mtip,@mefe,@masi)";
                com = new SqlCommand(sqlcom2, Form1.cn);
                com.Parameters.AddWithValue("@num", rec);
                com.Parameters.AddWithValue("@mfec", dateTimePicker1.Value);
                com.Parameters.AddWithValue("@mcod", cod);
                com.Parameters.AddWithValue("@mcon", con);
                com.Parameters.AddWithValue("@mnom", nom);
                com.Parameters.AddWithValue("@musu", usu);
                com.Parameters.AddWithValue("@mcaj", caj);
                com.Parameters.AddWithValue("@mmon", mon);
                com.Parameters.AddWithValue("@mtip", tip);
                com.Parameters.AddWithValue("@mefe", mon);
                com.Parameters.AddWithValue("@masi", asi);
                com.ExecuteNonQuery();
                dr.Close();
                //Impresion de reci
                LocalReport report = new LocalReport();

                Form1.MiReporte = "Informes\\Reci.rdlc";
                report.ReportPath = (Form1.MiReporte);

                string vRif = Form1.erif.Trim();
                string vCaja = iniciarSesion.ucodigo.Trim();
                string vNro = rec;

                ReportParameter[] parameters = new ReportParameter[7];
                parameters[0] = new ReportParameter("rRif", vRif.Trim());
                parameters[1] = new ReportParameter("rCaja", vCaja.Trim());
                parameters[2] = new ReportParameter("rNro", vNro.Trim());
                parameters[3] = new ReportParameter("rNom", nom.Trim());
                parameters[4] = new ReportParameter("rCon", con.Trim());
                parameters[5] = new ReportParameter("rMon", mon.ToString("N0"));
                parameters[6] = new ReportParameter("rTit", tit.Trim());

                report.SetParameters(parameters);
                report.PrintToPrinter();
                //
                this.Close();
            }
            else
            {
                MessageBox.Show("DEBE LLENAR DATOS DEL RECIBO");
            }
        }

        private void egresoCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == 27)
           {
               this.Close();
            }
        }
    }
}

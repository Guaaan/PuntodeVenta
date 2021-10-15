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
using System.IO;

namespace ptoVenta
{

    public partial class cambiarPrecio : Form
    {
        SqlCommand com;
        SqlDataReader dr;
        private double vcos = 0;
        private double vpre = 0;
        private double mini = 0;

        public cambiarPrecio()
        {
            InitializeComponent();
        }
        private void cambiarPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { Form1.newpre = "0"; this.Close(); }
        }

        private void cambiarPrecio_Load(object sender, EventArgs e)
        {
            com = new SqlCommand("SELECT CONVERT(numeric(10,0),ROUND(PRECIO1*1.19,-1)) PRECIO1,CONVERT(numeric(10,0),ROUND(COSTO*1.19,-1)) COSTO FROM INVENTARIO WHERE CODIGO='" + Form1.cod + "'", Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                vcos = Convert.ToDouble(dr["COSTO"]);
                vpre = Convert.ToDouble(dr["PRECIO1"]);
            }
            dr.Close();
            textBox1.Text = vpre.ToString("N0");
            textBox2.Text = vpre.ToString();

            double vdes = (vpre - vcos) * (Form1.desc / 100); 
            mini = (int)Math.Round(vpre - vdes,0);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                int x2 = (int)Convert.ToInt32(textBox2.Text);
                if (x2 < vcos) 
                { 
                    textBox2.Text = mini.ToString();
                    SendKeys.Send("^(a)");
                }
                else
                {
                    Form1.newpre = textBox2.Text.ToString(); 
                    this.Close();
                }
                 
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

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //TECLAS DEL FORM
            bool passed = false;
            if (keyData == Keys.F9)
            {
                Form1.newpre = mini.ToString();
                passed = false;
                this.Close();
            }
            return passed;
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal xpor = numericUpDown1.Value;
            decimal xval = Convert.ToDecimal(textBox1.Text.ToString());
            decimal xval2 = (int)Math.Round(xval - (xval * xpor / 100));
            textBox2.Text = xval2.ToString();
            SendKeys.Send("{TAB}");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            decimal xpor = numericUpDown2.Value;
            decimal xval = Convert.ToDecimal(textBox1.Text.ToString());
            decimal xval2 = (int)Math.Round(xval + (xval * xpor / 100));
            textBox2.Text = xval2.ToString();
            SendKeys.Send("{TAB}");
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("^(a)");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}

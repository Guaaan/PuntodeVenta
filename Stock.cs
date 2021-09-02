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
using System.Net;
using DevComponents.DotNetBar;

namespace ptoVenta
{
    public partial class Stock : Form
    {
        SqlConnection locn;
        SqlCommand com,lcom;
        SqlDataReader dr,lo,elo;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            dgvGrid1.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvGrid1.EnableHeadersVisualStyles = false;
            dgvGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(56, 114, 108);
            dgvGrid1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        public Stock()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string despro = textBox1.Text.Trim();
                com = new SqlCommand("SELECT I.CODIGO,I.NOMBRE,ROUND(I.PRECIO1*1.19,-1) MONTO,E.CANTIDAD CANTIDAD FROM INVENTARIO I LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE I.NOMBRE LIKE '%" + despro + "%'", Form1.cn);
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                dgvGrid1.Rows.Clear();
                int regis = 0;
                while (dr.Read())
                {
                    regis += 1;
                    int renglon = dgvGrid1.Rows.Add();
                    dgvGrid1.Rows[renglon].Cells["Codigo"].Value = Convert.ToString(dr["CODIGO"]).Trim();
                    if (Convert.ToString(dr["CANTIDAD"]).Trim() != "0")
                    {
                        dgvGrid1.Rows[renglon].Cells["Cantidad"].Value = Convert.ToString(dr["CANTIDAD"]).Trim();
                    }
                    dgvGrid1.Rows[renglon].Cells["Producto"].Value = Convert.ToString(dr["NOMBRE"]).Trim();
                    dgvGrid1.Rows[renglon].Cells["Precio"].Value = dr["MONTO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["MONTO"]);
                }
                dr.Close();
                label1.Visible = true;
                progressBarX1.Visible = true;
                int pregis = 3 * regis;
                progressBarX1.Maximum = pregis;
                progressBarX1.Value = 0;
                this.Refresh();
                com = new SqlCommand("SELECT * FROM LOCALES WHERE TIPO<>'NINGUNO' AND  SIGLAS<>'" + Form1.mante + "' ORDER BY POSI", Form1.cn);
                com.ExecuteNonQuery();
                lo = com.ExecuteReader();
                int fila = 0;
                string efila = "";
                string ss = "";
                while (lo.Read())
                {
                    progressBarX1.Value += 1;
                    label1.Text = "Conectando..."+ Convert.ToString(lo["NOMBRE"]).Trim();
                    this.label1.Refresh();
                    Form1.conecto = 0;
                    Form1.cadena = "Data Source = '" + Convert.ToString(lo["SERVER"]).Trim() + "';initial Catalog = '" + Convert.ToString(lo["DBASE"]).Trim() + "'; user id = sa; password ='" + Convert.ToString(lo["PASSW"]).Trim() + "'";
                    locn = new SqlConnection(Form1.cadena);
                    try
                    {
                        locn.Open();
                    }
                    catch (Exception ex)
                    {
                        string rpta = ex.Message;
                    }

                    if (locn.State == ConnectionState.Open)
                    {
                        int regi = 0;
                        fila++;
                        dgvGrid1.Columns[fila + 3].HeaderText = Convert.ToString(lo["NOMBRE"]).Trim();
                        this.dgvGrid1.Refresh();
                        foreach (DataGridViewRow row in dgvGrid1.Rows)
                        {
                            progressBarX1.Value += 1;
                            if (row.Cells["Codigo"].Value != null)
                            {
                                efila = fila.ToString();
                                ss = row.Cells["Codigo"].Value.ToString();
                                lcom = new SqlCommand("SELECT TOP 1 CANTIDAD FROM EXISTENCIA WHERE CODIGO='" + ss + "'", locn);
                                lcom.ExecuteNonQuery();
                                elo = lcom.ExecuteReader();
                                while (elo.Read())
                                {
                                    if (Convert.ToString(elo["CANTIDAD"]).Trim() != "0")
                                    {
                                        dgvGrid1.Rows[regi].Cells["Column" + efila].Value = Convert.ToString(elo["CANTIDAD"]).Trim();
                                    }
                                }
                                elo.Close();
                                regi += 1;
                            }
                        }
                        locn.Close();
                        this.dgvGrid1.Refresh();
                    }
                    else
                    {
                        progressBarX1.Value += (pregis / 4);
                    }
                }
                lo.Close();
                label1.Visible = false;
                progressBarX1.Visible = false;
                dgvGrid1.Focus();
            }
        }
    }
}

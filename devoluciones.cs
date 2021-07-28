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
using System.Collections;
using System.IO;

namespace ptoVenta
{
    public partial class devoluciones : Form
    {
        SqlCommand com;
        SqlDataReader dr;

        private string comsql1, comsql2;
        private double prec, cant,comp, tot = 0, totd = 0;
        private DateTime fech = DateTime.Now;

        public devoluciones()
        {
            InitializeComponent();
        }

        private void devoluciones_Load(object sender, EventArgs e)
        {
            txtBoletaFactura.Text = ticketsEmitidos.vnum;
            comsql1 = "SELECT F.NUMERO,C.NOMBRE,M.FECHA,M.CODIGO,M.DESCRIP,(M.CANTIDAD-M.CANTAJU) COMPRA,M.MONTOFINAL/M.CANTIDAD PRECIO,M.CODID,M.POSI FROM CAJAS C RIGHT JOIN FACTURAS F ON C.CODIGO = F.CAJAPERTUR ";
            comsql2 = comsql1 + "LEFT JOIN MFACTURAS M ON M.NUMERO = F.NUMERO WHERE F.STATUS=2 AND M.NUMERO='" + ticketsEmitidos.vnum + "'  ORDER BY M.POSI ";
            com = new SqlCommand(comsql2, Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            dgvGrid1.Rows.Clear();
            int fila = 0;
            while (dr.Read())
            {
                fila++;
                int renglon = dgvGrid1.Rows.Add();
                dgvGrid1.Rows[renglon].Cells["Caja"].Value = Convert.ToString(dr["NOMBRE"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Fecha"].Value = Convert.ToString(dr["FECHA"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Codigo"].Value = Convert.ToString(dr["CODIGO"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Producto"].Value = Convert.ToString(dr["DESCRIP"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Compra"].Value = Convert.ToDouble(dr["COMPRA"]);
                dgvGrid1.Rows[renglon].Cells["Cantidad"].Value = "0";
                dgvGrid1.Rows[renglon].Cells["Precio"].Value = dr["PRECIO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PRECIO"]);
                dgvGrid1.Rows[renglon].Cells["Codid"].Value = Convert.ToInt32(dr["CODID"]);
                dgvGrid1.Rows[renglon].Cells["Posi"].Value = Convert.ToInt32(dr["POSI"]);
                prec = Convert.ToDouble(dr["PRECIO"]);
                cant = Convert.ToInt32(dgvGrid1.Rows[renglon].Cells["Cantidad"].Value);
                fech = Convert.ToDateTime(dr["FECHA"]);
                tot = cant * prec;
                dgvGrid1.Rows[fila - 1].Cells["Total"].Value = tot;
                totd = totd + tot;
            }
            dr.Close();
            txtMontoNota.Text = totd.ToString("N0");
            dgvGrid1.CurrentCell = dgvGrid1.CurrentRow.Cells[6];
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            sumardev();
        }

        private void dgvGrid1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;

            if (dgvCombo != null)
            {
                dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);
                dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
            }
        }

        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = dgvGrid1.Rows[dgvGrid1.CurrentRow.Index].Index;
            ComboBox combo = sender as ComboBox;
            int xcan = Convert.ToInt32(combo.SelectedIndex);
            dgvGrid1.Rows[dgvGrid1.CurrentRow.Index].Cells[7].Value = xcan.ToString();
            comp = Convert.ToInt32(dgvGrid1.Rows[dgvGrid1.CurrentRow.Index].Cells[6].Value);
            if(comp < xcan)
            {
                int index = combo.FindString(comp.ToString());
                combo.SelectedIndex = index;
            }
            sumardev();
        }

        private void dgvGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrid1.Rows.Count > 0)
            {
                if (dgvGrid1.CurrentCell.ColumnIndex == 8)
                {
                    sumardev();
                }
            }
        }

        private void sumardev()
        {
            totd = 0;
            foreach (DataGridViewRow row in dgvGrid1.Rows)
            {
                if (row.Cells["Codigo"].Value != null)
                {
                    comp = Convert.ToInt32(row.Cells["Compra"].Value);
                    cant = Convert.ToInt32(row.Cells["Cantidad"].Value.ToString());
                    prec = Convert.ToInt32(row.Cells["Precio"].Value.ToString());
                    if (comp < cant)
                    {
                        cant = comp;
                    }
                    tot = cant * prec;
                    row.Cells["Total"].Value = tot;
                    totd += tot;
                }
            }
            txtMontoNota.Text = totd.ToString("N0");
        }

        private void devoluciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (totd > 0)
            {
                cierradev();
            }
        }

        private void cierradev()
        {
            string rec = "";
            com = new SqlCommand("SELECT MAX(convert(int, RECIBO))+1 REXP FROM CREDITOS", Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                rec = Convert.ToString(dr["REXP"]);
            }
            dr.Close();

            //CREDITOS
            int impu = Convert.ToInt32(totd/1.19);
            impu = Convert.ToInt32(totd) - impu;
            comsql1 = "INSERT INTO CREDITOS (RECIBO,CODIGO,FECHA,CONCEPTO,MONTO,IVA,USUARIO,CAJA,TIPO,FORMAPAGO,IMPUESTO,ENLACE,CONTROL,EMISION) ";
            comsql2 = comsql1 + "VALUES (@rec,@cod,@fec,@con,@mon,@iva,@usu,@caj,@tip,@for,@imp,@enl,@tro,@emi)";
            com = new SqlCommand(comsql2, Form1.cn);
            com.Parameters.AddWithValue("@rec", rec);
            com.Parameters.AddWithValue("@cod", "11");
            com.Parameters.AddWithValue("@fec", DateTime.Now);
            com.Parameters.AddWithValue("@con", "NOTA DE CREDITO SEGUN FACTURA NRO: "+ ticketsEmitidos.vnum);
            com.Parameters.AddWithValue("@mon", totd);
            com.Parameters.AddWithValue("@iva", 19);
            com.Parameters.AddWithValue("@usu", iniciarSesion.unombre.Trim());
            com.Parameters.AddWithValue("@caj", iniciarSesion.ucaja.Trim());
            com.Parameters.AddWithValue("@tip", 1);
            com.Parameters.AddWithValue("@for", "EFECTIVO");
            com.Parameters.AddWithValue("@imp", impu);
            com.Parameters.AddWithValue("@enl", ticketsEmitidos.vnum);
            com.Parameters.AddWithValue("@tro", rec);
            com.Parameters.AddWithValue("@emi", fech);
            com.ExecuteNonQuery();

            string num = "";
            com = new SqlCommand("SELECT MAX(convert(int, NUMERO))+1 REXP FROM CARGOS WHERE TIPO=1", Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                num = Convert.ToString(dr["REXP"]);
            }
            dr.Close();
            //CARGOS
            comsql1 = "INSERT INTO CARGOS (NUMERO,TIPO,FECHA,RESPONSABLE,AUTORIZA,ALMACEN,CONCEPTO,NOTA) ";
            comsql2 = comsql1 + "VALUES (@num,@tip,@fec,@res,@aut,@alm,@con,@not)";
            com = new SqlCommand(comsql2, Form1.cn);
            com.Parameters.AddWithValue("@num", num);
            com.Parameters.AddWithValue("@tip", 1);
            com.Parameters.AddWithValue("@fec", DateTime.Now);
            com.Parameters.AddWithValue("@res", iniciarSesion.unombre.Trim());
            com.Parameters.AddWithValue("@aut", iniciarSesion.ucodigo.Trim());
            com.Parameters.AddWithValue("@alm", Form1.alma);
            com.Parameters.AddWithValue("@con", "DEVOLUCION DE VENTA SEGUN FACTURA NRO: " + ticketsEmitidos.vnum);
            com.Parameters.AddWithValue("@not", ticketsEmitidos.vnum);
            com.ExecuteNonQuery();
            int fila = 0;
            foreach (DataGridViewRow row in dgvGrid1.Rows)
            {
                if (row.Cells["Cantidad"].Value != null)
                {
                    fila += 1;
                    string cid = row.Cells["Codid"].Value.ToString();
                    string cod = row.Cells["Codigo"].Value.ToString();
                    string des = row.Cells["Producto"].Value.ToString();
                    cant = Convert.ToInt32(row.Cells["Cantidad"].Value.ToString());
                    prec = Convert.ToInt32(row.Cells["Precio"].Value.ToString());
                    int pos = Convert.ToInt32(row.Cells["Posi"].Value.ToString());

                    comsql1 = "INSERT INTO MCARGOS (NUMERO,POSI,CODIGO,DESCRIPCION,CANTIDAD,PRECIO,TIPO,MOVIMIENTO,FECHA,IVAC,ALMACEN,CODID) ";
                    comsql2 = comsql1 + "VALUES (@num,@pos,@cod,@des,@can,@pre,@tip,@mov,@fec,@iva,@alm,@cid)";
                    com = new SqlCommand(comsql2, Form1.cn);
                    com.Parameters.AddWithValue("@num", num);
                    com.Parameters.AddWithValue("@pos", fila);
                    com.Parameters.AddWithValue("@cod", cod);
                    com.Parameters.AddWithValue("@des", des);
                    com.Parameters.AddWithValue("@can", cant);
                    com.Parameters.AddWithValue("@pre", prec/1.19);
                    com.Parameters.AddWithValue("@tip", 1);
                    com.Parameters.AddWithValue("@mov", 1);
                    com.Parameters.AddWithValue("@fec", DateTime.Now);
                    com.Parameters.AddWithValue("@iva", 1);
                    com.Parameters.AddWithValue("@alm", Form1.alma);
                    com.Parameters.AddWithValue("@cid", cid);
                    com.ExecuteNonQuery();

                    com = new SqlCommand("UPDATE EXISTENCIA SET CANTIDAD=CANTIDAD + " + cant + " WHERE CODID='" + cid + "'", Form1.cn);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("UPDATE MFACTURAS SET CANTAJU=CANTAJU+"+cant+" WHERE CODIGO='"+cod+"' AND NUMERO='"+ ticketsEmitidos.vnum + "' AND POSI='"+pos+"'", Form1.cn);
                    com.ExecuteNonQuery();
                }
            }
            // IMPRIME DEVOLUCION
            this.Close();

        }

    }
}

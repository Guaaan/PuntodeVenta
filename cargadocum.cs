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


namespace ptoVenta
{

    public partial class cargadocum : Form
    {
        SqlCommand com;
        SqlDataReader dr;

        private string comsql1, comsql2;
        public static string vnum;

        public cargadocum()
        {
            InitializeComponent();
        }

        private void cargadocum_Load(object sender, EventArgs e)
        {
            int anc = dgvGrid1.Width;
            int ancp = 0;
            for (int a = 0; a < 9; a++)
            {
                ancp = ancp + dgvGrid1.Columns[a].Width;
            }
            anc = (anc - ancp) - 20;
            dgvGrid1.Columns[5].Width = dgvGrid1.Columns[5].Width + anc;

            dgvGrid1.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvGrid1.EnableHeadersVisualStyles = false;
            dgvGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvGrid1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cargaboletas();

            int fila = 0;
            string[] grupoCodigos = dgvGrid1.Rows.Cast<DataGridViewRow>()
                .Select(x => Convert.ToString(x.Cells[0].Value)).Distinct().ToArray();

            for (int i = 0; i < grupoCodigos.Length; i++)
            {
                foreach (DataGridViewRow row in dgvGrid1.Rows.Cast<DataGridViewRow>()
                    .Where(r => Convert.ToString(r.Cells[0].Value) == grupoCodigos[i]))
                {
                    row.DefaultCellStyle.BackColor = i % 2 == 0 ? Color.LightSkyBlue : Color.White;
                }
                fila++;
            }
            textBox1.Text = fila.ToString("N0");


        }

        // metodo para cada boleta
        
        private void cargaboletas()
        {
            comsql1 = "SELECT F.NUMERO,C.NOMBRE,M.FECHA,M.CODIGO,M.DESCRIP,M.CANTIDAD,M.MONTOFINAL FROM CAJAS C RIGHT JOIN FACTURAS F ON C.CODIGO = F.CAJAPERTUR ";
            comsql2 = comsql1 + "INNER JOIN MFACTURAS M ON M.NUMERO = F.NUMERO WHERE F.STATUS=0 AND M.MONTOFINAL>0 ORDER BY F.FECHA DESC ";
            com = new SqlCommand(comsql2, Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            dgvGrid1.Rows.Clear();
            
            while (dr.Read())
            {
                int renglon = dgvGrid1.Rows.Add();
                dgvGrid1.Rows[renglon].Cells["Numero"].Value = Convert.ToString(dr["NUMERO"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Caja"].Value = Convert.ToString(dr["NOMBRE"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Fecha"].Value = Convert.ToString(dr["FECHA"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Codigo"].Value = Convert.ToString(dr["CODIGO"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Producto"].Value = Convert.ToString(dr["DESCRIP"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Cantidad"].Value = Convert.ToString(dr["CANTIDAD"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Precio"].Value = dr["MONTOFINAL"] == DBNull.Value ? 0 : Convert.ToDouble(dr["MONTOFINAL"]);

            }
            dr.Close();
        }

        private void dgvGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clsImprimir printmir;
            printmir = new clsImprimir();
            if (dgvGrid1.Rows.Count > 0)
            {
                if (dgvGrid1.CurrentCell.ColumnIndex == 7)
                {
                    int indice = dgvGrid1.CurrentRow.Index;
                    string ddoc = Convert.ToString(dgvGrid1.Rows[indice].Cells[0].Value).Trim();
                    printmir.CargarImprimir(dgvGrid1, printDocumento, ddoc);
                }
                if (dgvGrid1.CurrentCell.ColumnIndex == 8)
                {
                    int indice = dgvGrid1.CurrentRow.Index;
                    string ddoc = Convert.ToString(dgvGrid1.Rows[indice].Cells[0].Value).Trim();
                    com = new SqlCommand("DELETE FACTURAS WHERE NUMERO = '" + ddoc + "'", Form1.cn);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("DELETE MFACTURAS WHERE NUMERO = '" + ddoc + "'", Form1.cn);
                    com.ExecuteNonQuery();

                    dgvGrid1.Rows.Remove(dgvGrid1.CurrentRow);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGrid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgvGrid1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            if (e.KeyChar == 13)
            {
                int indice = dgvGrid1.CurrentRow.Index - 1;
                if (indice < 0) { indice = 0; }
                Form1.documc = Convert.ToString(dgvGrid1.Rows[indice].Cells[0].Value).Trim();
                this.Close();
            }
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void cargadocum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}

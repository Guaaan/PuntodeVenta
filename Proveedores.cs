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
using Microsoft.Reporting.WinForms;
using ptoVenta;

namespace Principal
{
    public partial class Proveedores : Form
    {
        SqlCommand com;
        SqlDataReader dr;
        public string vcod,sqlcom1,sqlcom2;
        private int fila = 0;

        public Proveedores()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            dgvGrid1.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvGrid1.EnableHeadersVisualStyles = false;
            dgvGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvGrid1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cargaGrid();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            vcod = Microsoft.VisualBasic.Interaction.InputBox("INTRODUZCA RUT DEL CLIENTE:", "NUEVO CLIENTE");
            if (!string.IsNullOrEmpty(vcod))
            {
                com = new SqlCommand("SELECT * FROM Proveedores WHERE CODIGO='" + vcod + "'", Form1.cn);
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                int siesta = 0;
                while (dr.Read())
                {
                    siesta = 1;
                }
                dr.Close();
                if (siesta == 0)
                {
                    com = new SqlCommand("INSERT INTO Proveedores (CODIGO) VALUES ('" + vcod + "')", Form1.cn);
                    com.ExecuteNonQuery();
                    fila++;
                    int renglon = dgvGrid1.Rows.Add();
                    dgvGrid1.Rows[renglon].Cells["Linea"].Value = Convert.ToString(fila);
                    dgvGrid1.Rows[renglon].Cells["Codigo"].Value = vcod.Trim();
                    dgvGrid1.Rows[renglon].Cells["Rut"].Value = vcod.Trim();
                    dgvGrid1.Rows[renglon].Cells["Nombre"].Value = "";
                    dgvGrid1.Rows[renglon].Cells["Direccion"].Value = "";
                    dgvGrid1.Rows[renglon].Cells["Telefonos"].Value = "";
                    dgvGrid1.Rows[renglon].Cells["Correo"].Value = "";
                    dgvGrid1.Rows[renglon].Cells["Contacto"].Value = "";
                    dgvGrid1.Rows[renglon].Cells["Precio"].Value = "0";
                    dgvGrid1.Rows[renglon].Cells["Estatus"].Value = "Activo";

                    dgvGrid1.Rows[renglon].Selected = true;
                    dgvGrid1.CurrentCell = dgvGrid1.Rows[renglon].Cells[0];
                }
                else
                {
                    fila = 0;
                    foreach (DataGridViewRow row in dgvGrid1.Rows)
                    {
                        if (row.Cells["Codigo"].Value != null)
                        {
                            row.Selected = false;
                            fila ++;
                            string ss = row.Cells["Codigo"].Value.ToString();
                            ss = ss.Trim();
                            if (vcod == ss)
                            {
                                dgvGrid1.Rows[fila - 1 ].Selected = true;
                                dgvGrid1.CurrentCell = dgvGrid1.Rows[fila - 1].Cells[0];
                                break;
                            }
                        }
                    }
                }
            }

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            vcod = Microsoft.VisualBasic.Interaction.InputBox("INTRODUZCA RUT/NOMBRE A BUSCAR:", "BUSCAR CLIENTE");
            vcod = vcod.ToUpper();
            if (!string.IsNullOrEmpty(vcod))
            {
                fila = 0;
                foreach (DataGridViewRow row in dgvGrid1.Rows)
                {
                    if (row.Cells["Codigo"].Value != null)
                    {
                        row.Selected = false;
                        fila++;
                        string ss = row.Cells["Codigo"].Value.ToString();
                        string cc = row.Cells["Nombre"].Value.ToString();
                        ss = ss.Trim();
                        if (ss.Contains(vcod) || cc.Contains(vcod))
                        {
                            dgvGrid1.Rows[fila - 1].Selected = true;
                            dgvGrid1.CurrentCell = dgvGrid1.Rows[fila - 1].Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void cargaGrid()
        {
            com = new SqlCommand("SELECT * FROM Proveedores order by nombre", Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            dgvGrid1.Rows.Clear();
            while (dr.Read())
            {
                fila++;
                int renglon = dgvGrid1.Rows.Add();
                dgvGrid1.Rows[renglon].Cells["Linea"].Value = Convert.ToString(fila);
                dgvGrid1.Rows[renglon].Cells["Codigo"].Value = Convert.ToString(dr["CODIGO"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Rut"].Value = Convert.ToString(dr["RIF"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Nombre"].Value = Convert.ToString(dr["NOMBRE"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Direccion"].Value = Convert.ToString(dr["DIRECCION"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Telefonos"].Value = Convert.ToString(dr["TELEFONOS"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Correo"].Value = Convert.ToString(dr["EMAIL"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Contacto"].Value = Convert.ToString(dr["CONTACTO"]).Trim();
                dgvGrid1.Rows[renglon].Cells["Precio"].Value = Convert.ToString(dr["PRECIO"]);
                dgvGrid1.Rows[renglon].Cells["Estatus"].Value = Convert.ToString(dr["STATUS"]) != "2" ? "Activo" : "Suspendido";
            }
            dr.Close();
            iconButton2.Text = fila.ToString("N0");
        }

        private void dgvGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrid1.Rows.Count > 0)
            {
                if (dgvGrid1.CurrentCell.ColumnIndex == 10)
                {
                    vcod = dgvGrid1.CurrentRow.Cells["Codigo"].Value.ToString();
                    com = new SqlCommand("SELECT * FROM Proveedores WHERE CODIGO='" + vcod + "'", Form1.cn);
                    com.ExecuteNonQuery();
                    dr = com.ExecuteReader();
                    int siesta = 0;
                    while (dr.Read())
                    {
                        siesta = 1;
                    }
                    dr.Close();
                    if(siesta == 0)
                    {
                        com = new SqlCommand("INSERT INTO Proveedores (CODIGO) VALUES ('" + vcod + "'", Form1.cn);
                        com.ExecuteNonQuery();
                    }
                    string xest = dgvGrid1.CurrentRow.Cells["Estatus"].Value.ToString();
                    int vest = 1;
                    if (xest == "Suspendido") { vest = 2; }
                    sqlcom1 = "UPDATE Proveedores SET RIF=@mrut,NOMBRE=@mnom,DIRECCION=@mdir,TELEFONOS=@mtel,EMAIL=@mcor,CONTACTO=@mcon,PRECIO=@mpre,STATUS=@mest WHERE CODIGO='" + vcod + "'";
                    com = new SqlCommand(sqlcom1, Form1.cn);
                    com.Parameters.AddWithValue("@mnom", dgvGrid1.CurrentRow.Cells["Nombre"].Value.ToString());
                    com.Parameters.AddWithValue("@mrut", dgvGrid1.CurrentRow.Cells["Rut"].Value.ToString());
                    com.Parameters.AddWithValue("@mdir", dgvGrid1.CurrentRow.Cells["Direccion"].Value.ToString());
                    com.Parameters.AddWithValue("@mtel", dgvGrid1.CurrentRow.Cells["Telefonos"].Value.ToString());
                    com.Parameters.AddWithValue("@mcor", dgvGrid1.CurrentRow.Cells["Correo"].Value.ToString());
                    com.Parameters.AddWithValue("@mcon", dgvGrid1.CurrentRow.Cells["Contacto"].Value.ToString());
                    com.Parameters.AddWithValue("@mpre", Convert.ToInt32(dgvGrid1.CurrentRow.Cells["Precio"].Value.ToString()));
                    com.Parameters.AddWithValue("@mest", vest);
                    com.ExecuteNonQuery();
                    MessageBox.Show("CLIENTE GUARDADO CON EXITO");
                }
                if (dgvGrid1.CurrentCell.ColumnIndex == 11)
                {
                    vcod = dgvGrid1.CurrentRow.Cells["Codigo"].Value.ToString();
                    DialogResult result = MessageBox.Show("DESEA USTED ELIMINAR ESTE CLIENTE", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result.ToString() == "Yes")
                    {
                        com = new SqlCommand("DELETE Proveedores WHERE CODIGO = '" + vcod + "' ", Form1.cn);
                        com.ExecuteNonQuery();
                        dgvGrid1.Rows.Remove(dgvGrid1.CurrentRow);
                        fila--; 
                        iconButton2.Text = fila.ToString("N0");
                    }
                }
            }
        }

    }
}

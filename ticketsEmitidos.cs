﻿using System;
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
using Microsoft.Reporting.WinForms;

namespace ptoVenta
{

    public partial class ticketsEmitidos : Form
    {
        SqlCommand com;
        SqlDataReader dr;

        private DateTime fec1 = DateTime.Today;
        private DateTime fec2 = DateTime.Today;
        private string comsql1, comsql2;
        public static string vnum;

        public List<TicketDatos> TicketDatos = new List<TicketDatos>();

        public ticketsEmitidos()
        {
            InitializeComponent();
        }

        private void ticketsEmitidos_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            int anc = dgvGrid1.Width;
            int ancp = 0;
            for (int a = 0; a < 10; a++)
            {
                ancp = ancp + dgvGrid1.Columns[a].Width;
            }
            anc = (anc - ancp) - 100;
            dgvGrid1.Columns[5].Width = dgvGrid1.Columns[5].Width + anc;
            dgvGrid1.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvGrid1.EnableHeadersVisualStyles = false;
            dgvGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvGrid1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cargaboletas();
        }

        private void cargaboletas()
        {
            fec2 = fec2.AddDays(+1);
            string f1 = fec1.ToString("yyyyMMdd");
            string f2 = fec2.ToString("yyyyMMdd");
            comsql1 = "SELECT F.NUMERO,C.NOMBRE,M.FECHA,M.CODIGO,M.DESCRIP,M.CANTIDAD,M.MONTOFINAL FROM CAJAS C RIGHT JOIN FACTURAS F ON C.CODIGO = F.CAJAPERTUR ";
            comsql2 = comsql1 + "LEFT JOIN MFACTURAS M ON M.NUMERO = F.NUMERO WHERE F.STATUS=2 AND M.FECHA>'" + f1 + "' AND M.FECHA<'" + f2 + "' AND M.CANTIDAD>0 ORDER BY F.FECHA DESC ";
            com = new SqlCommand(comsql2, Form1.cn);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            dgvGrid1.Rows.Clear();
            int fila = 0;
            while (dr.Read())
            {
                fila++;
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
            textBox1.Text = fila.ToString("N0");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fec1 = dateTimePicker1.Value;
            fec2 = dateTimePicker2.Value;
            cargaboletas();
            dgvGrid1.Focus();
        }

        private void dgvGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrid1.Rows.Count > 0)
            {
                if (dgvGrid1.CurrentCell.ColumnIndex == 99)
                {
                    vnum = dgvGrid1.CurrentRow.Cells["NUMERO"].Value.ToString();

                    //RepTicket rep = new RepTicket();
                    LocalReport report = new LocalReport();
                    report.DataSources.Clear();

                    Form1.MiReporte = "Informes\\Tickets.rdlc";

                    foreach (DataGridViewRow row in dgvGrid1.Rows)
                    {
                        if (row.Cells["numero"].Value.ToString() == vnum)
                        {
                            TicketDatos dat = new TicketDatos();
                            dat.Codigo = row.Cells["codigo"].Value.ToString();
                            dat.Nombre = row.Cells["producto"].Value.ToString();
                            dat.Cantidad = row.Cells["cantidad"].Value.ToString();
                            double pre = (double)row.Cells["precio"].Value;
                            dat.Precio = pre.ToString("N0");
                            TicketDatos.Add(dat);
                        }
                    }
                    //rep.ShowDialog();
                    report.DataSources.Add(new ReportDataSource("DataSet1", TicketDatos));
                    report.ReportPath = (Form1.MiReporte);

                    string vRif = Form1.erif.Trim();
                    string vCaja = iniciarSesion.ucodigo.Trim();
                    string vNro = vnum;

                    ReportParameter[] parameters = new ReportParameter[3];
                    parameters[0] = new ReportParameter("rRif", vRif);
                    parameters[1] = new ReportParameter("rCaja", vCaja);
                    parameters[2] = new ReportParameter("rNro", vNro);

                    report.SetParameters(parameters);
                    report.PrintToPrinter();

                }
                if (dgvGrid1.CurrentCell.ColumnIndex == 9)
                {
                    clsImprimir printmir;
                    printmir = new clsImprimir();
                    vnum = dgvGrid1.CurrentRow.Cells["NUMERO"].Value.ToString();
                    printmir.CargarImprimir(dgvGrid1, printDocumento, vnum, "Reimpresión");
                }
                if (dgvGrid1.CurrentCell.ColumnIndex == 10)
                {
                    vnum = dgvGrid1.CurrentRow.Cells["NUMERO"].Value.ToString();
                    devoluciones abrirFormClass = new devoluciones();
                    abrirFormClass.ShowDialog();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ticketsEmitidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}

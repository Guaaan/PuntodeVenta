using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ptoVenta
{
    public partial class RepTicket : Form
    {
        public List<TicketDatos> TicketDatos = new List<TicketDatos>();
        public RepTicket()
        {
            InitializeComponent();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", TicketDatos));
            reportViewer1.LocalReport.ReportPath = (Form1.MiReporte);
            this.reportViewer1.RefreshReport();
        }

    }
}

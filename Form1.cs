using System;
using System.IO;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading;
using System.Windows.Forms;
//using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
//using System.Collections;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
//using DevComponents.DotNetBar;
//using DevComponents.DotNetBar.Controls;


namespace ptoVenta
{
    public partial class Form1 : Form
    {
        CultureInfo myCIintl = new CultureInfo("es-ES", false);

        public static SqlConnection cn,locn;
        SqlCommand com;
        SqlDataReader dr;

        public List<TicketDatos> TicketDatos = new List<TicketDatos>();

        //private DataGridView dgvGrid1 = new DataGridView();

        public static int totf = 0;
        public static int totp = 0;
        public static int tots = 0;
        public static int toti = 0;
        public static string newpre = "";
        public static string cod = "";
        private string upre = "";
        public static string cadena = "";
        public static int conecto = 0;

        public static string nombre = "";
        public static string rut = "";
        public static string telefono = "";
        public static string correo = "";
        public static string direccion = "";
        public static double desc = 0;

        public string ucodigo = "";
        public string unombre = "";
        public string uperfil = "";
        public string ucaja = "";
        public string ufoto = "";

        public static string empresalic = "";
        public static string erif = "";
        public static string edire = "";
        public static string eservidor = "";
        public static string edatabase = "";
        string eserial = "";
        string elogo = "";
        string vari = "";
        string vfoto = "";
        public static int montoape = 0;
        string uforma = "";
        string strHostName = Dns.GetHostName();
        string vuser = "";
        public static string alma = "";
        public static string mante = "";
        public static string MiReporte = "";
        public static string documc = "";
        public static string nombreFarmacia;
     
        public SqlDataReader Dr { get => dr; set => dr = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cn = Conexion.conexion();
            cn.Open();
            textBox1.BorderStyle = BorderStyle.None;
            dgvLista.Width = dgvGrid1.Width;
            dgvLista.Visible = false;
            dgvGrid1.Visible = false;
            int anc = dgvGrid1.Width;
            int ancp = 0;
            for (int a = 0; a < 10; a++)
            {
                ancp = ancp + dgvGrid1.Columns[a].Width;
            }
            anc = (anc - ancp) - 20;
            dgvGrid1.Columns[3].Width = dgvGrid1.Columns[3].Width + anc;
            anc = dgvLista.Width;
            ancp = 0;
            for (int a = 0; a < 8; a++)
            {
                ancp = ancp + dgvLista.Columns[a].Width;
            }
            anc = (anc - ancp) - 20;
            dgvLista.Columns[3].Width = dgvLista.Columns[3].Width + anc;

            alternarColorData(dgvLista);
            dgvLista.Rows.Clear();
            dgvGrid1.Rows.Clear();

            Cargarvariables();
            dgvGrid1.Visible = true;
            timer1.Start();
        }

        public void Cargarvariables()
        {
            empresalic = "FARMACIAS GEMINIS SPA";
            textBox1.Text = empresalic;
            com = new SqlCommand("SELECT * FROM EMPRESA", cn);
            com.ExecuteNonQuery();
            Dr = com.ExecuteReader();
            while (Dr.Read())
            {
                mante = Convert.ToString(Dr["MANTE"]);
                erif = Convert.ToString(Dr["ERIF"]);
                edire = Convert.ToString(Dr["EDIRECCION"]);
                eserial = Convert.ToString(Dr["FONDOSYS"]);
                elogo = Convert.ToString(Dr["LOGOSYS"]);
                alma = Convert.ToString(Dr["ALMACEN"]);
                desc = Convert.ToDouble(Dr["PDESC"]);
            }
            Dr.Close();

            com = new SqlCommand("SELECT * FROM LOCALES WHERE SIGLAS= '" + mante + "' ", cn);
            com.ExecuteNonQuery();
            Dr = com.ExecuteReader();
            while (Dr.Read())
            {
                label13.Text = Convert.ToString(Dr["NOMBRE"]).Trim();
                label13.Text = Convert.ToString(Dr["NOMBRE"]).Trim();
                nombreFarmacia = Convert.ToString(Dr["NOMBRE"]).Trim();
            }
            Dr.Close();
        }
        public void alternarColorData(DataGridView dgv)
        {
            dgvLista.RowsDefaultCellStyle.BackColor = Color.MistyRose;
            dgvLista.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvLista.EnableHeadersVisualStyles = false;
            dgvLista.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
            dgvLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGrid1.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvGrid1.EnableHeadersVisualStyles = false;
            //dgvGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 195, 93);
            dgvGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen;
            dgvGrid1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            controlCambio();
        }

        private void controlCambio()
        {
            vari = txtProducto.Text.Trim();
            if (!string.IsNullOrEmpty(vari))
            {
                string ivari = vari.Substring(0, 1);
                if (vari.All(Char.IsLetter) || ivari.ToString() == "*" || ivari.ToString() == "+")
                {
                    panel1.Visible = true;
                    dgvLista.Visible = true;
                    dgvLista.Rows.Clear();
                    com = new SqlCommand("SELECT I.CODIGO,I.NOMBRE,E.CANTIDAD STOCK,CONVERT(numeric(10,0),ROUND(I.PRECIO1*1.19,-1)) PRECIO1,CONVERT(numeric(10,0),ROUND(I.PRECIO2*1.19,-1)) PRECIO2,I.PRINCIPIO,I.FOTO FROM INVENTARIO I LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE I.NOMBRE LIKE '" + vari + "%' ORDER BY I.NOMBRE", cn);
                    if (ivari.ToString() == "*" && vari.Length > 3)
                    {
                        vari = vari.Substring(1);
                        com = new SqlCommand("SELECT I.CODIGO,I.NOMBRE,E.CANTIDAD STOCK,CONVERT(numeric(10,0),ROUND(I.PRECIO1*1.19,-1)) PRECIO1,CONVERT(numeric(10,0),ROUND(I.PRECIO2*1.19,-1)) PRECIO2,I.PRINCIPIO,I.FOTO FROM INVENTARIO I LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE I.NOMBRE LIKE '%" + vari + "%' ORDER BY I.NOMBRE", cn);
                    }
                    if (ivari.ToString() == "+" && vari.Length > 3)
                    {
                        vari = vari.Substring(1);
                        com = new SqlCommand("SELECT I.CODIGO,I.NOMBRE,E.CANTIDAD STOCK,CONVERT(numeric(10,0),ROUND(I.PRECIO1*1.19,-1)) PRECIO1,CONVERT(numeric(10,0),ROUND(I.PRECIO2*1.19,-1)) PRECIO2,I.PRINCIPIO,I.FOTO FROM INVENTARIO I LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE I.PRINCIPIO LIKE '%" + vari + "%' ORDER BY I.NOMBRE", cn);
                    }
                    com.ExecuteNonQuery();
                    Dr = com.ExecuteReader();
                    while (Dr.Read())
                    {
                        int renglon = dgvLista.Rows.Add();
                        dgvLista.Rows[renglon].Cells["Linea"].Value = Convert.ToString(renglon + 1);
                        vfoto = (string)Convert.ToString(Dr["FOTO"]);
                        if (vfoto.Trim() != "")
                        {
                            if (File.Exists(vfoto))
                            {
                                dgvLista.Rows[renglon].Cells["FOTO"].Value = Image.FromFile(vfoto);
                            }
                        }
                        dgvLista.Rows[renglon].Cells["CODIGO"].Value = Dr["CODIGO"] == DBNull.Value ? " " : Convert.ToString(Dr["CODIGO"]).Trim();
                        dgvLista.Rows[renglon].Cells["PRODUCTO"].Value = Dr["NOMBRE"] == DBNull.Value ? " " : Convert.ToString(Dr["NOMBRE"]).Trim();
                        dgvLista.Rows[renglon].Cells["PRINCIPIO"].Value = Dr["PRINCIPIO"] == DBNull.Value ? " " : Convert.ToString(Dr["PRINCIPIO"]).Trim();
                        dgvLista.Rows[renglon].Cells["STOCK"].Value = Dr["STOCK"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["STOCK"]);
                        dgvLista.Rows[renglon].Cells["PRECIO"].Value = Dr["PRECIO1"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["PRECIO1"]);
                        dgvLista.Rows[renglon].Cells["OFERTA"].Value = Dr["PRECIO2"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["PRECIO2"]);
                    }
                    Dr.Close();
                }
            }
            else
            {
                panel1.Visible = false;
                dgvLista.Visible = false;
                txtProducto.Focus();
            }
        }

        public void asignavalores()
        {
            rut = txtRut.Text.ToString();
            nombre = txtNombre.Text.ToString();
            direccion = txtDireccion.Text.ToString();
            telefono = txtTelefono.Text.ToString();
            correo = txtCorreo.Text.ToString();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13))
            {
                vari = txtProducto.Text.Trim();
                if (!string.IsNullOrEmpty(vari))
                {

                    this.dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    if (vari.Substring(0, 1) == "*" || vari.Substring(0, 1) == "+")
                    {
                        vari = vari.Substring(1);
                    }
                    if (vari.All(Char.IsLetter))
                    {
                        dgvLista.Rows[0].Selected = true;
                        dgvLista.Focus();
                    }
                    else
                    {
                        Cargarproducto();
                    }
                }
                else
                {
                    cerrarBoleta();
                }
            }
            if (e.KeyChar == 27)
            {
                if (!string.IsNullOrEmpty(txtProducto.Text.Trim()))
                {
                    txtProducto.Text = "";
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtTotal.Text.Trim()))
                    {
                        dgvGrid1.Rows.Clear();
                    }
                }
            }
            if (e.KeyChar == 120)
            {
                cambiaprecios();
            }
        }

        private void cerrarBoleta()
        {
            int vtot = (int)Convert.ToDouble(txtTotal.Text);
            if (vtot > 0 && cButton9.Visible == true)
            {
               cierreBoleta frm = new cierreBoleta();
               AddOwnedForm(frm);
               frm.ShowDialog();
            }
            else
            {
                if (vtot > 0 && cButton9.Visible == false)
                {
                    MessageBox.Show("DEBE HACER APERTURA DE CAJA");
                }

            }
            Sumarproductos();
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void dgvLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgvLista.SelectionMode = DataGridViewSelectionMode.CellSelect;
            if (e.KeyChar == 13)
            {
                int indice = dgvLista.CurrentRow.Index - 1;
                if (indice < 0) { indice = 0; }
                vari = Convert.ToString(dgvLista.Rows[indice].Cells[2].Value).Trim();
                upre = Convert.ToString(dgvLista.Rows[indice].Cells[6].Value).Trim();
                Cargarproducto();
            }
            if (e.KeyChar == 27)
            {
                Cargarproducto();
            }
        }

        private void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            vari = Convert.ToString(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells[2].Value).Trim();
            Cargarproducto();
        }

        public void Cargarproducto()
        {
            //BUSCAR REGISTRO
            int fila = 0;
            int cant = 0;
            int enc = 0;

            foreach (DataGridViewRow row in dgvGrid1.Rows)
            {
                if (row.Cells["CODIGO1"].Value != null)
                {
                    row.Selected = false;
                    fila += 1;
                    string ss = row.Cells["CODIGO1"].Value.ToString();
                    cant = Convert.ToInt32(row.Cells["CANTIDAD1"].Value.ToString());
                    ss = ss.Trim();
                    if (vari == ss)
                    {
                        enc = 1;
                        cant = Convert.ToInt32(row.Cells["CANTIDAD1"].Value.ToString()) + 1;
                        break;
                    }
                }
            }
            if (enc != 0)
            {
                dgvGrid1.Rows[fila - 1].Cells["CANTIDAD1"].Value = cant.ToString();
                dgvGrid1.Rows[fila - 1].Cells["PRECIO1"].Value = upre.ToString();
            }
            else
            {
                int renglon = 0;
                com = new SqlCommand("SELECT I.CODIGO,I.NOMBRE,E.CANTIDAD STOCK,CONVERT(numeric(10,0),ROUND(I.PRECIO1*1.19,-1)) PRECIO1,CONVERT(numeric(10,0),ROUND(I.PRECIO2*1.19,-1)) PRECIO2,I.PRINCIPIO,I.FOTO FROM INVENTARIO I LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE I.CODIGO = '" + vari + "' ", cn);
                com.ExecuteNonQuery();
                Dr = com.ExecuteReader();
                while (Dr.Read())
                {
                    renglon = dgvGrid1.Rows.Add();
                    dgvGrid1.Rows[renglon].Cells["Linea1"].Value = Convert.ToString(renglon + 1);
                    string vfoto = (string)Convert.ToString(Dr["FOTO"]);
                    if (vfoto.Trim() != "")
                    {
                        if (File.Exists(vfoto))
                        {
                            dgvGrid1.Rows[renglon].Cells["FOTO1"].Value = Image.FromFile(vfoto);
                        }
                    }
                    dgvGrid1.Rows[renglon].Cells["CODIGO1"].Value = Dr["CODIGO"] == DBNull.Value ? " " : Convert.ToString(Dr["CODIGO"]).Trim();
                    dgvGrid1.Rows[renglon].Cells["PRODUCTO1"].Value = Dr["NOMBRE"] == DBNull.Value ? " " : Convert.ToString(Dr["NOMBRE"]).Trim();
                    dgvGrid1.Rows[renglon].Cells["STOCK1"].Value = Dr["STOCK"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["STOCK"]);
                    dgvGrid1.Rows[renglon].Cells["CANTIDAD1"].Value = "1";
                    dgvGrid1.Rows[renglon].Cells["PRECIO1"].Value = Dr["PRECIO1"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["PRECIO1"]);
                    dgvGrid1.Rows[renglon].Cells["OFERTA1"].Value = Dr["PRECIO2"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["PRECIO2"]);
                    dgvGrid1.Rows[renglon].Cells["TOTAL1"].Value = Dr["PRECIO1"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["PRECIO1"]);
                }
                Dr.Close();
                if (renglon > 0)
                {
                    dgvGrid1.CurrentCell = dgvGrid1.Rows[renglon].Cells[0];
                }
            }
            Sumarproductos();
        }

        public void Sumarproductos()
        {
            asignavalores();
            int fila = 0;
            int cant;
            int prec, pre1, tpre;
            int ofer;
            int tot, toto;
            totf = 0;
            totp = 0;
            tots = 0;
            toti = 0;

            foreach (DataGridViewRow row in dgvGrid1.Rows)
            {
                if (row.Cells["CODIGO1"].Value != null)
                {
                    fila += 1;
                    cant = Convert.ToInt32(row.Cells["CANTIDAD1"].Value.ToString());
                    prec = Convert.ToInt32(row.Cells["PRECIO1"].Value.ToString());
                    pre1 = prec;
                    ofer = Convert.ToInt32(row.Cells["OFERTA1"].Value.ToString());
                    if (ofer > 0 && cant > 1)
                    {
                        prec = ofer;
                    }
                    if (!string.IsNullOrEmpty(textBox4.Text))
                    {
                        string cod = (row.Cells["CODIGO1"].Value.ToString());
                        com = new SqlCommand("SELECT * FROM COMPRAVENTA WHERE codigo = '" + cod + "' ", Form1.cn);
                        com.ExecuteNonQuery();
                        dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            prec = dr["COSTO"] == DBNull.Value ? 0 : Convert.ToInt32(Dr["COSTO"]);
                        }
                        dr.Close();
                    }
                    tot = cant * prec;
                    tpre = cant * pre1;
                    dgvGrid1.Rows[fila - 1].Cells["TOTAL1"].Value = tot;
                    tot = Convert.ToInt32(row.Cells["TOTAL1"].Value.ToString());
                    totf += tot;
                    totp += tpre;
                    tots = (int)Math.Round(totf / 1.19);
                    toti = totf - tots;
                }
            }
            txtTotal.Text = totf.ToString("N0");
            txtSubTotal.Text = tots.ToString("N0");
            txtIva.Text = toti.ToString("N0");
            textBox2.Text = totp.ToString("N0");
            toto = totp - totf;
            textBox3.Text = toto.ToString("N0");
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTicketsEmitidos_Click(object sender, EventArgs e)
        {
            ticketsEmitidos abrirTicketsEmitidos = new ticketsEmitidos();
            abrirTicketsEmitidos.ShowDialog();
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            iniciarSesion abririniciarSecion = new iniciarSesion();
            abririniciarSecion.ShowDialog();
            label14.Text = "Caja: " + iniciarSesion.ucaja.Trim() + " " + iniciarSesion.unombre.Trim();
            int position = eservidor.IndexOf(";");
            edatabase = eservidor.Substring(position + 18);
            eservidor = eservidor.Substring(14, position - 14);

            position = edatabase.IndexOf(";");
            edatabase = edatabase.Substring(1, position - 1);
            ufoto = iniciarSesion.ufoto.Trim();
            if (ufoto.Trim() != "")
            {
                if (File.Exists(ufoto))
                {
                    ovalShape1.BackgroundImage = Image.FromFile(ufoto);
                }
            }

            label16.Text = eservidor.ToString() + " (" + edatabase.ToString() + ")";
            //apertura de caja
            vuser = iniciarSesion.ucodigo.Trim();
            com = new SqlCommand("SELECT TOP 1 * FROM USUARIOS WHERE CODIGO = '" + vuser + "' ", cn);
            com.ExecuteNonQuery();
            Dr = com.ExecuteReader();
            while (Dr.Read())
            {
                uforma = Convert.ToString(Dr["FORMATO"]);
            }
            Dr.Close();
            if (uforma.Trim() == strHostName)
            {
                cButton9.Visible = true;
            }
            //
            txtProducto.ReadOnly = false;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

            vuser = iniciarSesion.ucodigo.Trim();
            com = new SqlCommand("SELECT TOP 1 * FROM USUARIOS WHERE CODIGO = '" + vuser + "' ", cn);
            com.ExecuteNonQuery();
            Dr = com.ExecuteReader();
            while (Dr.Read())
            {
                uforma = Convert.ToString(Dr["FORMATO"]);
            }
            Dr.Close();
            if (uforma.Trim() != "")
            {
                if (uforma.Trim() == strHostName)
                {
                    MessageBox.Show("SU CAJA YA ESTA APERTURADA EN ESTE COMPUTADOR");
                }
                else
                {
                    MessageBox.Show("SU CAJA YA ESTA APERTURADA EN EL COMPUTADOR: " + uforma.Trim());
                }
            }
            else
            {
                aperturaCaja frm = new aperturaCaja();
                frm.ShowDialog();
                if (montoape >= 0)
                {
                    string rec = "";
                    com = new SqlCommand("SELECT MAX(convert(int, RECIBO))+1 REXP FROM RECIBOS WHERE TIPO=1", cn);
                    com.ExecuteNonQuery();
                    Dr = com.ExecuteReader();
                    while (Dr.Read())
                    {
                        rec = Convert.ToString(Dr["REXP"]);
                    }
                    Dr.Close();
                    string cod = iniciarSesion.ucodigo.Trim();
                    string nom = iniciarSesion.unombre.Trim();
                    string con = "APERTURA DE CAJA: " + nom;
                    string caj = iniciarSesion.ucaja.Trim();
                    int mon = montoape;
                    com = new SqlCommand("INSERT INTO RECIBOS (CODIGO,RECIBO,FECHA,NOMBRE,CONCEPTO,CAJA,MONTO,TIPO) VALUES ('10','" + rec + "', '" + DateTime.Now + "','" + nom + "','" + con + "','" + caj + "'," + mon + "," + 1 + ") ", cn);
                    com.ExecuteNonQuery();

                    com = new SqlCommand("UPDATE USUARIOS SET FORMATO = '" + strHostName + "' WHERE CODIGO = '" + vuser + "' ", cn);
                    com.ExecuteNonQuery();
                    //Report Form reci To Printer Noconsole
                    MessageBox.Show("APERTURA DE CAJA SATISFACTORIA");
                    cButton9.Visible = true;
                }
            }
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void btnEgresoCaja_Click(object sender, EventArgs e)
        {
            egresoCaja abriregresoCajas = new egresoCaja();
            abriregresoCajas.ShowDialog();

            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void dgvGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            Sumarproductos();
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
            ComboBox combo = sender as ComboBox;
            int xcan = Convert.ToInt32(combo.SelectedIndex);
            xcan = xcan + 1;
            dgvGrid1.Rows[dgvGrid1.CurrentRow.Index].Cells[5].Value = xcan.ToString();
            Sumarproductos();

            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void dgvGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrid1.Rows.Count > 0)
            {
                if (dgvGrid1.CurrentCell.ColumnIndex == 9)
                {
                    dgvGrid1.Rows.Remove(dgvGrid1.CurrentRow);
                }
            }
            if (dgvGrid1.Rows.Count > 0)
            {
                if (dgvGrid1.CurrentCell.ColumnIndex == 6)
                {
                    cambiaprecios();
                }
            }

        }

        private void cambiaprecios()
        {
            newpre = "0";
            if (dgvGrid1.Rows.Count > 0)
            {
                cod = Convert.ToString(dgvGrid1.Rows[dgvGrid1.CurrentRow.Index].Cells[2].Value);
                cambiarPrecio frm = new cambiarPrecio();
                frm.ShowDialog();
                if (Convert.ToInt32(newpre.ToString()) > 0)
                {
                    dgvGrid1.Rows[dgvGrid1.CurrentRow.Index].Cells["PRECIO1"].Value = newpre.ToString();
                }
            }
            Sumarproductos();
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //TECLAS DEL FORM
            bool passed = false;
            if (keyData == Keys.F9)
            {
                if (dgvGrid1.Rows.Count > 0)
                {
                    cambiaprecios();
                    passed = false;
                }
            }
            if (keyData == Keys.F3) { liberarCaja(); }
            if (keyData == Keys.F4) { guardaDocumento(); }
            if (keyData == Keys.F5) { cargarDocumento(); }
            if (keyData == Keys.F6) { faltantes(); }
            if (keyData == Keys.F7) { stocktiendas(); }
            if (keyData == Keys.F8) { cerrarBoleta(); }
            return passed;
        }

        private void faltantes()
        {
            int vtot = (int)Convert.ToDouble(txtTotal.Text);
            if (vtot > 0)
            {
                string mcod, mnom;
                foreach (DataGridViewRow row in dgvGrid1.Rows)
                {
                    mcod = row.Cells["CODIGO1"].Value.ToString();
                    mnom = row.Cells["PRODUCTO1"].Value.ToString();

                    string sqlcom1 = "INSERT INTO LOGFILE (CODIGO,USUARIO,FECHA,ESTACION,TABLA,TEXTO,AVAR1,AVAR2) ";
                    string sqlcom2 = "VALUES (@mcod,@muse,@mfec,@mest,@mtab,@mtex,@mav1,@mav2)";
                    string sqlcom = sqlcom1 + sqlcom2;
                    com = new SqlCommand(sqlcom, Form1.cn);
                    com.Parameters.AddWithValue("@mcod", iniciarSesion.ucodigo.Trim());
                    com.Parameters.AddWithValue("@muse", iniciarSesion.unombre.Trim());
                    com.Parameters.AddWithValue("@mfec", DateTime.Now);
                    com.Parameters.AddWithValue("@mest", strHostName);
                    com.Parameters.AddWithValue("@mtab", "MFACTURAS");
                    com.Parameters.AddWithValue("@mtex", "Anulo venta del Articulo por: FALTANTE");
                    com.Parameters.AddWithValue("@mav1", mcod);
                    com.Parameters.AddWithValue("@mav2", mnom);
                    com.ExecuteNonQuery();
                }
                MessageBox.Show("PRODUCTOS INCLUIDOS A FALTANTES EN PEDIDOS");
                dgvGrid1.Rows.Clear();
                Sumarproductos();
            }
            else
            {
                string mtex = Microsoft.VisualBasic.Interaction.InputBox("INTRODUZCA NOMBRE DEL PRODUCTO A PEDIR", "FALTANTE PARA PEDIDOS");
                string sqlcom1 = "INSERT INTO LOGFILE (CODIGO,USUARIO,FECHA,ESTACION,TABLA,TEXTO,AVAR2) ";
                string sqlcom2 = "VALUES (@mcod,@muse,@mfec,@mest,@mtab,@mtex,@mav2)";
                string sqlcom = sqlcom1 + sqlcom2;
                com = new SqlCommand(sqlcom, Form1.cn);
                com.Parameters.AddWithValue("@mcod", iniciarSesion.ucodigo.Trim());
                com.Parameters.AddWithValue("@muse", iniciarSesion.unombre.Trim());
                com.Parameters.AddWithValue("@mfec", DateTime.Now);
                com.Parameters.AddWithValue("@mest", strHostName);
                com.Parameters.AddWithValue("@mtab", "MFACTURAS");
                com.Parameters.AddWithValue("@mtex", "Anulo venta del Articulo por: FALTANTE");
                com.Parameters.AddWithValue("@mav2", mtex.ToUpper());
                com.ExecuteNonQuery();
            }
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            Sumarproductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liberarCaja();
        }

        private void liberarCaja()
        {
            vuser = iniciarSesion.ucodigo.Trim();
            com = new SqlCommand("SELECT TOP 1 * FROM USUARIOS WHERE CODIGO = '" + vuser + "' ", cn);
            com.ExecuteNonQuery();
            Dr = com.ExecuteReader();
            while (Dr.Read())
            {
                uforma = Convert.ToString(Dr["FORMATO"]);
            }
            Dr.Close();
            if (uforma.Trim() != "")
            {
                if (uforma.Trim() == strHostName)
                {

                    DialogResult result = MessageBox.Show("DESEA USTED LIBERAR ESTA CAJA", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result.ToString() == "Yes")
                    {
                        com = new SqlCommand("UPDATE USUARIOS SET FORMATO = '' WHERE CODIGO = '" + vuser + "' ", cn);
                        com.ExecuteNonQuery();
                        MessageBox.Show("CAJA LIBERARADA EN ESTE EQUIPO");
                        cButton9.Visible = false;
                        Application.Exit();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("SU CAJA ESTA APERTURADA EN ESTE COMPUTADOR: ");
                }
            }
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void cButton1_Click(object sender, EventArgs e)
        {
            guardaDocumento();
        }

        private void guardaDocumento()
        {
            int vtot = (int)Convert.ToDouble(txtTotal.Text);
            if (vtot > 0)
            {
                //FACTURAS
                string num = "";
                com = new SqlCommand("SELECT MAX(convert(int, NUMERO))+1 REXP FROM FACTURAS", Form1.cn);
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    num = Convert.ToString(dr["REXP"]);
                }
                dr.Close();

                int des;
                DateTime mfec = DateTime.Now;
                des = Form1.totp - Form1.totf;

                //FACTURA
                string sqlcom1 = "INSERT INTO FACTURAS (MARCA,NUMERO,CODIGO,FECHA,MONTO,DESCUENTO,IVA,IMPUESTO,CAJAPERTUR,NOMBRE,DIRECCION,TELEFONOS,CORREO) ";
                string sqlcom2 = "VALUES ('GEMINIS','" + num + "','" + rut + "','" + DateTime.Now + "'," + tots + "," + des + "," + 19 + ",";
                string sqlcom3 = Form1.toti + ",'" + iniciarSesion.ucaja + "','" + nombre + "','" + direccion + "','" + telefono + "','" + correo + "') ";
                string sqlcom = sqlcom1 + sqlcom2 + sqlcom3;
                com = new SqlCommand(sqlcom, Form1.cn);
                com.ExecuteNonQuery();

                //MFACTURAS
                int mfila = 0;
                string mcod, mnom, mnum, mgru = "";
                double mcan, msto, mofe, mtot, mtpr, mmon, mcid = 0;
                double mcos = 0;
                double mp1 = 0;
                double mp2 = 0;
                double mdes = 0;
                double mpre, mpr1, mpsi;

                foreach (DataGridViewRow row in dgvGrid1.Rows)
                {
                    if (row.Cells["CODIGO1"].Value != null)
                    {
                        mfila += 1;
                        mcod = row.Cells["CODIGO1"].Value.ToString();
                        mnom = row.Cells["PRODUCTO1"].Value.ToString();
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

                        com = new SqlCommand("SELECT E.CANTIDAD STOCK,I.COSTO,I.PRECIO1,I.PRECIO2,I.GRUPO,E.CODID FROM INVENTARIO I LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE I.CODIGO = '" + mcod + "' ", Form1.cn);
                        com.ExecuteNonQuery();
                        dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            mcos = Convert.ToDouble(dr["COSTO"]);
                            mp1 = Convert.ToDouble(dr["PRECIO1"]);
                            mp2 = dr["PRECIO2"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PRECIO2"]);
                            msto = Convert.ToInt32(dr["STOCK"]);
                            mgru = Convert.ToString(dr["GRUPO"]);
                            mcid = Convert.ToInt32(dr["CODID"]);

                        }
                        dr.Close();

                        if (mcan > 1 && mp2 > 0) { mdes = (mp1 - mp2); }

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
                        com.Parameters.AddWithValue("@malma", Form1.alma);
                        com.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("DOCUMENTO GUARDADO CON EL Nro: " + num.ToString());
                dgvGrid1.Rows.Clear();
                Sumarproductos();
            }
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void cButton2_Click(object sender, EventArgs e)
        {
            cargarDocumento();
        }

        private void cargarDocumento()
        {
            cargadocum fcarga = new cargadocum();
            fcarga.ShowDialog();

            if (documc != "")
            {
                int renglon = 0;
                string comsql1 = "SELECT M.CODIGO,M.DESCRIP NOMBRE,E.CANTIDAD STOCK,CONVERT(numeric(10,0),ROUND(M.MONTO*1.19,-1)) PRECIO1,CONVERT(numeric(10,0),ROUND(I.PRECIO2*1.19,-1)) PRECIO2,I.PRINCIPIO,I.FOTO ";
                string comsql2 = "FROM MFACTURAS M LEFT JOIN INVENTARIO I ON I.CODIGO=M.CODIGO LEFT JOIN EXISTENCIA E ON E.CODIGO=I.CODIGO WHERE M.NUMERO = '" + documc + "' ORDER BY M.POSI";
                string comsql = comsql1 + comsql2;
                com = new SqlCommand(comsql, cn);
                com.ExecuteNonQuery();
                Dr = com.ExecuteReader();
                while (Dr.Read())
                {
                    renglon = dgvGrid1.Rows.Add();
                    dgvGrid1.Rows[renglon].Cells["Linea1"].Value = Convert.ToString(renglon + 1);
                    string vfoto = (string)Convert.ToString(Dr["FOTO"]);
                    if (vfoto.Trim() != "")
                    {
                        if (File.Exists(vfoto))
                        {
                            dgvGrid1.Rows[renglon].Cells["FOTO1"].Value = Image.FromFile(vfoto);
                        }
                    }
                    dgvGrid1.Rows[renglon].Cells["CODIGO1"].Value = Dr["CODIGO"] == DBNull.Value ? " " : Convert.ToString(Dr["CODIGO"]).Trim();
                    dgvGrid1.Rows[renglon].Cells["PRODUCTO1"].Value = Dr["NOMBRE"] == DBNull.Value ? " " : Convert.ToString(Dr["NOMBRE"]).Trim();
                    dgvGrid1.Rows[renglon].Cells["STOCK1"].Value = Dr["STOCK"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["STOCK"]);
                    dgvGrid1.Rows[renglon].Cells["CANTIDAD1"].Value = "1";
                    dgvGrid1.Rows[renglon].Cells["PRECIO1"].Value = Dr["PRECIO1"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["PRECIO1"]);
                    dgvGrid1.Rows[renglon].Cells["OFERTA1"].Value = Dr["PRECIO2"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["PRECIO2"]);
                    dgvGrid1.Rows[renglon].Cells["TOTAL1"].Value = Dr["PRECIO1"] == DBNull.Value ? 0 : Convert.ToDouble(Dr["PRECIO1"]);
                }
                Dr.Close();
                if (renglon > 0)
                {
                    dgvGrid1.CurrentCell = dgvGrid1.Rows[renglon].Cells[0];
                }
            }
            Sumarproductos();
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void cButton7_Click(object sender, EventArgs e)
        {
            liberarCaja();
        }

        private void cButton4_Click(object sender, EventArgs e)
        {
            cambiaprecios();
        }

        private void cButton6_Click(object sender, EventArgs e)
        {
            faltantes();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            int vtot = (int)Convert.ToDouble(txtTotal.Text);
            if (vtot > 0)
            {
                MessageBox.Show("DEBE FINALIZAR VENTA BOLETA ");
                txtProducto.Text = "";
                txtProducto.Focus();
            }
            else
            {
                cierredecaja abrircierre = new cierredecaja();
                abrircierre.ShowDialog();
                txtProducto.Text = "";
                txtProducto.Focus();
            }
        }

        private void cButton9_VisibleChanged(object sender, EventArgs e)
        {
            if (cButton9.Visible)
            {
                cButton9.Left = cButton13.Left;
                cButton13.Left = cButton12.Left;
                cButton12.Left = cButton8.Left;
                cButton8.Left = cButton11.Left;
                cButton11.Left = cButton10.Left;
            }
            else
            {
                cButton13.Left = cButton12.Left;
                cButton12.Left = cButton8.Left;
                cButton8.Left = cButton11.Left;
                cButton11.Left = cButton10.Left;
            }
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            if (panel1.Visible) { panel7.Visible = false; } else { panel7.Visible = true; }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            int vtot = (int)Convert.ToDouble(txtTotal.Text);
            if (vtot > 0)
            {

                //RepTicket rep = new RepTicket();
                LocalReport report = new LocalReport();
                report.DataSources.Clear();

                Form1.MiReporte = "Informes\\Cotizacion.rdlc";

                foreach (DataGridViewRow row in dgvGrid1.Rows)
                {
                    TicketDatos dat = new TicketDatos();
                    dat.Codigo = row.Cells["CODIGO1"].Value.ToString();
                    dat.Nombre = row.Cells["PRODUCTO1"].Value.ToString();
                    dat.Cantidad = row.Cells["CANTIDAD1"].Value.ToString();
                    double pre = (double)row.Cells["PRECIO1"].Value;
                    dat.Precio = pre.ToString("N0");
                    TicketDatos.Add(dat);
                }
                //rep.ShowDialog();
                report.DataSources.Add(new ReportDataSource("DataSet1", TicketDatos));
                report.ReportPath = (Form1.MiReporte);

                string vRif = erif.Trim();
                string vCaja = iniciarSesion.ucodigo.Trim();

                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("rRif", vRif);
                parameters[1] = new ReportParameter("rCaja", vCaja);

                report.SetParameters(parameters);
                report.PrintToPrinter();
                dgvGrid1.Rows.Clear();
                Sumarproductos();
            }
            txtProducto.Text = "";
            txtProducto.Focus();
        }

        private void cButton3_Click(object sender, EventArgs e)
        {
            stocktiendas();
        }

        private void cButton9_Click(object sender, EventArgs e)
        {
            int vtot = (int)Convert.ToDouble(txtTotal.Text);
            if (vtot > 0)
            {
                MessageBox.Show("DEBE FINALIZAR VENTA BOLETA ");
                txtProducto.Text = "";
                txtProducto.Focus();
            }
            else
            {
                cierredecaja abrircierre = new cierredecaja();
                abrircierre.ShowDialog();
                txtProducto.Text = "";
                txtProducto.Focus();
            }
        }

        private void cButton5_Click(object sender, EventArgs e)
        {
            cerrarBoleta();
        }

        private void cButton11_ClickButtonArea(object Sender, MouseEventArgs e)
        {
        }

        private void cButton8_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            clsImprimir printmir;
            printmir = new clsImprimir();
            if (dgvGrid1.Rows.Count > 0)
            {
                printmir.CargarImprimir(dgvGrid1, imprimirDocument, null, "Cotización");

                txtProducto.Text = "";
                txtProducto.Focus();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClsImprimirCierre cierrP;
            cierrP = new ClsImprimirCierre();
            cierrP.imprimirCierre(imprimirDocument, 420);
            
        }

        private void btton2_Click(object sender, EventArgs e)
        {
            cierreCajaTest cct = new cierreCajaTest();
            cct.ShowDialog();
        }

        private void stocktiendas() 
        {
            Stock abrirstock = new Stock();
            abrirstock.ShowDialog();
            txtProducto.Text = "";
            txtProducto.Focus();
        }
    }
}

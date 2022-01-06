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

namespace ptoVenta
{
    public partial class iniciarSesion :Form 
    {

        SqlCommand com;
        SqlDataReader ur;
        public static string ucodigo = "";
        public static string unombre = "";
        public static string uperfil = "";
        public static string ucaja = "";
        public static string ufoto = "";

        public iniciarSesion()
        {
            InitializeComponent();
            this.Opacity = 0.98;
        }

        private void iniciarSesion_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM USUARIOS ORDER BY NOMBRE", Form1.cn);
            da.Fill(ds, "USUARIOS");
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.ValueMember = "CODIGO";
            string[] lines = System.IO.File.ReadAllLines(@"sesion.ini");
            string sesion = "";
            foreach (string line in lines)
            {
                sesion = line;
            }
            int index = comboBox1.FindString(sesion);
            comboBox1.SelectedIndex = index;
            SendKeys.Send("{TAB}");
        }

        private void iniciarSesion_Shown(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(Location);
            int al = scr.WorkingArea.Height + 10;
            this.Height = al;
            for (int i = Width * -1; i < -10; )

            {
                i = (int)(i + 0.5);
                Location = new Point(i, 0);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vuser = comboBox1.Text.Trim();
            string vfoto = "";
            if (!String.IsNullOrEmpty(vuser))
                com = new SqlCommand("SELECT TOP 1 * FROM USUARIOS WHERE CODIGO = '" + vuser + "' ", Form1.cn);
            com.ExecuteNonQuery();
            ur = com.ExecuteReader();
            while (ur.Read())
            {
                vfoto = "pfp//"+Convert.ToString(ur["EMAIL"]).Trim().ToUpper();
            }
            ur.Close();
            pictureBox1.BackgroundImage = Image.FromFile("pfp\\user.jpg");

            if (vfoto.Trim() != "")
            {
                if (File.Exists(vfoto))
                {
                    pictureBox1.BackgroundImage = Image.FromFile(vfoto);
                    ufoto = vfoto;
                }
            }
            txtRut1.Focus();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                Application.Exit();
                this.Close();
            }
            if (e.KeyChar == 13)
            {
                txtRut1.Focus();
            }
                
        }

        private void txtRut1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                Application.Exit();
                this.Close();
            }
            if (e.KeyChar == 13)
            {
                string vclave = txtRut1.Text.Trim();
                string vuser = comboBox1.Text.Trim();
                if (String.IsNullOrEmpty(vuser) | String.IsNullOrEmpty(vclave))
                {
                    txtRut1.Text = "";
                    txtRut1.Focus();
                }
                else
                {
                    string uclave = " ";
                    unombre = " ";
                    ucodigo = " ";
                    uperfil = " ";
                    ucaja = " ";

                    com = new SqlCommand("SELECT TOP 1 * FROM USUARIOS WHERE CODIGO = '"+vuser+"' AND DPTO = '"+vclave+"' ", Form1.cn);
                    com.ExecuteNonQuery();
                    ur = com.ExecuteReader();
                    while (ur.Read())
                    {

                        uclave = Convert.ToString(ur["DPTO"]);
                        unombre = Convert.ToString(ur["NOMBRE"]);
                        ucodigo = Convert.ToString(ur["CODIGO"]);
                        uperfil = Convert.ToString(ur["CPERFIL"]);
                        ucaja = Convert.ToString(ur["CAJA"]);
                    }
                    ur.Close();
                    if (vclave.Trim() == uclave.Trim())
                    {
                        string text = ucodigo.ToString();
                        System.IO.File.WriteAllText(@"sesion.ini",text);
                        this.Close();
                    }
                    else
                    {
                        txtRut1.Text = "";
                        txtRut1.Focus();
                    }
                }
            }
        }

        private void cButton39_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            CambiarContraseña cbc = new CambiarContraseña();
            cbc.ShowDialog();
        }
    }


 }

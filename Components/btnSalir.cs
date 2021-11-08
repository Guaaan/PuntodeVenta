using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btnLib
{
    public partial class btnSalir : UserControl
    {
        private Color arribColor;
        private Color abajColor;
        private Color arribHover;
        private Color abajHover;

        private Size tamaño;
        private Image img;
        private Size imgSize;

        private String text= "Salir";




        [Category("Colores")]
        public Color Color1_Arriba
        {
            get
            {
                return abajColor;
            }
            set
            {
                abajColor = value;
                botonSalir.BaseColor1 = abajColor;
            }
        }
        [Category("Colores")]
        public Color Color2_Abajo
        {
            get
            {
                return arribColor;
            }
            set
            {
                arribColor = value;
                botonSalir.BaseColor2 = arribColor;

            }
        }

        [Category("Colores")]
        public Color Hover1_Arriba
        {
            get
            {
                return arribHover;
            }
            set
            {
                arribHover = value;
                botonSalir.OnHoverBaseColor1 = arribHover;
            }
        }
        [Category("Colores")]
        public Color Hover2_Abajo
        {
            get
            {
                return abajHover;
            }
            set
            {
                abajHover = value;
                botonSalir.OnHoverBaseColor2 = abajHover;
            }
        }
        [Category("Editores")]
        public Size Tamaño_Boton
        {
            get
            {
                return tamaño;
            }

            set
            {
                tamaño = value;
                botonSalir.Size = tamaño;
                this.Size = tamaño;
            }
        }
        [Category("Texto")]
        public String Texto
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                botonSalir.Text = text;
            }
        }

        public enum TextoAlineo
        {
            Center,
            Left,
            Right
        }
        TextoAlineo textoAlineo;
        [Category("Texto")]
        public TextoAlineo Alineacion_texto
        {
            get { return textoAlineo; }
            set
            {
                textoAlineo = value; Invalidate();
                switch (textoAlineo)
                {
                    case TextoAlineo.Center:
                        botonSalir.TextAlign = HorizontalAlignment.Center;
                        break;

                    case TextoAlineo.Right:
                        botonSalir.TextAlign = HorizontalAlignment.Right;
                        break;

                    case TextoAlineo.Left:
                        botonSalir.TextAlign = HorizontalAlignment.Left;
                        break;

                }
            }
        }

        [Category("Imagen")]
        public Image Imagen
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
                botonSalir.Image = img;
            }
        }
        [Category("Imagen")]
        public Size Tamaño_imagen
        {
            get
            {
                return imgSize;
            }
            set
            {
                imgSize = value;
                botonSalir.ImageSize = imgSize;
            }
        }



        public btnSalir()
        {
            InitializeComponent();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
    }
}

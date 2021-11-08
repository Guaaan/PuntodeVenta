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
    public partial class btnAceptar : UserControl
    {
        private Color arribColor;
        private Color abajColor;
        private Color arribHover;
        private Color abajHover;

        private Size tamaño;
        private Image img;
        private Size imgSize;

        private String text = "Botón";
        private int bRadius = 8;





        [Category("Editores")]
        public Color Color1_Arriba
        {
            get
            {
                return abajColor;
            }
            set
            {
                abajColor = value;
                botonAceptar.BaseColor1 = abajColor;
            }
        }
        [Category("Editores")]
        public Color Color2_Abajo
        {
            get
            {
                return arribColor;
            }
            set
            {
                arribColor = value;
                botonAceptar.BaseColor2 = arribColor;

            }
        }

        [Category("Editores")]
        public Color Hover1_Arriba
        {
            get
            {
                return arribHover;
            }
            set
            {
                arribHover = value;
                botonAceptar.OnHoverBaseColor1 = arribHover;
            }
        }
        [Category("Editores")]
        public Color Hover2_Abajo
        {
            get
            {
                return abajHover;
            }
            set
            {
                abajHover = value;
                botonAceptar.OnHoverBaseColor2 = abajHover;
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
                botonAceptar.Size = tamaño;
                this.Size = tamaño;
            }
        }
        [Category("Editores")]
        public String Texto
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                botonAceptar.Text = text = text.Replace("@", "" + "\n");
            }
        }

        public enum TextoAlineo
        {
            Center,
            Left,
            Right
        }
        TextoAlineo textoAlineo;

        [Category("Editores")]
        public TextoAlineo Alineacion_texto
        {
            get { return textoAlineo; }
            set
            {
                textoAlineo = value; Invalidate();
                switch (textoAlineo)
                {
                    case TextoAlineo.Center:
                        botonAceptar.TextAlign = HorizontalAlignment.Center;
                        break;

                    case TextoAlineo.Right:
                        botonAceptar.TextAlign = HorizontalAlignment.Right;
                        break;

                    case TextoAlineo.Left:
                        botonAceptar.TextAlign = HorizontalAlignment.Left;
                        break;

                }
            }
        }

        [Category("Editores")]
        public Image Imagen
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
                botonAceptar.Image = img;
            }
        }
        [Category("Editores")]
        public Size Tamaño_imagen
        {
            get
            {
                return imgSize;
            }
            set
            {
                imgSize = value;
                botonAceptar.ImageSize = imgSize;
            }
        }

        [Category("Editores")]
        public int Radio
        {
            get { return bRadius; }
            set
            {
                bRadius = value;
                botonAceptar.Radius = bRadius;
            }

        }

        public btnAceptar()
        {
            InitializeComponent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace btnLib
{
    public partial class UserControl1 : GunaGradientButton
    {
        private Color arribColor;
        private Color abajColor;
        private Color arribHover;
        private Color abajHover;

        private Size tamaño;
        private Image img;
        private Size imgSize;

        private String text = "Salir";
        private String textSalir = "Salir";




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
                this.BaseColor1 = abajColor;
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
                this.BaseColor2 = arribColor;

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
                this.OnHoverBaseColor1 = arribHover;
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
                this.OnHoverBaseColor2 = abajHover;
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
                this.Size = tamaño;
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
                
                this.Text = textSalir;
                
                this.Text = text = text.Replace("@", "" + "\n");

                

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
                        this.TextAlign = HorizontalAlignment.Center;
                        break;

                    case TextoAlineo.Right:
                        this.TextAlign = HorizontalAlignment.Right;
                        break;

                    case TextoAlineo.Left:
                        this.TextAlign = HorizontalAlignment.Left;
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
                this.Image = img;
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
                this.ImageSize = imgSize;
            }
        }


        public UserControl1()
        {
            InitializeComponent();
        }
    }
}

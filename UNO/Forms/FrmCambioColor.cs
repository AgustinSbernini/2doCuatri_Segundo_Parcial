using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmCambioColor : Form
    {
        Colores colorElegido;
        public delegate void CambiarColor(Colores color);

        public CambiarColor cambiarColor;

        public FrmCambioColor()
        {
            InitializeComponent();
            cambiarColor += FrmJuegoEnPartida.cambioColorHecho;
        }

        private void BtnElegido(object sender, EventArgs e)
        {
            if (btnRojo.Focused)
            {
                colorElegido = Colores.Rojo;
            }
            else
            {
                if (btnAzul.Focused)
                {
                    colorElegido = Colores.Azul;
                }
                else
                {
                    if (btnVerde.Focused)
                    {
                        colorElegido = Colores.Verde;
                    }
                    else
                    {
                        if (btnAmarillo.Focused)
                        {
                            colorElegido = Colores.Amarillo;
                        }
                    }
                }
            }

            cambiarColor.Invoke(colorElegido);

            this.Close();
        }


    }
}

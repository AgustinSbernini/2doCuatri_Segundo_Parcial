using System;
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

        // Dependiendo el color elegido con los botones es el que se guarda en la variable
        // Para ejecutar con el delegado en el Form de la Partida
        private void BtnElegido(object sender, EventArgs e)
        {
            if (this.btnRojo.Focused)
            {
                colorElegido = Colores.Rojo;
            }
            else
            {
                if (this.btnAzul.Focused)
                {
                    colorElegido = Colores.Azul;
                }
                else
                {
                    if (this.btnVerde.Focused)
                    {
                        colorElegido = Colores.Verde;
                    }
                    else
                    {
                        if (this.btnAmarillo.Focused)
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

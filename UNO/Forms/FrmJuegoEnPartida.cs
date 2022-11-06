using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca_de_clases;

namespace Forms
{
    public partial class FrmJuegoEnPartida : Form
    {
        private List<Cartas> mazoDeCartas;
        private List<Usuarios> listaJugadores;
        private List<Cartas> cartasJugadas;
        private Cartas cartaMesa;
        private Usuarios user;
        private int numJugadores;
        private FrmCambioColor frmCambioColor;
        private static Colores colorElegido;


        public FrmJuegoEnPartida()
        {
            InitializeComponent();
            this.frmCambioColor = new();
            this.listaJugadores = new();
            this.cartasJugadas = new();

        }
        public FrmJuegoEnPartida(Usuarios user, int numJugadores) : this()
        {
            this.user = user;
            this.numJugadores = numJugadores;
        }
        private void FrmJuegoEnPartida_Load(object sender, EventArgs e)
        {
            this.mazoDeCartas = Cartas.MazoDeCartas();
            this.listaJugadores.Add(this.user);

            // Crea la cantidad de usuarios necesarios para rellenar la mesa y los guarda en una lista
            for (int i = 0; i < numJugadores - 1; i++)
            {
                Usuarios usuarioAux = new("Aux", "Aux");
                this.listaJugadores.Add(usuarioAux);
            }
           
            // Reparte 7 cartas a cada jugador, dando una a una a cada uno y quita la carta del mazo
            for(int j = 0; j < 7; j++)
            {
                for (int i = 0; i < numJugadores; i++)
                {
                    Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                }   
            }

            foreach(Cartas carta in user.CartasEnMano)
            {
                this.ManoCartas.Items.Add(carta);
            }

            // Arreglar para hacer dinamico. Numero de cartas de cada jugador
            lblJugador2.Text = listaJugadores[1].CartasEnMano.Count.ToString();
            lblJugador3.Text = listaJugadores[2].CartasEnMano.Count.ToString();
            lblJugador4.Text = listaJugadores[3].CartasEnMano.Count.ToString();

            // Carta que se juega al medio al inicio de la partida
            this.cartaMesa = Cartas.RepartirCarta(this.mazoDeCartas);
            while(this.cartaMesa.Color == Colores.Negro)
            {
                this.mazoDeCartas.Add(this.cartaMesa);
                this.cartaMesa = Cartas.RepartirCarta(this.mazoDeCartas);
            }

            this.lblCartaMesa.Text = cartaMesa.ToString();
            this.pbCartaMesa.Image = Image.FromFile(cartaMesa.Imagen);        
        }

        private void ManoCartas_Click(object sender, EventArgs e)
        {
            if(this.ManoCartas.Items.Contains(cartaMesa))
            {
                if (this.ManoCartas.SelectedItem as Cartas == cartaMesa)
                {
                    this.cartasJugadas.Add(this.cartaMesa);
                    this.cartaMesa = this.ManoCartas.SelectedItem as Cartas;
                    this.user.CartasEnMano.Remove(this.ManoCartas.SelectedItem as Cartas);
                    this.ManoCartas.Items.RemoveAt(this.ManoCartas.SelectedIndex);
                    this.lblCartaMesa.Text = cartaMesa.ToString();
                    this.pbCartaMesa.Image = Image.FromFile(cartaMesa.Imagen);
                    if (this.cartaMesa.Color == Colores.Negro)
                    {
                        frmCambioColor.ShowDialog();
                        Cartas.cambioColor(this.cartaMesa, colorElegido);
                        this.lblCartaMesa.Text = cartaMesa.ToString() + " Color: " + colorElegido;
                    }          
                }
            }
            else
            {
                Cartas.RepartirCarta(this.user, this.mazoDeCartas);
                this.ManoCartas.Items.Clear();
                foreach (Cartas carta in user.CartasEnMano)
                {
                    this.ManoCartas.Items.Add(carta);
                }
            }
        }

        public static void cambioColorHecho(Colores color)
        {
            colorElegido = color;
        }

        public void turnoBots(bool sentidoHorario)
        {
            if(sentidoHorario)
            {

            }
        }
    }
}

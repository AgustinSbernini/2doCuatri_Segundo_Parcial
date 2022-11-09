using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private List<Label> listaLabelsCartasEnMano;
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
            this.listaLabelsCartasEnMano = new();
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
            this.listaLabelsCartasEnMano.Add(lblJugador1TotalCartas);
            this.listaLabelsCartasEnMano.Add(lblJugador2TotalCartas);
            this.listaLabelsCartasEnMano.Add(lblJugador3TotalCartas);
            this.listaLabelsCartasEnMano.Add(lblJugador4TotalCartas);
            this.lblCartaMesa.Visible = false;

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
            lblJugador2TotalCartas.Text = listaJugadores[1].CartasEnMano.Count.ToString();
            lblJugador3TotalCartas.Text = listaJugadores[2].CartasEnMano.Count.ToString();
            lblJugador4TotalCartas.Text = listaJugadores[3].CartasEnMano.Count.ToString();

            // Carta que se juega al medio al inicio de la partida
            this.cartaMesa = Cartas.RepartirCarta(this.mazoDeCartas);
            while(this.cartaMesa.Color == Colores.Negro)
            {
                this.mazoDeCartas.Add(this.cartaMesa);
                this.cartaMesa = Cartas.RepartirCarta(this.mazoDeCartas);
            }

            this.pbCartaMesa.BackgroundImage = Image.FromFile(cartaMesa.Imagen);
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
                    this.pbCartaMesa.BackgroundImage = Image.FromFile(cartaMesa.Imagen);

                    if (this.cartaMesa.Color == Colores.Negro)
                    {
                        frmCambioColor.ShowDialog();
                        Cartas.cambioColor(this.cartaMesa, colorElegido);
                        this.lblCartaMesa.Visible = true;
                        this.lblCartaMesa.Text = "Color Elegido: " + colorElegido;
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
            partidaEnJuego();
        }

        public static void cambioColorHecho(Colores color)
        {
            colorElegido = color;
        }

        private void partidaEnJuego()
        {
            int i = 0;
            Task task = Task.Run(() =>
            {
                while(i != 0)
                //while (listaJugadores[0].CartasEnMano.Count != 0 && listaJugadores[1].CartasEnMano.Count != 0
                //    && listaJugadores[2].CartasEnMano.Count != 0 && listaJugadores[3].CartasEnMano.Count != 0)
                {
                    Thread.Sleep(1000);
                    lblContador.Text = "3";
                    Thread.Sleep(1000);
                    lblContador.Text = "2";
                    Thread.Sleep(1000);
                    lblContador.Text = "1";
                    i = turnoBots(i); 
                }
            });
        }
        private int turnoBots(int i)
        {
            Efectos efectoGenerado;
            bool rondaSentidoReloj = true;

            efectoGenerado = JugarCarta(listaJugadores[i]);
                
            listaLabelsCartasEnMano[i].Text = listaJugadores[i].CartasEnMano.Count().ToString();

            if(rondaSentidoReloj)
            {
                switch (efectoGenerado)
                {
                    case Efectos.RobaDos:
                        i = ConsultarIndice(i, +1);
                        Cartas.RepartirCarta(listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(listaJugadores[i], this.mazoDeCartas);
                        break;

                    case Efectos.RobaCuatro:
                        i = ConsultarIndice(i, +1);
                        for (int j = 0; j < 3; j++)
                        {
                            Cartas.RepartirCarta(listaJugadores[i], this.mazoDeCartas);
                        }
                        Cartas.cambioColor(this.cartaMesa, out colorElegido);
                        this.lblCartaMesa.Visible = true;
                        this.lblCartaMesa.Text = "Color Elegido: " + colorElegido;
                        break;

                    case Efectos.CambioColor:
                        Cartas.cambioColor(this.cartaMesa, out colorElegido);
                        this.lblCartaMesa.Visible = true;
                        this.lblCartaMesa.Text = "Color Elegido: " + colorElegido;
                        break;

                    case Efectos.CambioSentido:
                        rondaSentidoReloj = false;
                        i = ConsultarIndice(i, -1); // Se le resta dos. Uno para compensar el que se suma despues y
                        i = ConsultarIndice(i, -1); // otro para que empiece el jugador anterior al que jugó la carta
                        break;

                    case Efectos.Bloqueo:
                        i = ConsultarIndice(i, +1);
                        break;

                    default:
                        break;
                }

                i = ConsultarIndice(i, +1);
            }
            else
            {
                switch (efectoGenerado)
                {
                    case Efectos.RobaDos:
                        i = ConsultarIndice(i, -1);
                        Cartas.RepartirCarta(listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(listaJugadores[i], this.mazoDeCartas);
                        break;

                    case Efectos.RobaCuatro:
                        i = ConsultarIndice(i, -1);
                        for (int j = 0; j < 3; j++)
                        {
                            Cartas.RepartirCarta(listaJugadores[i], this.mazoDeCartas);
                        }
                        Cartas.cambioColor(this.cartaMesa, out colorElegido);
                        this.lblCartaMesa.Visible = true;
                        this.lblCartaMesa.Text = "Color Elegido: " + colorElegido;
                        break;

                    case Efectos.CambioColor:
                        Cartas.cambioColor(this.cartaMesa, out colorElegido);
                        this.lblCartaMesa.Visible = true;
                        this.lblCartaMesa.Text = "Color Elegido: " + colorElegido;
                        break;

                    case Efectos.CambioSentido:
                        rondaSentidoReloj = true;
                        i = ConsultarIndice(i, +1); // Se le resta dos. Uno para compensar el que se suma despues y
                        i = ConsultarIndice(i, +1); // otro para que empiece el jugador anterior al que jugó la carta
                        break;

                    case Efectos.Bloqueo:
                        i = ConsultarIndice(i, -1);
                        break;

                    default:
                        break;
                }

                i = ConsultarIndice(i, -1);
            }
            
            return i;
        }

        private int ConsultarIndice(int indice,int modificador)
        {
            int nuevoIndice = indice;
            nuevoIndice += modificador;

            if (nuevoIndice < 0)
            {
                nuevoIndice = 3;
            }
            else
            {
                if (nuevoIndice > 3)
                {
                    nuevoIndice = 0;
                }
            }

            return nuevoIndice;
        }

        public Efectos JugarCarta(Usuarios usuario)
        {
            bool encontroCarta = false;
            Cartas cartaAux = null;
            foreach (Cartas carta in usuario.CartasEnMano)
            {
                if(carta == cartaMesa)
                {
                    this.cartasJugadas.Add(this.cartaMesa);
                    this.cartaMesa = carta;
                    usuario.CartasEnMano.Remove(carta);                
                    this.pbCartaMesa.BackgroundImage = Image.FromFile(cartaMesa.Imagen);
                    
                    encontroCarta = true;
                    cartaAux = carta;
                    break;
                }
            }

            if(!encontroCarta)
            {
                Cartas.RepartirCarta(usuario, this.mazoDeCartas);
            }

            return cartaAux is null ? Efectos.Ninguno : cartaAux.Efecto;
        }

        private void pbCartaMesa_BackgroundImageChanged(object sender, EventArgs e)
        {
            lblCartaMesa.Visible = false;
        }
    }
}

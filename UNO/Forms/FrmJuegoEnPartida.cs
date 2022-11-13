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
        private List<PictureBox> listaPBCantarUno;
        private Cartas cartaMesa;
        private Cartas cartaMano;
        private Usuarios user;
        private UsuariosDB dataBase;
        private int numeroUser;
        private int numeroCancelarTarea;
        private bool soloBots;
        private bool empezoPartidaBots;
        private FrmCambioColor frmCambioColor;
        private static Colores colorElegido;
        private bool imagenTachada;
        private bool rondaSentidoReloj;
        private bool cerrarJuegoSeguro;
        private bool banderaGanador;
        private Efectos efectoGenerado;
        private string turnoUser;
        private FrmHistorialPartida frmHistorialPartida;
        private StringBuilder historial;
        public delegate void ActualizarHistorial(string historialRecibido);
        public ActualizarHistorial actualizarHistorial;
        private int cantidadCartas;

        public FrmJuegoEnPartida()
        {
            InitializeComponent();
            this.frmCambioColor = new();
            this.listaJugadores = new();
            this.cartasJugadas = new();
            this.listaLabelsCartasEnMano = new();
            this.historial = new();
            this.listaPBCantarUno = new();
            this.frmHistorialPartida = null;
            this.actualizarHistorial += FrmHistorialPartida.ActualizarHistorial;
        }
        public FrmJuegoEnPartida(Usuarios user, bool soloBots, int cantidadCartas) : this()
        {
            this.soloBots = soloBots;
            this.dataBase = new();
            this.cantidadCartas = cantidadCartas;
            if (this.soloBots)
            {
                this.numeroUser = -1;
                this.empezoPartidaBots = false;
                this.user = this.dataBase.LogearUsuario("Jugador 1", "Aux");
            }
            else
            {
                this.numeroUser = 0;
                this.user = user;
            }
        }
        private void FrmJuegoEnPartida_Load(object sender, EventArgs e)
        {
            this.mazoDeCartas = Cartas.MazoDeCartas();
            this.listaJugadores.Add(this.user);
            this.listaLabelsCartasEnMano.Add(lblJugador1TotalCartas);
            this.listaLabelsCartasEnMano.Add(lblJugador2TotalCartas);
            this.listaLabelsCartasEnMano.Add(lblJugador3TotalCartas);
            this.listaLabelsCartasEnMano.Add(lblJugador4TotalCartas);
            this.listaPBCantarUno.Add(pbJugador1);
            this.listaPBCantarUno.Add(pbJugador2);
            this.listaPBCantarUno.Add(pbJugador3);
            this.listaPBCantarUno.Add(pbJugador4);
            this.lblCartaMesa.Visible = false;
            this.imagenTachada = false;
            this.rondaSentidoReloj = true;
            this.efectoGenerado = Efectos.Ninguno;
            this.turnoUser = "Es tu turno!";
            this.lblContador.Text = this.turnoUser;
            this.cerrarJuegoSeguro = false;
            this.banderaGanador = true;
            
            // Crea la cantidad de usuarios necesarios para rellenar la mesa y los guarda en una lista
            for (int i = 2; i < 5; i++)
            {
                Usuarios usuarioAux = this.dataBase.LogearUsuario($"Jugador {i}", "Aux");
                this.listaJugadores.Add(usuarioAux);
            }

            // Reparte la cantidad de cartas indicada a cada jugador, dando una a una a cada uno
            // y quita la carta del mazo
            for(int j = 0; j < this.cantidadCartas; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                }   
            }

            foreach (Cartas carta in this.user.CartasEnMano)
            {
                this.lstManoCartas.Items.Add(carta);
            }

            this.lblJugador2TotalCartas.Text = this.listaJugadores[1].CartasEnMano.Count.ToString();
            this.lblJugador3TotalCartas.Text = this.listaJugadores[2].CartasEnMano.Count.ToString();
            this.lblJugador4TotalCartas.Text = this.listaJugadores[3].CartasEnMano.Count.ToString();

            // Carta que se juega al medio al inicio de la partida
            this.cartaMesa = Cartas.RepartirCarta(this.mazoDeCartas);
            while(this.cartaMesa.Especial)
            {
                this.mazoDeCartas.Add(this.cartaMesa);
                this.cartaMesa = Cartas.RepartirCarta(this.mazoDeCartas);
            }

            this.pbCartaMesa.BackgroundImage = Image.FromFile(this.cartaMesa.Imagen);

            if(this.soloBots)
            {
                btnTirarCarta.Text = "Empezar Partida";
            }
        }

        private void btnTirarCarta_Click(object sender, EventArgs e)
        {
            if(this.soloBots)
            {
                if (!this.empezoPartidaBots)
                {
                    partidaEnJuego(0);
                    this.empezoPartidaBots = true;
                    this.btnTirarCarta.Text = "Terminar Partida";
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                if (this.lblContador.Text == this.turnoUser)
                {
                    Cartas cartaAux = this.lstManoCartas.SelectedItem as Cartas;
                    if(cartaAux == this.cartaMesa)
                    {
                        int i = 0;

                        this.cartasJugadas.Add(this.cartaMesa);
                        this.cartaMesa = cartaAux;
                        this.user.CartasEnMano.Remove(cartaAux);
                        this.lstManoCartas.Items.RemoveAt(this.lstManoCartas.SelectedIndex);
                        this.historial.AppendLine($"{user.Usuario} tiró {cartaMesa}");
                        this.pbCartaMesa.BackgroundImage = Image.FromFile(this.cartaMesa.Imagen);

                        if (this.cartaMesa.Color == Colores.Negro)
                        {
                            frmCambioColor.ShowDialog();
                            Cartas.cambioColor(this.cartaMesa, colorElegido);
                            this.lblCartaMesa.Visible = true;
                            this.lblCartaMesa.Text = "Color Elegido: " + colorElegido;
                        }

                        if(this.user.CartasEnMano.Count != 0)
                        {
                            i = logicaEfectos(this.cartaMesa.Efecto, this.rondaSentidoReloj, i);

                            this.actualizarHistorial.Invoke(this.historial.ToString());

                            partidaEnJuego(i);
                        }
                    }
                }
            }
        }

        private void lstManoCartas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cartaMano = this.lstManoCartas.SelectedItem as Cartas;
            try
            {
                this.pbCartaMano.BackgroundImage = Image.FromFile(this.cartaMano.Imagen);
            }
            catch(Exception)
            {
                this.pbCartaMano.BackgroundImage = null;
            }
            if(this.cartaMano == this.cartaMesa)
            {
                if(this.imagenTachada)
                {
                    this.pbCartaMano.Image = null;
                    this.imagenTachada = false;
                }
            }
            else
            {
                this.imagenTachada = true;
                this.pbCartaMano.Image = Image.FromFile($"..\\..\\..\\Resources\\Tachado.png");
            }
        }

        public static void cambioColorHecho(Colores color)
        {
            colorElegido = color;
        }


        private async void partidaEnJuego(int i)
        {
            while (i != this.numeroUser)
            {
                if(this.mazoDeCartas.Count < 5)
                {
                    Cartas.RellenarMazo(this.mazoDeCartas, this.cartasJugadas);
                }

                this.numeroCancelarTarea = i;

                var task = await Task.Run(async () =>
                {
                    if(this.numeroUser == this.numeroCancelarTarea)
                    {
                        Thread.CurrentThread.Interrupt();
                        return 1;
                    }

                    CambiarContador(i, 3);
                    await Task.Delay(1000);
                    CambiarContador(i, 2);
                    await Task.Delay(1000);
                    CambiarContador(i, 1);
                    await Task.Delay(1000);

                    i = turnoBots(i);

                    this.actualizarHistorial.Invoke(this.historial.ToString());

                    return 1;
                });

                if (this.numeroUser == this.numeroCancelarTarea)
                {
                    break;
                }

                CambiarContador(i, 0);

                this.lstManoCartas.Items.Clear();

                foreach (Cartas carta in user.CartasEnMano)
                {
                    this.lstManoCartas.Items.Add(carta);
                }
            }         
        }

        private void CambiarContador(int i, int j)
        {
            if (this.lblContador.InvokeRequired)
            {
                Action<int, int> d = new(this.CambiarContador);

                this.lblContador.Invoke(d, new object[] { i, j });
            }
            else
            {
                if (i == this.numeroUser)
                {
                    this.lblContador.Text = this.turnoUser;
                }
                else
                {
                    this.lblContador.Text = $"Turno del jugador {i + 1}\n Jugará en {j}...";
                }
            }
        }
        private void cambiarContadorCartas(int i)
        {
            if (this.listaLabelsCartasEnMano[i].InvokeRequired)
            {
                Action<int> d = new(cambiarContadorCartas);

                this.listaLabelsCartasEnMano[i].Invoke(d, new object[] { i });
            }
            else
            {
                this.listaLabelsCartasEnMano[i].Text = this.listaJugadores[i].CartasEnMano.Count().ToString();
            }
        }
        private int turnoBots(int i)
        {         
            this.efectoGenerado = JugarCarta(listaJugadores[i]);

            cambiarContadorCartas(i);

            i = logicaEfectos(this.efectoGenerado, this.rondaSentidoReloj, i);

            return i;
        }
        private void cambiarColorMesa(Colores colorElegido)
        {
            if (this.lblCartaMesa.InvokeRequired)
            {
                Action<Colores> d = new(cambiarColorMesa);

                this.lblCartaMesa.Invoke(d, new object[] { colorElegido });
            }
            else
            {
                this.lblCartaMesa.Visible = true;
                this.lblCartaMesa.Text = "Color Elegido: " + colorElegido;
            }
        }

        private int logicaEfectos(Efectos efecto, bool sentidoRonda, int i)
        {
            bool juegaBot = true;
            if(i == this.numeroUser)
            {
                juegaBot = false;
            }
            else
            {
                juegaBot = true;
            }
            if (sentidoRonda)
            {
                switch (efecto)
                {
                    case Efectos.RobaDos:
                        i = ConsultarIndice(i, +1);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        ActualizaHistorial(i, efecto);
                        break;

                    case Efectos.RobaCuatro:
                        i = ConsultarIndice(i, +1);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        ActualizaHistorial(i, efecto);
                        if (juegaBot)
                        {
                            Cartas.cambioColor(this.cartaMesa, out colorElegido);
                            cambiarColorMesa(colorElegido);
                        }
                        break;

                    case Efectos.CambioColor:
                        if (juegaBot)
                        {
                            Cartas.cambioColor(this.cartaMesa, out colorElegido);
                            cambiarColorMesa(colorElegido);
                        }
                        break;

                    case Efectos.CambioSentido:
                        this.rondaSentidoReloj = false;
                        i = ConsultarIndice(i, -1); // Se le resta dos. Uno para compensar el que se suma despues y
                        i = ConsultarIndice(i, -1); // otro para que empiece el jugador anterior al que jugó la carta
                        break;

                    case Efectos.Bloqueo:
                        i = ConsultarIndice(i, +1);
                        ActualizaHistorial(i, efecto);
                        break;
                }

                cambiarContadorCartas(i);

                i = ConsultarIndice(i, +1);
            }
            else
            {
                switch (efecto)
                {
                    case Efectos.RobaDos:
                        i = ConsultarIndice(i, -1);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        ActualizaHistorial(i, efecto);
                        break;

                    case Efectos.RobaCuatro:
                        i = ConsultarIndice(i, -1);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        ActualizaHistorial(i, efecto);
                        if (juegaBot)
                        {
                            Cartas.cambioColor(this.cartaMesa, out colorElegido);
                            cambiarColorMesa(colorElegido);
                        }
                        break;

                    case Efectos.CambioColor:
                        if (juegaBot)
                        {
                            Cartas.cambioColor(this.cartaMesa, out colorElegido);
                            cambiarColorMesa(colorElegido);
                        }
                        break;

                    case Efectos.CambioSentido:
                        this.rondaSentidoReloj = true;
                        i = ConsultarIndice(i, +1); // Se le resta dos. Uno para compensar el que se suma despues y
                        i = ConsultarIndice(i, +1); // otro para que empiece el jugador anterior al que jugó la carta
                        break;

                    case Efectos.Bloqueo:
                        i = ConsultarIndice(i, -1);
                        ActualizaHistorial(i, efecto);
                        break;
                }

                cambiarContadorCartas(i);

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
                    this.historial.AppendLine($"El {usuario.Usuario} tiró {carta}.");
                    this.pbCartaMesa.BackgroundImage = Image.FromFile(this.cartaMesa.Imagen);
                    encontroCarta = true;
                    cartaAux = carta;
                    break;
                }
            }

            if(!encontroCarta)
            {
                Cartas.RepartirCarta(usuario, this.mazoDeCartas);
                this.historial.AppendLine($"El {usuario.Usuario} levantó 1 cartas del mazo.");
            }

            return cartaAux is null ? Efectos.Ninguno : cartaAux.Efecto;
        }

        private void pbCartaMesa_BackgroundImageChanged(object sender, EventArgs e)
        {
            if (this.lblCartaMesa.InvokeRequired)
            {
                Action<object, EventArgs> d = new (pbCartaMesa_BackgroundImageChanged);

                this.lblCartaMesa.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.lblCartaMesa.Visible = false;
            }

            for (int i = 0; i < 4; i++)
            {
                if (this.listaJugadores[i].CartasEnMano.Count == 0)
                {
                    if(this.banderaGanador)
                    {
                        this.numeroUser = this.numeroCancelarTarea;
                        this.historial.AppendLine($"{this.listaJugadores[i].Usuario} ganó la partida!");
                        this.listaJugadores[i].PartidasGanadas++;
                        MessageBox.Show($"{this.listaJugadores[i].Usuario} ha ganado la partida!", "Victory!", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        this.cerrarJuegoSeguro = true;
                        this.banderaGanador = false;
                        this.listaLabelsCartasEnMano[i].Text = this.listaJugadores[i].CartasEnMano.Count().ToString();
                    }
                    break;
                }
                else
                {
                    if (this.listaJugadores[i].CartasEnMano.Count == 1)
                    {
                        // Cantar uno
                        this.historial.AppendLine($"{this.listaJugadores[i].Usuario} le queda 1 carta!");
                        CantarUno(i, true);
                    }
                    else
                    {
                        // Ocultar uno
                        CantarUno(i, false);
                    }
                }
            }
        }

        private void CantarUno(int i, bool uno)
        {
            if (this.listaPBCantarUno[i].InvokeRequired)
            {
                Action<int, bool> d = new(CantarUno);

                this.listaPBCantarUno[i].Invoke(d, new object[]{ i, uno });
            }
            else
            {
                if(uno)
                {
                    this.listaPBCantarUno[i].Visible = true;
                }
                else
                {
                    this.listaPBCantarUno[i].Visible = false;
                }
            }
        }

        private void btnAgarrarCarta_Click(object sender, EventArgs e)
        {
            if(this.lblContador.Text == this.turnoUser)
            {
                if (!user.CartasEnMano.Contains(cartaMesa))
                {
                    if(this.banderaGanador)
                    {
                        Cartas.RepartirCarta(this.user, this.mazoDeCartas);

                        this.lstManoCartas.Items.Clear();

                        foreach (Cartas carta in user.CartasEnMano)
                        {
                            this.lstManoCartas.Items.Add(carta);
                        }
              
                        partidaEnJuego(rondaSentidoReloj ? 1 : 3);
                    }
                }
            }
        }

        private void ActualizaHistorial(int i, Efectos efecto)
        {
            string usuarioAfectado;
            string efectoRecibido = "";
            if(i == this.numeroUser)
            {
                usuarioAfectado = $"{listaJugadores[i].Usuario}";
            }
            else
            {
                usuarioAfectado = $"El {listaJugadores[i].Usuario}";
            }
            switch (efecto)
            {
                case Efectos.RobaDos:
                    efectoRecibido = " recibió 2 cartas.";
                    break;
                case Efectos.RobaCuatro:
                    efectoRecibido = " recibió 4 cartas.";
                    break;
                case Efectos.Bloqueo:
                    efectoRecibido = " fue salteado.";
                    break;
            }
            this.historial.AppendLine(usuarioAfectado + efectoRecibido);
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (this.frmHistorialPartida == null)
            {
                this.frmHistorialPartida = new(this.historial.ToString());
                this.frmHistorialPartida.FormClosed += (o, args) => this.frmHistorialPartida = null;
            }

            this.frmHistorialPartida.Show();
            this.frmHistorialPartida.BringToFront();
        }

        private void FrmJuegoEnPartida_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Mensaje de advertencia cuando se intenta cerrar el formulario. si marca Yes se cierra, si marca No se cancela
            if(!this.cerrarJuegoSeguro)
            {
                if (MessageBox.Show("Seguro desea terminar la partida? Se le sumará como derrota!", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    for(int i = 0; i < 4; i++)
                    {
                        this.listaJugadores[i].PartidasJugadas++;
                        this.dataBase.ActualizarUsuario(this.listaJugadores[i]);
                    }
                    if (this.frmHistorialPartida != null)
                    {
                        this.frmHistorialPartida.Close();
                    }
                    this.numeroUser = this.numeroCancelarTarea;

                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    this.listaJugadores[i].PartidasJugadas++;
                    this.dataBase.ActualizarUsuario(this.listaJugadores[i]);
                }
            }       
        }
    }
}

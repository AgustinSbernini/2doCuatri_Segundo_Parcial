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
        #region Declaracion de variables
        private List<Cartas> mazoDeCartas;
        private List<Usuarios> listaJugadores;
        private List<Cartas> cartasJugadas;
        private List<Label> listaLabelsCartasEnMano;
        private List<PictureBox> listaPBCantarUno;
        private Cartas cartaMesa;
        private Cartas cartaMano;
        private Usuarios user;
        private Partida partida;
        private UsuariosDB usuarioDB;
        private PartidasDB partidaDB;
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
        private DateTime inicioPartida;
        private DateTime finalPartida;
        private int cantidadCartasJugadas;
        private int velocidad;

        #endregion
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
        public FrmJuegoEnPartida(Usuarios user, Partida partida, bool soloBots, int cantidadCartas, int velocidad) : this()
        {
            this.usuarioDB = new();
            this.partidaDB = new();
            this.soloBots = soloBots;
            this.partida = partida;
            this.cantidadCartas = cantidadCartas;
            this.velocidad = velocidad;

            // Si la partida es con bots agarra de la base de datos un jugador extra para reemplazar al usuario
            // Setea el numero usuario en -1 para que no rompa el bucle de los bots jugando
            if (this.soloBots)
            {
                this.numeroUser = -1;
                this.empezoPartidaBots = false;
                this.user = this.usuarioDB.RecuperarUno(new Usuarios("Jugador 1", "Aux"));
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
            this.cantidadCartasJugadas = 0;
            this.inicioPartida = DateTime.Now;

            // Recolecta la cantidad de usuarios necesarios para rellenar la mesa y los guarda en una lista
            for (int i = 2; i < 5; i++)
            {
                Usuarios usuarioAux = this.usuarioDB.RecuperarUno(new Usuarios($"Jugador {i}", "Aux"));
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

            // Carga en el list box las cartas del jugador
            foreach (Cartas carta in this.user.CartasEnMano)
            {
                this.lstManoCartas.Items.Add(carta);
            }

            // Muestra la cantidad de cartas que tiene cada jugador
            this.lblJugador2TotalCartas.Text = this.listaJugadores[1].CartasEnMano.Count.ToString();
            this.lblJugador3TotalCartas.Text = this.listaJugadores[2].CartasEnMano.Count.ToString();
            this.lblJugador4TotalCartas.Text = this.listaJugadores[3].CartasEnMano.Count.ToString();

            // Carta que se juega al medio al inicio de la partida evita ser carta especial por regla del juego
            this.cartaMesa = Cartas.RepartirCarta(this.mazoDeCartas);
            while(this.cartaMesa.Especial)
            {
                this.mazoDeCartas.Add(this.cartaMesa);
                this.cartaMesa = Cartas.RepartirCarta(this.mazoDeCartas);
            }

            // Cambia la imagen de la carta del medio por la carta jugada
            this.pbCartaMesa.BackgroundImage = Image.FromFile(this.cartaMesa.Imagen);

            if(this.soloBots)
            {
                btnTirarCarta.Text = "Empezar Partida";
            }
            this.historial.AppendLine("EMPIEZA LA PARTIDA!");
        }

        private void btnTirarCarta_Click(object sender, EventArgs e)
        {
            // Si solo son bots empieza el bucle infinito hasta que se queda sin cartas algun bot
            if(this.soloBots)
            {
                if (!this.empezoPartidaBots)
                {
                    // Llama a la función donde empieza la logica del juego y cambia el texto del boton
                    partidaEnJuego(0);
                    this.empezoPartidaBots = true;
                    this.btnTirarCarta.Text = "Terminar Partida";
                }
                else
                {
                    // Si la partida ya esta empezada te permite terminar el juego y cerrarlo
                    this.Close();
                }
            }
            else
            {
                // Solo si es tu turno te permite tirar carta
                if (this.lblContador.Text == this.turnoUser)
                {
                    Cartas cartaAux = this.lstManoCartas.SelectedItem as Cartas;
                    if(cartaAux == this.cartaMesa)
                    {
                        int i = 0;
                        // Agrega la carta de la mesa a una lista de cartas jugadas para recargar el mazo despues
                        // Quita la carta de la mano del jugador y del listbox y cambia la imagen por la nueva
                        this.cartasJugadas.Add(this.cartaMesa);
                        this.cartaMesa = cartaAux;
                        this.user.CartasEnMano.Remove(cartaAux);
                        this.lstManoCartas.Items.RemoveAt(this.lstManoCartas.SelectedIndex);
                        this.historial.AppendLine($"{user.Usuario} tiró {cartaMesa}");
                        this.pbCartaMesa.BackgroundImage = Image.FromFile(this.cartaMesa.Imagen);

                        // Si la carta es +4 o cambia color se abre un form nuevo para seleccionar el color
                        if (this.cartaMesa.Color == Colores.Negro)
                        {
                            frmCambioColor.ShowDialog();
                            Cartas.cambioColor(this.cartaMesa, colorElegido);
                            this.lblCartaMesa.Visible = true;
                            this.lblCartaMesa.Text = "Color Elegido: " + colorElegido;
                        }

                        if(this.user.CartasEnMano.Count != 0)
                        {
                            // Luego de tirar realiza el efecto que tenga la carta
                            i = logicaEfectos(this.cartaMesa.Efecto, this.rondaSentidoReloj, i);

                            // Actualiza el historial
                            this.actualizarHistorial.Invoke(this.historial.ToString());

                            // Empieza la logica del juego
                            partidaEnJuego(i);
                        }
                    }
                }
            }
        }
        private void btnAgarrarCarta_Click(object sender, EventArgs e)
        {
            // Si es el turno del jugador y no tiene cartas para jugar puede agarrar una carta
            if (this.lblContador.Text == this.turnoUser)
            {
                if (!user.CartasEnMano.Contains(cartaMesa))
                {
                    // Evita que puedas agarrar carta si ya termino el juego
                    if (this.banderaGanador)
                    {
                        // Agarra una carta, y actualiza el list box
                        Cartas.RepartirCarta(this.user, this.mazoDeCartas);

                        this.lstManoCartas.Items.Clear();

                        foreach (Cartas carta in user.CartasEnMano)
                        {
                            this.lstManoCartas.Items.Add(carta);
                        }

                        // Sigue con la logica del juego al sentido del reloj le toca al jugador siguiente
                        // sino le toca al jugador anterior
                        partidaEnJuego(rondaSentidoReloj ? 1 : 3);
                    }
                }
            }
        }
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            // Crea un form donde se muestra el historial, si ya esta creado lo trae al frente
            // Cuando se cierra lo vuelve null para confirmar la validacion
            if (this.frmHistorialPartida == null)
            {
                this.frmHistorialPartida = new(this.historial.ToString());
                this.frmHistorialPartida.FormClosed += (o, args) => this.frmHistorialPartida = null;
            }

            this.frmHistorialPartida.Show();
            this.frmHistorialPartida.BringToFront();
        }
        private void lstManoCartas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cada vez que se cambia de indice en el list box se actualiza la imagen de la carta
            // Si esta puede tirarse aparece normal, si no puede tirarse aparece tachada
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

        private async void partidaEnJuego(int i)
        {
            // mientras no sea el turno del jugador se ejecuta el bucle, si solo son bots es infinito
            while (i != this.numeroUser)
            {
                // En caso de que queden pocas cartas (por si tiran un +4) se rellena el mazo con las 
                // cartas jugadas
                if(this.mazoDeCartas.Count < 5)
                {
                    Cartas.RellenarMazo(this.mazoDeCartas, this.cartasJugadas);
                }

                // Se utiliza para finalizar la partida
                this.numeroCancelarTarea = i;

                // Espera a que se termine la tarea antes de iniciar la proxima
                var task = await Task.Run(async () =>
                {
                    // Finaliza la tarea cuando termina el juego
                    if(this.numeroUser == this.numeroCancelarTarea)
                    {
                        Thread.CurrentThread.Interrupt();
                        return 1;
                    }

                    // Cuenta regresiva para que tiren los bots con su tiempo de espera
                    CambiarContador(i, 3);
                    await Task.Delay(this.velocidad);
                    CambiarContador(i, 2);
                    await Task.Delay(this.velocidad);
                    CambiarContador(i, 1);
                    await Task.Delay(this.velocidad);

                    // Logica de los bots donde el parametro es el indice que va a jugar y el retorno el siguiente
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
        private int turnoBots(int i)
        {
            // Juega una carta el jugador de turno y retorna el efecto de la carta
            this.efectoGenerado = JugarCarta(listaJugadores[i]);

            // Actualiza el contador de las cartas que tiene el jugador
            cambiarContadorCartas(i);

            // Realiza el efecto de la carta tirada
            i = logicaEfectos(this.efectoGenerado, this.rondaSentidoReloj, i);

            return i;
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
            // Dependiendo del sentido de la ronda es a quien realiza el efecto
            if (sentidoRonda)
            {
                switch (efecto)
                {
                    //Reparte dos cartas al jugador siguiente y saltea su turno
                    case Efectos.RobaDos:
                        i = ConsultarIndice(i, +1);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        Cartas.RepartirCarta(this.listaJugadores[i], this.mazoDeCartas);
                        ActualizaHistorial(i, efecto);
                        break;

                    // Reparte cuatro cartas al jugador siguiente y saltea su turno
                    // Si juega un bot elige un color al azar
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

                    // Cambia el color de la carta de la mesa, si es un bot se elige al azar
                    case Efectos.CambioColor:
                        if (juegaBot)
                        {
                            Cartas.cambioColor(this.cartaMesa, out colorElegido);
                            cambiarColorMesa(colorElegido);
                        }
                        break;

                    // Cambia el sentido de la ronda
                    case Efectos.CambioSentido:
                        this.rondaSentidoReloj = false;
                        i = ConsultarIndice(i, -1); // Se le resta dos. Uno para compensar el que se suma despues y
                        i = ConsultarIndice(i, -1); // otro para que empiece el jugador anterior al que jugó la carta
                        break;

                    // Saltea el turno del siguiente jugador
                    case Efectos.Bloqueo:
                        i = ConsultarIndice(i, +1);
                        ActualizaHistorial(i, efecto);
                        break;
                }

                // Actualiza el contador de carta del jugador que recibió los efectos
                cambiarContadorCartas(i);

                i = ConsultarIndice(i, +1);
            }
            else // Realiza lo mismo que el anterior fragmento pero hacía el sentido contrario de la ronda
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
        /// <summary>
        /// Actualiza el indice sumando o restando 1 y evita que se salga por fuera de los indices de la lista
        /// </summary>
        /// <param name="indice"> indice del turno actual</param>
        /// <param name="modificador"> +1 o -1 dependiendo del sentido de la ronda </param>
        /// <returns></returns>
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

        // Recorre la lista de cartas del jugador en busca de la que coincida con la de la mesa
        // Si coincide agrega la carta de la mesa al mazo de jugadas, tira la carta actual y la quita de la mano
        // Actualiza la imagen de la carta en mesa
        public Efectos JugarCarta(Usuarios usuario)
        {
            bool encontroCarta = false;
            Cartas cartaAux = null;
            foreach (Cartas carta in usuario.CartasEnMano)
            {
                if(carta == this.cartaMesa)
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

            // Si no encontró la carta levanta una carta del mazo
            if(!encontroCarta)
            {
                Cartas.RepartirCarta(usuario, this.mazoDeCartas);
                this.historial.AppendLine($"El {usuario.Usuario} levantó 1 cartas del mazo.");
            }

            // Si no se encontró la carta retorna el efecto ninguno, sino el efecto de la carta
            return cartaAux is null ? Efectos.Ninguno : cartaAux.Efecto;
        }

        private void pbCartaMesa_BackgroundImageChanged(object sender, EventArgs e)
        {
            // Reinvoca el mensaje de color de la carta de la mesa desde otro hilo
            if (this.lblCartaMesa.InvokeRequired)
            {
                Action<object, EventArgs> d = new (pbCartaMesa_BackgroundImageChanged);

                this.lblCartaMesa.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.lblCartaMesa.Visible = false;
            }

            this.cantidadCartasJugadas++;
            //Consulta por cada jugador si se quedó sin cartas, le queda una o le quedan mas
            for (int i = 0; i < 4; i++)
            {
                if (this.listaJugadores[i].CartasEnMano.Count == 0)
                {
                    if(this.banderaGanador)
                    {
                        // Termina la partida guardando la fecha de finalizacion, cancelando el hilo de tareas
                        // aumenta la cantidad de partidas ganadas del jugador, muestra el mensaje de victoria
                        // Y evita que se pueda seguir jugando
                        this.finalPartida = DateTime.Now;
                        this.numeroUser = this.numeroCancelarTarea;
                        this.historial.AppendLine($"{this.listaJugadores[i].Usuario} GANÓ LA PARTIDA!");
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
                        // Cantar uno en caso de quedarle una carta y muestra el lbl
                        this.historial.AppendLine($"{this.listaJugadores[i].Usuario} le queda 1 carta!");
                        CantarUno(i, true);
                    }
                    else
                    {
                        // Ocultar el lbl si agarra una carta
                        CantarUno(i, false);
                    }
                }
            }
        }

        private void CantarUno(int i, bool uno)
        {
            // Reinvoca el lbl de cantar uno del jugador del indice y lo oculta o lo muestra dependiendo
            // de la cantidad de cartas que le queden
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
        private void CambiarContador(int i, int j)
        {
            // Reinvoca el lbl donde indica de quien es el turno
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
            // Reinvoca el lbl del jugador pasado por el indice sobre las cartas que le quedan en la mano
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
        public static void cambioColorHecho(Colores color)
        {
            // Recolecta el color cambiado del form cambio color
            colorElegido = color;
        }
        private void cambiarColorMesa(Colores colorElegido)
        {
            // Reinvoca el lbl de la mesa para indicar cual fue el color elegido con el +4 o cambio color
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

        private void ActualizaHistorial(int i, Efectos efecto)
        {
            // Actualiza el historial de cartas tiradas con la informacion de lo ocurrido
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
                    this.finalPartida = DateTime.Now;
                    this.historial.AppendLine("PARTIDA CANCELADA");

                    // Actualiza la partida y los jugadores que participaron en la base de datos
                    ActualizarPartida();

                    for (int i = 0; i < 4; i++)
                    {
                        this.listaJugadores[i].PartidasJugadas++;
                        this.usuarioDB.Actualizar(this.listaJugadores[i]);
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
                // Actualiza la partida y los jugadores que participaron en la base de datos
                ActualizarPartida();

                for (int i = 0; i < 4; i++)
                {
                    this.listaJugadores[i].PartidasJugadas++;
                    this.usuarioDB.Actualizar(this.listaJugadores[i]);
                }

                DialogResult = DialogResult.OK;
            }       
        }

        // Actualiza la información de la partida y la updatea en la base de datos
        private void ActualizarPartida()
        {
            this.partida.EnCurso = false;
            this.partida.Final = this.finalPartida;
            this.partida.Historial = this.historial.ToString();
            this.partida.CantidadCartasJugadas = this.cantidadCartasJugadas;
            this.partidaDB.Actualizar(this.partida);
        }
    }
}

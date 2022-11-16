using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca_de_clases;

namespace Forms
{
    public partial class FrmMenuPrincipal : Form
    {
        private Usuarios usuario;
        private UsuariosDB usuariosDB;
        private Partida partidaNueva;
        private PartidasDB partidasDB;
        private FrmJuegoEnPartida frmJuegoEnPartida;
        private List<Partida> listaPartidasDB;
        private List<Usuarios> listaUsuariosDB;
        private bool soloBots;
        private int cantidadCartas;
        private string tipoPartida;
        private int velocidad;
        private DataTable tablaPartida;
        private DataRow filaAuxPartida;
        private DataTable tablaUsuario;
        private DataRow filaAuxUsuario;
        private int filaSeleccionada;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.tablaPartida = new();
            this.tablaUsuario = new();
            this.partidasDB = new();
            this.usuariosDB = new();
        }
        public FrmMenuPrincipal(Usuarios usuario) : this()
        {
            this.usuario = usuario;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.lblBienvenido.Text = $"Bienvenido {this.usuario.Usuario}!";

            // Creo las columnas de las tablas que se utilizan para mostrar las estadisticas
            this.tablaPartida.Columns.Add("Creador");
            this.tablaPartida.Columns.Add("Fecha Inicio Partida");
            this.tablaPartida.Columns.Add("Fecha Final Partida");
            this.tablaPartida.Columns.Add("Tipo de Partida");
            this.tablaPartida.Columns.Add("Total Cartas Jugadas");
            this.tablaPartida.Columns.Add("Duracion");
            this.tablaPartida.Columns.Add("En Curso");

            this.tablaUsuario.Columns.Add("Posición");
            this.tablaUsuario.Columns.Add("Usuario");
            this.tablaUsuario.Columns.Add("Partidas Ganadas");
            this.tablaUsuario.Columns.Add("Partidas Jugadas");
            this.tablaUsuario.Columns.Add("Winrate");
            this.tablaUsuario.Columns.Add("Ultima conexión");

            // Marco el radiobutton como true para que se ejecute el evento
            this.rbPartidas.Checked = true;
        }

        // Los botones al ser clickeados setean si juegan solo bots, la cantidad de cartas que se tiran
        // El tipo de partida que va a jugar y la velocidad en la que se tiran las cartas
        // Luego de eso llaman a la funcion CrearSala
        #region Uso de Botones
        private void btnUserVsBotsRapida_Click(object sender, EventArgs e)
        {
            this.soloBots = false;
            this.cantidadCartas = 2;
            this.tipoPartida = "User vs Bots Rapida";
            this.velocidad = 500;
            this.CrearSala(soloBots, cantidadCartas, tipoPartida, velocidad);
        }

        private void btnUserVsBots_Click(object sender, EventArgs e)
        {
            this.soloBots = false;
            this.cantidadCartas = 7;
            this.tipoPartida = "User vs Bots Normal";
            this.velocidad = 1000;
            this.CrearSala(soloBots, cantidadCartas, tipoPartida, velocidad);
        }

        private void btnBotsVsBotsRapida_Click(object sender, EventArgs e)
        {
            this.soloBots = true;
            this.cantidadCartas = 2;
            this.tipoPartida = "Bots vs Bots Rapida";
            this.velocidad = 500;
            this.CrearSala(soloBots, cantidadCartas, tipoPartida, velocidad);
        }

        private void btnBotsVsBots_Click(object sender, EventArgs e)
        {
            this.soloBots = true;
            this.cantidadCartas = 7;
            this.tipoPartida = "Bots vs Bots Normal";
            this.velocidad = 1000;
            this.CrearSala(soloBots, cantidadCartas, tipoPartida, velocidad);
        }
        #endregion

        // Se crea un nuevo objeto Partida con la fecha de inicio, quien la creo y el tipo de partida.
        // Luego se guarda en la base de datos y llama a la funcion donde se cargan las partidas
        // Para que se actualice si es la tabla que se esta mostrando.
        // Por ultimo crea un hilo nuevo donde se crea la partida y se muestra.
        private void CrearSala(bool bots, int cantCartas, string tipoPartida, int velocidad)
        {
            this.partidaNueva = new(DateTime.Now, usuario.Usuario, tipoPartida);
            this.partidasDB.CrearNuevo(this.partidaNueva);
            if(this.rbPartidas.Checked)
            {
                this.CargarPartidas();
            }

            Task task = Task.Run(() =>
            {
                this.frmJuegoEnPartida = new(this.usuario, this.partidaNueva, bots, cantCartas, velocidad);
                this.frmJuegoEnPartida.ShowDialog();
            });
            Thread.Sleep(1000);
        }

        // Cada vez que se cambia el check de los radio buton carga el datagrid con la informacion
        // solicitada y cambia el texto del boton para que sea mas indicativo.
        private void rbPartidas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbPartidas.Checked)
            {
                this.CargarPartidas();
                this.btnDescarga.Text = "Descargar Historial";
            }
            else
            {
                this.CargarUsuarios();
                this.btnDescarga.Text = "Descargar Informacion";
            }
        }

        // Limpio la tabla existente, cargo en una lista todas las partidas guardadas en la base de datos
        // recorro la lista de partidas y agrego la informacion de cada partida al datagrid
        private void CargarPartidas()
        {
            this.tablaPartida.Clear();

            this.listaPartidasDB = this.partidasDB.DevolverLista();

            foreach (Partida partida in this.listaPartidasDB)
            {
                this.filaAuxPartida = this.tablaPartida.NewRow();

                // Si la partida esta en curso el Final y la Cantidad de cartas jugadas tienen datos por defecto
                // Por lo que los muestro como vacios.
                if (partida.EnCurso)
                {
                    this.filaAuxPartida[2] = "-----";
                    this.filaAuxPartida[4] = "-----";
                }
                else
                {
                    this.filaAuxPartida[2] = partida.Final;
                    this.filaAuxPartida[4] = partida.CantidadCartasJugadas;
                }

                this.filaAuxPartida[0] = partida.Creador;
                this.filaAuxPartida[1] = partida.Inicio;
                this.filaAuxPartida[3] = partida.TipoPartida;
                this.filaAuxPartida[5] = partida.Duracion;
                this.filaAuxPartida[6] = partida.EnCurso;

                this.tablaPartida.Rows.Add(this.filaAuxPartida);
            }

            this.dgvPartida.DataSource = this.tablaPartida;
        }

        // Limpio la tabla existente, cargo en una lista todas los usuarios guardadas en la base de datos
        // recorro la lista de usuarios y agrego la informacion de cada partida al datagrid e incremento la posicion
        private void CargarUsuarios()
        {
            this.tablaUsuario.Clear();
            int posicion = 1;
            this.listaUsuariosDB = this.usuariosDB.DevolverLista();

            foreach (Usuarios usuario in this.listaUsuariosDB)
            {
                this.filaAuxUsuario = this.tablaUsuario.NewRow();

                this.filaAuxUsuario[0] = posicion;
                this.filaAuxUsuario[1] = usuario.Usuario;
                this.filaAuxUsuario[2] = usuario.PartidasGanadas;
                this.filaAuxUsuario[3] = usuario.PartidasJugadas;
                this.filaAuxUsuario[4] = $"{usuario.Winrate}%";
                this.filaAuxUsuario[5] = usuario.UltimoLogeo;

                this.tablaUsuario.Rows.Add(this.filaAuxUsuario);
                posicion++;
            }

            this.dgvPartida.DataSource = this.tablaUsuario;
        }

        // Recolecta la fila seleccionada para utilizarla en btnDescargar
        private void dgvPartida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.filaSeleccionada = e.RowIndex;
        }

        // Recorre la lista seleccionada dependiendo de los radiobutton
        // Si el objeto de la fila seleccionada coincide con el guardado en la base de datos
        // Te descarga el Historial o la Informacion en el escritorio con el nombre descripto 
        // Y muestra que lo descargo
        private void btnDescarga_Click(object sender, EventArgs e)
        {
            if(this.filaSeleccionada > -1)
            {
                string textoADescargar;

                if (this.rbPartidas.Checked)
                {
                    foreach (Partida partida in this.listaPartidasDB)
                    {
                        if (partida.Inicio.ToString() == this.dgvPartida.Rows[this.filaSeleccionada].Cells[1].Value.ToString())
                        {
                            if(!partida.EnCurso)
                            {
                                textoADescargar = partida.Historial;
                                File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Historial partida {partida.Id}.txt", textoADescargar);
                                MessageBox.Show($"Historial de la partida {partida.Id} descargada en el escritorio!");
                            }
                            else
                            {
                                MessageBox.Show($"Espera a que finalice la partida para descargar el hisotiral");
                            }
                        }
                    }
                }
                else
                {
                    foreach (Usuarios usuario in this.listaUsuariosDB)
                    {
                        if(usuario.Usuario == this.dgvPartida.Rows[this.filaSeleccionada].Cells[1].Value.ToString())
                        {
                            textoADescargar = usuario.ToString();
                            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Informacion de {usuario.Usuario}.txt", textoADescargar);
                            MessageBox.Show($"Informacion del usuario {usuario.Usuario} descargada en el escritorio!");
                        }
                    }
                }
            }
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro desea cerrar el programa?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}

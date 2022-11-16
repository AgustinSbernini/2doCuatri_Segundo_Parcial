using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Usuarios
    {
        private int id;
        private string usuario;
        private string contraseña;
        private int partidasGanadas;
        private int partidasJugadas;
        private int winrate;
        private DateTime ultimoLogeo;
        private List<Cartas> cartasEnMano;

        public Usuarios(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.partidasGanadas = 0;
            this.partidasJugadas = 0;
            this.winrate = 0;
            this.ultimoLogeo = DateTime.Now;
            this.cartasEnMano = new();
        }
        public Usuarios(string usuario, string contraseña, int partidasGanadas, int partidasJugadas, int winrate, DateTime ultimoLogeo) : this(usuario, contraseña)
        {
            this.ultimoLogeo = ultimoLogeo;
            this.partidasGanadas = partidasGanadas;
            this.partidasJugadas = partidasJugadas;
            this.winrate = winrate;
        }
        public string Usuario { get => usuario; }
        public string Contraseña { get => contraseña; }
        public int PartidasJugadas { get => partidasJugadas; set => partidasJugadas = value;}
        public int PartidasGanadas { get => partidasGanadas; set => partidasGanadas = value; }
        public int Winrate { 
            get
            {
                if(partidasGanadas != 0 && partidasJugadas != 0)
                {
                    winrate = (partidasGanadas * 100) / partidasJugadas;
                }
                else
                {
                    winrate = 0;
                }
                return winrate;
            }

            set => winrate = value; 
        }
        public DateTime UltimoLogeo { get => ultimoLogeo; set => ultimoLogeo = value; }
        public List<Cartas> CartasEnMano { get => cartasEnMano; set => cartasEnMano = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            StringBuilder retorno = new();

            retorno.AppendLine($"Usuario: {this.usuario}");
            retorno.AppendLine($"Total de partidas Jugadas: {this.partidasJugadas}");
            retorno.AppendLine($"Total de partidas Ganadas: {this.partidasGanadas}");
            retorno.AppendLine($"Winrate: {this.winrate}%");
            retorno.AppendLine($"Ultima vez conectado: {this.ultimoLogeo:d}");

            return retorno.ToString();
        }

        public static Usuarios operator +(Usuarios usuario, Cartas carta)
        {
            usuario.cartasEnMano.Add(carta);

            return usuario;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Partida
    {
        private int id;
        private string creador;
        private DateTime inicio;
        private DateTime final;
        private string historial;
        private string tipoPartida;
        private int cantidadCartasJugadas;
        private string duracion;
        private bool enCurso;

        public DateTime Inicio { get => inicio; set => inicio = value; }
        public DateTime Final { get => final; set
            { 
                this.final = value;
                this.duracion = $"{(this.final - this.inicio).Minutes}:{(this.final - this.inicio).Seconds}";
            }
        }
        public string Historial { get => historial; set => historial = value; }
        public int CantidadCartasJugadas { get => cantidadCartasJugadas; set => cantidadCartasJugadas = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public string TipoPartida { get => tipoPartida; set => tipoPartida = value; }
        public bool EnCurso { get => enCurso; set => enCurso = value; }
        public string Creador { get => creador; set => creador = value; }
        public int Id { get => id; set => id = value; }

        public Partida(DateTime inicio, string creador, string tipoPartida)
        {
            this.creador = creador;
            this.inicio = inicio;
            this.tipoPartida = tipoPartida;
            this.final = new DateTime(1753, 01, 01);
            this.historial = "";
            this.duracion = "-----";
            this.cantidadCartasJugadas = 0;
            this.enCurso = true;
        }
        public Partida(DateTime inicio, string creador, string tipoPartida, DateTime final, string historial, int cantidadCartasJugadas, string duracion, bool enCurso) : this(inicio, creador, tipoPartida)
        {
            this.final = final;
            this.historial = historial;
            this.cantidadCartasJugadas = cantidadCartasJugadas;
            this.duracion = duracion;
            this.enCurso = enCurso;
        }
    }
}

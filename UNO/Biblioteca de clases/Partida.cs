using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Partida
    {
        private int idCreador;
        private DateTime inicio;
        private DateTime final;
        private string historial;
        private string tipoPartida;
        private int cantidadCartasJugadas;
        private string duracion;

        public int IdCreador { get => idCreador; set => idCreador = value; }
        public DateTime Inicio { get => inicio; set => inicio = value; }
        public DateTime Final { get => final; set => final = value; }
        public string Historial { get => historial; set => historial = value; }
        public int CantidadCartasJugadas { get => cantidadCartasJugadas; set => cantidadCartasJugadas = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public string TipoPartida { get => tipoPartida; set => tipoPartida = value; }

        public Partida(DateTime inicio, int idCreador, string tipoPartida)
        {
            this.idCreador = idCreador;
            this.inicio = inicio;
            this.tipoPartida = tipoPartida;
        }
        public Partida(DateTime inicio, int idCreador, string tipoPartida, DateTime final, string historial, int cantidadCartasJugadas) : this(inicio, idCreador, tipoPartida)
        {
            this.final = final;
            this.historial = historial;
            this.cantidadCartasJugadas = cantidadCartasJugadas;
            this.duracion = $"{(final-inicio).Minutes}:{(final - inicio).Seconds}";
        }


    }
}

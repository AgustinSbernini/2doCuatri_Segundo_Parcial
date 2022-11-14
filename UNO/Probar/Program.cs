using System;
using System.IO;
using Biblioteca_de_clases;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Probar
{
    class Program
    {

        static void Main(string[] args)
        {
            DateTime final = DateTime.Now;
            DateTime inicio = new DateTime(2022, 11, 13);
            TimeSpan resultado = (final - inicio);

            Console.WriteLine($"00:{resultado.Minutes}:{resultado.Seconds}");
            
            /*
            Cartas cartaAux = new(1,Colores.Rojo);
            Cartas cartaAux1 = new(2, Colores.Rojo);
            Cartas cartaAux2 = new(3, Colores.Rojo);
            Cartas cartaAux3 = new(4, Colores.Rojo);
            Cartas cartaAux4 = new(5, Colores.Rojo);
            Cartas cartaAux5 = new(6, Colores.Rojo);
            Cartas cartaAux6 = new(7, Colores.Rojo);

            List<Cartas> mazo = new();

            List<Cartas> cartasJugadas = new();

            mazo.Add(cartaAux);
            mazo.Add(cartaAux1);
            mazo.Add(cartaAux2);

            cartasJugadas.Add(cartaAux3);
            cartasJugadas.Add(cartaAux4);
            cartasJugadas.Add(cartaAux5);
            cartasJugadas.Add(cartaAux6);

            Console.WriteLine($"{mazo.Count} {cartasJugadas.Count}");

            Cartas.RellenarMazo(mazo, cartasJugadas);

            Console.WriteLine($"{mazo.Count} {cartasJugadas.Count}");

            /*private int numero; // del 1 al 9 se repiten dos veces, el 0 una sola
              private Colores color; // 19 de cada color en total        
              private bool robaDos; // 8 en total, 2 de cada color
              private bool bloqueo; // 8 en total, 2 de cada color
              private bool cambioSentido; // 8 en total, 2 de cada color
              private bool robaCuatro;// 4 en total
              private bool cambioColor; // 4 en total*/

        }
    }
}

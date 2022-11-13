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
        private static void taskNuevas()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"ID tasK: {Task.CurrentId} numero i: {i}");
            }
        }
        static void Main(string[] args)
        {
            Task.Run(() => 
            {
                Program.taskNuevas();
            });
            Thread.Sleep(500);
            Task.Run(() =>
            {
                Program.taskNuevas();
            });
            Thread.Sleep(500);
            Task.Run(() =>
            {
                Program.taskNuevas();
            });

            Console.ReadLine();
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

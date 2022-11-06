using System;
using System.IO;
using Biblioteca_de_clases;
using System.Text.Json;
using System.Collections.Generic;

namespace Probar
{
    class Program
    {
        private static void RepartirCarta(Usuarios usuario, List<Cartas> mazo)
        {
            int numero;
            Random random = new();
            //if(mazo.Count > 0)
            {
                numero = random.Next(mazo.Count);
                usuario += mazo[numero];
                mazo.RemoveAt(numero);

            }
        }

        static void Main(string[] args)
        {
            
            /*
            List<Cartas> mazo = Cartas.MazoDeCartas();
            Usuarios user = new("Agus", "Juan");
            Usuarios user2 = new("Agus", "Juan");
            Usuarios user3 = new("Agus", "Juan");
            Usuarios user4 = new("Agus", "Juan");
            List<Usuarios> listaUsuarios = new();
            listaUsuarios.Add(user);
            listaUsuarios.Add(user2);
            listaUsuarios.Add(user3);
            listaUsuarios.Add(user4);

            Console.WriteLine(user.CartasEnMano.Count);
            Console.WriteLine(mazo.Count);
            Console.WriteLine("-----------------");
            RepartirCarta(listaUsuarios[0], mazo);
            RepartirCarta(listaUsuarios[0], mazo);
            RepartirCarta(listaUsuarios[0], mazo);
            RepartirCarta(listaUsuarios[0], mazo);

            Console.WriteLine(user.CartasEnMano.Count);
            Console.WriteLine(mazo.Count);*/
            /*
            foreach (Cartas carta in mazo)
            {
                Console.WriteLine(carta);
            }

            Console.WriteLine(mazo.Count);*/



            /*private int numero; // del 1 al 9 se repiten dos veces, el 0 una sola
              private Colores color; // 19 de cada color en total        
              private bool robaDos; // 8 en total, 2 de cada color
              private bool bloqueo; // 8 en total, 2 de cada color
              private bool cambioSentido; // 8 en total, 2 de cada color
              private bool robaCuatro;// 4 en total
              private bool cambioColor; // 4 en total*/


            /*
            StreamWriter streamWriter = new StreamWriter("..\\..\\..\\..\\Forms\\bin\\Debug\\net5.0-windows\\Cartas.json", true);
            string jsonString;
            Cartas cartaAux;

            foreach (Colores color in Enum.GetValues(typeof(Colores)))
            {
                if(color != Colores.Negro)
                {
                    for(int i = 0; i < 10; i++)
                    {
                        if (i == 0)
                        {
                            cartaAux = new(i, color);
                            jsonString = JsonSerializer.Serialize(cartaAux);

                            streamWriter.WriteLine(jsonString);
                        }
                        else
                        {
                            for(int j = 0; j < 2; j++)
                            {
                                cartaAux = new(i, color);
                                jsonString = JsonSerializer.Serialize(cartaAux);

                                streamWriter.WriteLine(jsonString);
                            }
                        }
                    }

                    for (int j = 0; j < 2; j++)
                    {
                        cartaAux = new(Efectos.RobaDos, color);
                        jsonString = JsonSerializer.Serialize(cartaAux);

                        streamWriter.WriteLine(jsonString);

                        cartaAux = new(Efectos.Bloqueo, color);
                        jsonString = JsonSerializer.Serialize(cartaAux);

                        streamWriter.WriteLine(jsonString);

                        cartaAux = new(Efectos.CambioSentido, color);
                        jsonString = JsonSerializer.Serialize(cartaAux);

                        streamWriter.WriteLine(jsonString);
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        cartaAux = new(Efectos.RobaCuatro);
                        jsonString = JsonSerializer.Serialize(cartaAux);

                        streamWriter.WriteLine(jsonString);

                        cartaAux = new(Efectos.CambioColor);
                        jsonString = JsonSerializer.Serialize(cartaAux);

                        streamWriter.WriteLine(jsonString);
                    }
                }
            }

            streamWriter.Close();
            streamWriter.Dispose();
            */
        }
    }
}

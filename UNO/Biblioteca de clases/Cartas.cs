using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Biblioteca_de_clases
{
    public class Cartas
    {
        private int numero;
        private Colores color;
        private bool especial;
        private Efectos efecto;
        private Colores colorCambiado;
        private string imagen;

        public int Numero { get => numero; set => numero = value; }
        public Colores Color { get => color; set => color = value; }
        public bool Especial { get => especial; set => especial = value; }
        public Efectos Efecto { get => efecto; set => efecto = value; }
        public string Imagen { get => imagen; set => imagen = value; }

        public Cartas() { }
        public Cartas(int numero, Colores color)
        {
            this.numero = numero;
            this.color = color;
            this.especial = false;
            this.efecto = Efectos.Ninguno;
        }
        public Cartas(Efectos efecto) : this()
        {
            this.especial = true;
            this.efecto = efecto;
            this.numero = -1;
            this.color = Colores.Negro;
        }

        public Cartas(Efectos efecto, Colores color) : this(efecto)
        {
            this.color = color;
        }
        public Cartas(int numero, Colores color, bool especial, Efectos efecto) : this(efecto, color)
        {
            this.numero = numero;
            this.especial = especial;
        }
        public static bool operator ==(Cartas cartaMano, Cartas cartaMesa)
        {
            bool retorno = false;
            if(cartaMano is null || cartaMesa is null)
            {
                if(cartaMano is null && cartaMesa is null)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else
            {
                if(cartaMesa.numero == -1 || cartaMano.numero == -1)
                {
                    if (cartaMano.color == Colores.Negro || cartaMano.color == cartaMesa.color || cartaMano.efecto == cartaMesa.efecto || cartaMesa.colorCambiado == cartaMano.color)
                    {
                        retorno = true;
                    }
                }
                else
                {
                    if(cartaMano.color == Colores.Negro || cartaMano.color == cartaMesa.color || cartaMano.numero == cartaMesa.numero)
                    {
                        retorno = true;
                    }
                }
            }

            return retorno;
        }
        public static bool operator !=(Cartas cartaMano, Cartas cartaMesa)
        {
            return !(cartaMano == cartaMesa);
        }

        public static void cambioColor(Cartas cartaMesa, Colores nuevoColor)
        {
            cartaMesa.colorCambiado = nuevoColor;
        }
        public static void cambioColor(Cartas cartaMesa, out Colores colorElegido)
        {
            Random random = new();
            Colores colorRandom;

            colorRandom = (Colores) Enum.GetValues(typeof(Colores)).GetValue(random.Next(1, 5));

            Cartas.cambioColor(cartaMesa, colorRandom);

            colorElegido = colorRandom;
        }

        public override string ToString()
        {
            StringBuilder retorno = new();

            if(!this.especial)
            {
                retorno.Append($"Numero: {this.numero} Color: {this.color}");
            }
            else
            {
                retorno.Append($"Efecto: {this.efecto}");
                if (!(this.color == Colores.Negro))
                {
                    retorno.Append($" Color: {this.color}");
                }
            }

            return retorno.ToString();
        }
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Cartas)
            {
                retorno = this == obj as Cartas;
            }

            return retorno;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static List<Cartas> MazoDeCartas()
        {
            List<Cartas> mazo = null;
            Cartas carta;
            StreamReader streamReader;
            string cartaString;

            if (File.Exists("Cartas.json"))
            {
                streamReader = File.OpenText("Cartas.json");
                mazo = new();

                while ((cartaString = streamReader.ReadLine()) is not null)
                {
                    carta = JsonSerializer.Deserialize<Cartas>(cartaString);
                    carta.imagen = $"..\\..\\..\\Resources\\{carta.Numero}{carta.Color}{carta.Efecto}.png";
                    mazo.Add(carta);
                }    
            }

            return mazo;
        }

        public static void RepartirCarta(Usuarios usuario, List<Cartas> mazo)
        {
            int numero;
            Random random = new();
            if(mazo.Count > 0)
            {
                numero = random.Next(mazo.Count);
                usuario += mazo[numero];
                mazo.RemoveAt(numero);
            }
        }

        public static Cartas RepartirCarta(List<Cartas> mazo)
        {
            int numero;
            Random random = new();
            Cartas cartaAux = null;

            if (mazo.Count > 0)
            {
                numero = random.Next(mazo.Count);
                cartaAux = mazo[numero];
                mazo.RemoveAt(numero);
            }

            return cartaAux;
        }

    }    
}

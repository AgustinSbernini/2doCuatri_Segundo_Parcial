using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca_de_clases;
using System.Collections.Generic;

namespace UnitTestUNO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMazoDeCartas()
        {
            List<Cartas> mazo = Cartas.MazoDeCartas();

            Assert.AreEqual(108, mazo.Count);
        }

        [TestMethod]
        public void TestRepartirCartaUsuario()
        {
            Usuarios user = new("Nuevo", "Nuevo");
            List<Cartas> mazo = Cartas.MazoDeCartas();

            Cartas.RepartirCarta(user, mazo);
            Cartas.RepartirCarta(user, mazo);
            Cartas.RepartirCarta(user, mazo);
            Cartas.RepartirCarta(user, mazo);
            Cartas.RepartirCarta(user, mazo);

            Assert.AreEqual(user.CartasEnMano.Count, 5);
        }

        [TestMethod]
        public void TestRepartirCartaMesa()
        {
            List<Cartas> mazo = Cartas.MazoDeCartas();

            Cartas carta = Cartas.RepartirCarta(mazo);

            Assert.IsTrue(carta is not null);
        }

        [TestMethod]
        public void TestRellenarMazo()
        {
            List<Cartas> mazoLleno = Cartas.MazoDeCartas();
            List<Cartas> mazoVacio = new();

            Cartas.RellenarMazo(mazoVacio, mazoLleno);

            Assert.AreEqual(mazoVacio.Count, 108);
            Assert.AreEqual(mazoLleno.Count, 0);
        }

        [TestMethod]
        public void TestSumarCartaUsuario()
        {
            Usuarios user = new("Nuevo", "Nuevo");
            Cartas cartaNuevo = new(1, Colores.Rojo);

            user += cartaNuevo;

            Assert.AreEqual(user.CartasEnMano[0], cartaNuevo);
        }

    }
}

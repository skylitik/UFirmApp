using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFirm.BLL;
using System;
using Ufirm.Common;

namespace Ufirm.BLL.Test
{
    [TestClass]
    public class DostawcaTests
    {
        [TestMethod]
        public void WyslijEmailWitamy_PrawidlowaNazwaFirmy_Sukces()
        {
            //Arrange
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "UFirm";
            var oczekiwana = "Wiadomość wyslana: Witaj UFirm";

            //Act
            var aktualna = dostawca.WysliEmailWitamy("Wiadomość testowa");

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod]
        public void WyslijEmailWitamy_PustaNazwaFirmy_Sukces()
        {
            //Arrange
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "";
            var oczekiwana = "Wiadomość wyslana: Witaj";

            //Act
            var aktualna = dostawca.WysliEmailWitamy("Wiadomość testowa");

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod]
        public void WyslijEmailWitamy_NullNazwaFirmy_Sukces()
        {
            //Arrange
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = null;
            var oczekiwana = "Wiadomość wyslana: Witaj";

            //Act
            var aktualna = dostawca.WysliEmailWitamy("Wiadomość testowa");

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void ZlozZamowienieTest()
        {
            //Arrange
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var oczekiwana = new WynikOperacji(true, "Zamówienie z UFirm\r\nProdukt: Informatyka - 1\r\nIlość: 15");

            //Act
            var aktualna = dostawca.ZlozZamowienie(produkt, 15);

            //Assert
            Assert.AreEqual(oczekiwana.Sukces, aktualna.Sukces);
            Assert.AreEqual(oczekiwana.Wiadomosc, aktualna.Wiadomosc);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZlozZamowienie_NullProdukt_ExceptionTest()
        {
            //Arrange
            var dostawca = new Dostawca();
           

            //Act
            var aktualna = dostawca.ZlozZamowienie(null, 15);

            //Assert
            //Oczekiwany wyjatek
           // Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZlozZamowienie_IloscTest()
        {
            //Arrange
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
           

            //Act
            var aktualna = dostawca.ZlozZamowienie(produkt, 0);

            //Assert
           // Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}

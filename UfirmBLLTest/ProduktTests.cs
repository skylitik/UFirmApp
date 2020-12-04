using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UFirm.BLL.Test
{
    [TestClass()]
    public class ProduktTests
    {
        [TestMethod()]
        public void PowiedzWitajTest()
        {
            //Arrange
            var produkt = new Produkt();
            produkt.ProduktID = 1;
            produkt.NazwaProduktu = "Biurko";
            produkt.Opis = "Czarne biurko";
            produkt.DostawcaProduktu.NazwaFirmy = "UFirm dostawca";

            var oczekiwana = "Witaj Biurko (1): Czarne biurko";

            //Act
            var aktualna = produkt.PowiedzWitaj();

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void PowiedzWitaj_SparametryzowanyKonstruktorTest()
        {
            //Arrange
            var produkt = new Produkt(1, "Biurko", "Czarne biurko");      
        
            var oczekiwana = "Witaj Biurko (1): Czarne biurko";

             //Act
            var aktualna = produkt.PowiedzWitaj();

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void PowiedzWitaj_InicjalizatorObiektuTest()
        {
            //Arrange
            var produkt = new Produkt
            {
                ProduktID = 1,
                NazwaProduktu = "Biurko",
                Opis = "Czarne Biurko"
            };


            var oczekiwana = "Witaj Biurko (1): Czarne Biurko";

            //Act
            var aktualna = produkt.PowiedzWitaj();

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}
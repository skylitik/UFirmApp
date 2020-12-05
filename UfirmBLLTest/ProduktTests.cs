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

            var oczekiwana = "Witaj Biurko (1): Czarne biurko Dostępny od: ";

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
        
            var oczekiwana = "Witaj Biurko (1): Czarne biurko Dostępny od: ";

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


            var oczekiwana = "Witaj Biurko (1): Czarne Biurko Dostępny od: ";

            //Act
            var aktualna = produkt.PowiedzWitaj();

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void Produkt_NullTest()
        {
            //Arrange
            Produkt produkt = null;
            string oczekiwana = null;

            //Act
            var aktualna = produkt?.DostawcaProduktu?.NazwaFirmy;

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void Konwersja_CaliNaMetr()
        {
            //Arrange
            
            var oczekiwana = 194.35;

            //Act
            var aktualna = 5 * Produkt.CaliNaMetr;

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void MinimalnaCena_DomyslnaTest()
        {
            //Arrange
            var produkt = new Produkt();
            var oczekiwana = 10.50m;

            //Act
            var aktualna = produkt.MinimalnaCena;

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void Krzeslo()
        {
            //Arrange
            var produkt = new Produkt(1, "Krzesło zwykłe", "Opis");
            var oczekiwana = 120.99m;

            //Act
            var aktualna = produkt.MinimalnaCena;

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void NazwaProduktu_FormatTest()
        {
            //Arrange
            var produkt = new Produkt();
            produkt.NazwaProduktu = " Krzesło obrotowe ";
            var oczekiwana = "Krzesło obrotowe";

            //Act
            var aktualna = produkt.NazwaProduktu;

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void NazwaProduktu_ZakorkaTest()
        {
            //Arrange
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krz";
            string oczekiwana = null;
            string oczekiwanaWiadomosc = "Nazwa produktu musi być dłuszcza niż 4 znaki";

            //Act
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomoscz;
            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }
        [TestMethod()]
        public void NazwaProduktu_ZadlugaTest()
        {
            //Arrange
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krzeszło obrotowe zbyt długa nazwa";
            string oczekiwana = null;
            string oczekiwanaWiadomosc = "Nazwa produktu musi być krótsza niż 30 znaków";

            //Act
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomoscz;
            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }
        [TestMethod()]
        public void NazwaProduktu_PrawidlowaTest()
        {
            //Arrange
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krzesło obrotowe";
            string oczekiwana = "Krzesło obrotowe";
            string oczekiwanaWiadomosc = null;

            //Act
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomoscz;
            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }
        [TestMethod()]
        public void Kategoria_warosczDomyslnaTest()
        {
            //Arrange
            var produkt = new Produkt();
            string oczekiwana = "Informatyka";

            //Act
            var aktualna = produkt.Kategoria;
            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void Kategoria_nowaWartosc()
        {
            //Arrange
            var produkt = new Produkt();
            produkt.Kategoria = "Geografia";
            var oczekiwana = "Geografia";

            //Act
            var aktualna = produkt.Kategoria;
            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void Numer_WartoszcDomyslnaTest()
        {
            //Arrange
            var produkt = new Produkt();
            var oczekiwana = 1;

            //Act
            var aktualna = produkt.Numer;
            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void Numer_NowaWartosc()
        {
            //Arrange
            var produkt = new Produkt();
            produkt.Numer = 400;
            var oczekiwana = 400;

            //Act
            var aktualna = produkt.Numer;
            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFirm.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFirm.BLL.Tests
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

            var oczekiwana = "Witaj Biurko (1): Czarne biurko";

            //Act
            var aktualna = produkt.PowiedzWitaj();

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void PowiedzWitajSparametryzowanyKonstruktorTest()
        {
            //Arrange
            var produkt = new Produkt(1, "Biurko", "Czarne biurko");      
        
            var oczekiwana = "Witaj Biurko (1): Czarne biurko";

             //Act
            var aktualna = produkt.PowiedzWitaj();

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}
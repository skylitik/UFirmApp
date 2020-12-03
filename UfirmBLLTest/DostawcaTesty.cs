using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFirm.BLL;

namespace UfirmBLLTest
{
    [TestClass]
    public class DostawcaTesty
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
    }
}

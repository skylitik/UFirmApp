using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ufirm.Common.Tests
{
    [TestClass()]
    public class LogowanieServiceTests
    {
        [TestMethod()]
        public void LogowanieTest()
        {
            //Arrange
            
            var oczekiwana = "Akcja: Test Akcja";

            //Act
            var aktualna = LogowanieService.Logowanie("Test Akcja");

            //Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}
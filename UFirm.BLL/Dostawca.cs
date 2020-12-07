using Ufirm.Common;
using System;

namespace UFirm.BLL
{
    /// <summary>
    /// Zarządza dostawcami od których kupujemy nasze produkty
    /// </summary>
    public class Dostawca
    {
        #region Pola i właściwości
        public int DostawcaId { get; set; }
        public string NazwaFirmy { get; set; }
        public string Email { get; set; }
        #endregion
        #region Metody
        /// <summary>
        /// Wysyla wiadomosc email, aby powiatc nowego dostawce
        /// </summary>
        /// <param name="wiadomosc"></param>
        /// <returns></returns>
        public string WysliEmailWitamy(string wiadomosc)
        {
            var emailService = new EmailService();
            var temat = ("Witaj " + this.NazwaFirmy).Trim();
            var potwierdzenie = emailService.WyslijWiadomosc(temat, wiadomosc, this.Email);

            return potwierdzenie;
        }

        /// <summary>
        /// Wysyla zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>
        /// <param name="ilosc">Ilość do zamówienia</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc)
        {
            if (produkt == null)
                throw new ArgumentNullException(nameof(produkt));
            if (ilosc <= 0)
                throw new ArgumentOutOfRangeException(nameof(ilosc));
            var sukces = false;

            var tekstZamowienia = "Zamówienie z UFirm" + Environment.NewLine + "Produkt: " + produkt.KodProduktu + Environment.NewLine + "Ilość: " + ilosc;
            var emailService = new EmailService();
            var potwierdzenie =  emailService.WyslijWiadomosc("Nowe zamówienie", tekstZamowienia, this.Email);
            if (potwierdzenie.StartsWith("Wiadomość wyslana: "))
                sukces = true;
            var wynikOperacji = new WynikOperacji(sukces, tekstZamowienia);
            

            return wynikOperacji;
        }
        #endregion
    }
}

﻿using Ufirm.Common;
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
            return ZlozZamowienie(produkt, ilosc, null, null);
        }
        /// <summary>
        /// Wysyla zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>
        /// <param name="ilosc">Ilość do zamówienia</param>
        /// <param name="data">Data dostawy zamówienia</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DateTimeOffset? data)
        {
            return ZlozZamowienie(produkt, ilosc, data, null);
        }
        /// <summary>
        /// Wysyla zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>
        /// <param name="ilosc">Ilość do zamówienia</param>
        /// <param name="data">Data dostawy zamówienia</param>
        /// <param name="instrukcje">Instrukcja dostawy</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DateTimeOffset? data, string instrukcje)
        {
            if (produkt == null)
                throw new ArgumentNullException(nameof(produkt));
            if (ilosc <= 0)
                throw new ArgumentOutOfRangeException(nameof(ilosc));
            if (data >= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(data));
            var sukces = false;

            var tekstZamowienia = "Zamówienie z UFirm" + Environment.NewLine + "Produkt: " + produkt.KodProduktu + Environment.NewLine + "Ilość: " + ilosc;
            if (data.HasValue)
            {
                tekstZamowienia += Environment.NewLine + "Data dostawy: " + data.Value.ToString("d");
            }
            if (!string.IsNullOrWhiteSpace(instrukcje))
            {
                tekstZamowienia += Environment.NewLine + "Instrukcja: " + instrukcje;
            }

            var emailService = new EmailService();
            var potwierdzenie = emailService.WyslijWiadomosc("Nowe zamówienie", tekstZamowienia, this.Email);
            if (potwierdzenie.StartsWith("Wiadomość wyslana: "))
                sukces = true;
            var wynikOperacji = new WynikOperacji(sukces, tekstZamowienia);


            return wynikOperacji;
        }
            #endregion
        }
}

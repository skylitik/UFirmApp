using System;
using Ufirm.Common;
using static Ufirm.Common.LogowanieService;

namespace UFirm.BLL
{
    /// <summary>
    /// Zarządza produktami
    /// </summary>
    public class Produkt
    {
        #region Konstruktory
        public Produkt()
        {
            Console.WriteLine("Produkt został utworzony");
            //this.DostawcaProduktu = new Dostawca();
        }
        public Produkt(int produktId, string nazwaProduktu, string opis) : this()
        {
            this.ProduktID = produktId;
            this.NazwaProduktu = nazwaProduktu;
            this.Opis = opis;
            Console.WriteLine("Produkt ma nazwe: " + nazwaProduktu);
            
        }
        #endregion

        #region Pola i wlaściwości
        private int produktId;

        public int ProduktID
        {
            get { return produktId; }
            set { produktId = value; }
        }
        private string nazwaProduktu;

        public string NazwaProduktu
        {
            get { return nazwaProduktu; }
            set { nazwaProduktu = value; }
        }
        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }
        private Dostawca dostawcaProduktu;

        public Dostawca DostawcaProduktu
        {
            get 
            {
                if (dostawcaProduktu == null)
                {
                    dostawcaProduktu = new Dostawca();
                }
                return dostawcaProduktu; 
            }
            set { dostawcaProduktu = value; }
        }

        #endregion
        public string PowiedzWitaj()
        {
            //var dostawca = new Dostawca();
           // dostawca.WysliEmailWitamy("Wiadomość z produktu");

            var emailServices = new EmailService();
            var potwierdzenie = emailServices.WyslijWiadomosc("Nowy produkt", this.NazwaProduktu, "ufirm@gmail.com");
            var wynik = Logowanie("Powiedziano Witaj");

            return "Witaj " + NazwaProduktu + " (" + ProduktID + "): " + Opis;
        }
    }
}

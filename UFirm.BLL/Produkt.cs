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
        public const double CaliNaMetr = 38.87;
        public readonly decimal MinimalnaCena;
        #region Konstruktory
        public Produkt()
        {
            Console.WriteLine("Produkt został utworzony");
            //this.DostawcaProduktu = new Dostawca();
            this.MinimalnaCena = 10.50m;
            this.Kategoria = "Informatyka";
        }
        public Produkt(int produktId, string nazwaProduktu, string opis) : this()
        {
            this.ProduktID = produktId;
            this.NazwaProduktu = nazwaProduktu;
            this.Opis = opis;
            if (nazwaProduktu.StartsWith("Krzesło"))
            {
                this.MinimalnaCena = 120.99m;
            }
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
            get
            {
                var przecinakProduktu = nazwaProduktu?.Trim();
                return przecinakProduktu;
            }
            set
            {
                if (value.Length < 4)
                {
                    Wiadomoscz = "Nazwa produktu musi być dłuszcza niż 4 znaki";
                }
                else if (value.Length > 30)
                {
                    Wiadomoscz = "Nazwa produktu musi być krótsza niż 30 znaków";
                }
                else
                {
                    nazwaProduktu = value;
                }
            }
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
        private DateTime? dataDostepnosci;

        public DateTime? DateDostepnosci
        {
            get { return dataDostepnosci; }
            set { dataDostepnosci = value; }
        }

        public string Wiadomoscz { get; private set; }
        internal string Kategoria { get; set; }
        public int Numer { get; set; } = 1;

        public string KodProduktu => String.Format("{0} - {1:0000}", this.Kategoria, this.Numer);
        public decimal Koszt { get; set; }
        #endregion
        public string PowiedzWitaj()
        {
            //var dostawca = new Dostawca();
           // dostawca.WysliEmailWitamy("Wiadomość z produktu");

            var emailServices = new EmailService();
            var potwierdzenie = emailServices.WyslijWiadomosc("Nowy produkt", this.NazwaProduktu, "ufirm@gmail.com");
            var wynik = Logowanie("Powiedziano Witaj");
            

            return "Witaj " + NazwaProduktu + " (" + ProduktID + "): " + Opis + " Dostępny od: " + DateDostepnosci?.ToShortDateString();
        }
        /// <summary>
        /// Oblicza sugerowaną cene detaliczną produktu
        /// </summary>
        /// <param name="procent">Procent uywany do wyliczenia sugerowanej ceny detalicznej</param>
        /// <returns></returns>
        public decimal obliczSugerowanaCena(decimal procent) => this.Koszt + (this.Koszt * procent / 100);        
        public override string ToString() => this.nazwaProduktu + " ("+ this.produktId + ")"; 
    }
}

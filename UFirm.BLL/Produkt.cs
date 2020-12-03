using System;

namespace UFirm.BLL
{
    /// <summary>
    /// Zarządza produktami
    /// </summary>
    public class Produkt
    {
        public Produkt()
        {
            Console.WriteLine("Produkt został utworzony");
        }
        public Produkt(int produktId, string nazwaProduktu, string opis) : this()
        {
            this.ProduktID = produktId;
            this.NazwaProduktu = nazwaProduktu;
            this.Opis = opis;
            Console.WriteLine("Produkt ma nazwe: " + nazwaProduktu);
            
        }
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
        public string PowiedzWitaj()
        {
            return "Witaj " + NazwaProduktu + " (" + ProduktID + "): " + Opis;
        }
    }
}

using Ufirm.Common;

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
    }
}

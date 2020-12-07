using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufirm.Common
{
   public class WynikOperacji
    {
        
        public WynikOperacji()
        {

        }
        public WynikOperacji(bool sukces, string wiadomosc)
        {
            this.Sukces = sukces;
            this.Wiadomosc = wiadomosc;
        }
        public bool Sukces { get; private set; }
        public string Wiadomosc { get; private set; }
    }

}

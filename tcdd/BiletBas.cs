using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class BiletBas
    {
        public string AdSoyad { get; set; }
        public string Cikis { get; set; }
        public string Varis { get; set; }
        public string Tren { get; set; }
        public string Tarife { get; set; }
        public decimal Ucret { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public int KoltukNo { get; set; }
        public string BiletNo { get; set; }

        public BiletBas()
        {
            Tren = "Doğu Ekspresi";
            Saat = "10:00";
        }
    }
}

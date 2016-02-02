using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class Seyahat
    {

        private List<Hat> hat { get; set; }
        public string KalkisNokta { get; set; }
        public string VarisNokta { get; set; }
        public DateTime GidisTarihi { get; set; }
        public Bilet bilet { get; set; }

        public Seyahat(Bilet b)
        {
            bilet = b;
            Hat h1 = new Hat();
            h1.Kalkis = "Turgutlu";
            h1.Varis = "İzmir";
            h1.Fiyat = 8;

            Hat h2 = new Hat();
            h2.Kalkis = "Turgutlu";
            h2.Varis = "Manisa";
            h2.Fiyat = 6; 

            Hat h3 = new Hat();
            h3.Kalkis = "Turgutlu";
            h3.Varis = "Uşak";
            h3.Fiyat = 10;

            Hat h4 = new Hat();
            h4.Kalkis = "Manisa";
            h4.Varis = "Turgutlu";
            h4.Fiyat = 6;

            Hat h5 = new Hat();
            h5.Kalkis = "İzmir";
            h5.Varis = "Turgutlu";
            h5.Fiyat = 8;

            Hat h6 = new Hat();
            h6.Kalkis = "Uşak";
            h6.Varis = "Turgutlu";
            h6.Fiyat = 10;


            hat = new List<Hat>();
            hat.Add(h1);
            hat.Add(h2);
            hat.Add(h3);
            hat.Add(h4);
            hat.Add(h5);
            hat.Add(h6);
        }

        public virtual decimal SeyahatTutar()
        {
            var sonuc = hat.Where(x => x.Kalkis == this.KalkisNokta && x.Varis == this.VarisNokta).FirstOrDefault();
            return sonuc.Fiyat;
        }
    }
}

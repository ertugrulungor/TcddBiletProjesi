using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    class Puan : Odeme
    {
        public Puan(Yolcu y)
        {
            yolcu = y;
        }

        private decimal odenecekTutar { get; set; }       


        public decimal PuanIndirim(decimal IndirimliTutar)
        {
            if (IndirimliTutar <= yolcu.Puan)
            {
                odenecekTutar = yolcu.Puan - IndirimliTutar;
                odenecekTutar = 0;
                yolcu.Puan -= IndirimliTutar;
            }
            else
            {
                odenecekTutar = IndirimliTutar - yolcu.Puan;
                yolcu.Puan = 0; 
            }

            return odenecekTutar;
        }

        public override string Ode()
        {
            return "Puan ödendi";
        }
    }
}

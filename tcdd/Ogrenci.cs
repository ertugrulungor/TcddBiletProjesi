using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class Ogrenci : Bilet
    {
        public override decimal IndirimYap(decimal SeyahatTutar)
        {
            return SeyahatTutar * 0.7M;
        }

        public Ogrenci(Yolcu y)
        {
            yolcu = y;
            TarifeAdi = "Öğrenci Bilet";
        }
    }
}

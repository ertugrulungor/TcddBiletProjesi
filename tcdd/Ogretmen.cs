using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class Ogretmen : Bilet
    {
        public override decimal IndirimYap(decimal SeyahatTutar)
        {
            return SeyahatTutar * 0.8M;
        }

        public Ogretmen(Yolcu y)
        {
            yolcu = y;
            TarifeAdi = "Öğretmen Bilet";
        }
    }
}

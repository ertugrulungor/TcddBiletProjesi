using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class Tam : Bilet
    {
        public override decimal IndirimYap(decimal SeyahatTutar)
        {
            return SeyahatTutar;
        }

        public Tam(Yolcu y)
        {
            yolcu = y;
            TarifeAdi = "Tam Bilet";
        }
    }
}

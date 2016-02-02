using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class KrediKarti : Odeme
    {
        public KrediKarti(Yolcu y)
        {
            this.yolcu = y;
        }
        public override string Ode()
        {
            return "Kredi kartı ile ödeme tamamlandı";
        }
    }
}

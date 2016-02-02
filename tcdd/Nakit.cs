using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class Nakit : Odeme
    {
        public Nakit(Yolcu y)
        {
            this.yolcu = y;
        }
        public override string Ode()
        {              
            return "Nakit olarak ödeme tamamlandı";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public abstract class Odeme
    {
        protected Yolcu yolcu { get; set; }


        public abstract string Ode();
    }
}

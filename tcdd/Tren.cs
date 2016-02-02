using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class Tren
    {
        public Tren()
        {
            this.KoltukSayisi = 100;
        }
        public DateTime Tarih { get; set; }
        public short KoltukSayisi { get; private set; }
        public List<Seyahat> biletler = new List<Seyahat>();
    }
}

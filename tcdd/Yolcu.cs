using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class Yolcu
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public decimal Puan { get; set; }
        public Yolcu()
        {
            this.Puan = 0;
        }
        
    }
}

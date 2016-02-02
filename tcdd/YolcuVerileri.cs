using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public class YolcuVerileri
    {
        public List<Yolcu> KayitliYolcular = new List<Yolcu>();
        private decimal snPuan { get; set; }
        public decimal YolcuPuani(Yolcu y)
        {
            var TCsi = KayitliYolcular.Where(x => x.TC == y.TC).FirstOrDefault();
            snPuan = TCsi.Puan;
            return snPuan;
        }
    }
}

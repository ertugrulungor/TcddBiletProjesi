using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
   public class TCDD
    {         
        
        public List<Tren> Trenler { get; set; }
        public TCDD()
        {
            Tren t1 = new Tren();
            t1.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            Tren t2 = new Tren();
            t2.Tarih = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());

            Tren t3 = new Tren();
            t3.Tarih = Convert.ToDateTime(DateTime.Now.AddDays(2).ToShortDateString());

            Tren t4 = new Tren();
            t4.Tarih = Convert.ToDateTime(DateTime.Now.AddDays(3).ToShortDateString());

            Tren t5 = new Tren();
            t5.Tarih = Convert.ToDateTime(DateTime.Now.AddDays(4).ToShortDateString());

            Trenler = new List<Tren>();
            Trenler.Add(t1);
            Trenler.Add(t2);
            Trenler.Add(t3);
            Trenler.Add(t4);
            Trenler.Add(t5);
        }

        public List<Seyahat> TrenListesi(List<Tren> tren, string tarih)
        {
            Tren sonuc = tren.Where(x => x.Tarih.ToShortDateString() == tarih).FirstOrDefault();
            return sonuc.biletler;
        }
    }
}

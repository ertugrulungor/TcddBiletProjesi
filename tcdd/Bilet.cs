using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcdd
{
    public abstract class Bilet
    {
        public Yolcu yolcu { get; set; }

        private int koltukno = 0;
        public int KoltukNo { get { return koltukno; } }

        private string biletno = "";
        public string BiletNo { get { return biletno; } }

        public DateTime BiletTarihi { get; set; }
        public string TarifeAdi { get; set; }

        public abstract decimal IndirimYap(decimal SeyahatTutar);           

        public string BiletNoCek(Tren t, Seyahat yolcu)
        {
            int tempNo;
            try
            {
                Seyahat s = t.biletler[t.biletler.Count - 1];
                tempNo = s.bilet.koltukno;
                yolcu.bilet.koltukno = tempNo + 1;
            }
            catch
            {
                yolcu.bilet.koltukno = 1;
            }
            biletno = "A" + yolcu.GidisTarihi.Day.ToString() + yolcu.GidisTarihi.Year.ToString() + "57" + yolcu.bilet.koltukno.ToString();
            return BiletNo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tcdd
{
    public partial class frmTcdd : Form
    {
        public frmTcdd()
        {
            InitializeComponent();
        }

        decimal sonuc = 0;
        string BiletNo;
        bool HataKontrolu = false;
        public int deger;
        private void BiletAtama(TCDD t, Seyahat s)
        {
            Tren sonuc = t.Trenler.Where(x => x.Tarih == s.GidisTarihi).FirstOrDefault();
            BiletNo = s.bilet.BiletNoCek(sonuc, s);
            sonuc.biletler.Add(s);
        }

        private void tmrSaat_Tick(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.ToShortTimeString();
        }

        private void frmTcdd_Load(object sender, EventArgs e)
        {
            lblTutar.Text = 0.ToString("C2");
        }

        private void cmbTekYolcu_SelectedIndexChanged(object sender, EventArgs e)
        {
           deger = Convert.ToInt32(cmbTekYolcu.Text);

            if (deger != 0)
                btnOdemeIslemi.Enabled = true;
            else
                btnOdemeIslemi.Enabled = false;

            for (int i = 1; i <= deger; i++)
            {
                Control c = grpYolcu.Controls["pnlTekYolcu" + i];
                c.Enabled = true;
            }

            for (int i = deger + 1; i <= 4; i++)
            {
                Control c = grpYolcu.Controls["pnlTekYolcu" + i];
                c.Enabled = false;
            }
        }

        decimal temp;
        Yolcu y1 = new Yolcu();
        Tren Trn = new Tren();
        TCDD TCdd = new TCDD();
        YolcuVerileri yolcuveri = new YolcuVerileri();
        public static List<BiletBas> biletbas = new List<BiletBas>();


        private decimal BiletHesapla(Bilet b, int i)
        {
            
            BiletBas BiletBilgi = new BiletBas();
            BiletBas BiletBilgi2 = new BiletBas();
            Seyahat s1 = new Seyahat(b);
            s1.GidisTarihi = Convert.ToDateTime(dtpTekGidis.Value.ToShortDateString());

            s1.bilet.BiletTarihi = s1.GidisTarihi;
            s1.KalkisNokta = cmbTekKalkis.Text;
            s1.VarisNokta = cmbTekVaris.Text;

            BiletBilgi.Tarih = s1.GidisTarihi;
            BiletBilgi.Cikis = s1.KalkisNokta;
            BiletBilgi.Varis = s1.VarisNokta;

            temp = s1.bilet.IndirimYap(s1.SeyahatTutar());
            Trn.biletler.Add(s1);


            BiletBilgi.Ucret = s1.bilet.IndirimYap(s1.SeyahatTutar());

            BiletAtama(TCdd, s1);
            BiletBilgi.AdSoyad = s1.bilet.yolcu.Ad + " " + s1.bilet.yolcu.Soyad;
            BiletBilgi.BiletNo = BiletNo;
            BiletBilgi.KoltukNo = s1.bilet.KoltukNo;
            BiletBilgi.Tarife = s1.bilet.TarifeAdi;
            biletbas.Add(BiletBilgi);

            if (rdGidisDonus.Checked == true)
            {

                Seyahat s2 = new Seyahat(b);
                s2.GidisTarihi = Convert.ToDateTime(dtpGidisDonus.Value.ToShortDateString());
                s2.bilet.BiletTarihi = s2.GidisTarihi;
                s2.KalkisNokta = cmbTekVaris.Text;
                s2.VarisNokta = cmbTekKalkis.Text;
                temp += s2.bilet.IndirimYap(s2.SeyahatTutar());

                BiletBilgi2.KoltukNo = s2.bilet.KoltukNo;
                BiletBilgi2.AdSoyad = s2.bilet.yolcu.Ad + " " + s2.bilet.yolcu.Soyad;
                BiletBilgi2.Tarife = s2.bilet.TarifeAdi;
                BiletBilgi2.Cikis = s2.KalkisNokta;
                BiletBilgi2.Tarih = s2.bilet.BiletTarihi;
                BiletBilgi2.Varis = s2.VarisNokta;
                BiletBilgi2.Ucret = s2.bilet.IndirimYap(s2.SeyahatTutar());

                Trn.biletler.Add(s2);
                BiletAtama(TCdd, s2);
                BiletBilgi2.BiletNo = BiletNo;
                biletbas.Add(BiletBilgi2);
            }
            Control c = grpYolcu.Controls["pnlTekYolcu" + i];
            CheckBox chc = c.Controls["chbPuan" + i] as CheckBox;
            if (chc.Checked)
            {
                Puan p = new Puan(b.yolcu);
                temp = p.PuanIndirim(temp);
            }
            b.yolcu.Puan += (temp) / 1000;
            sonuc += temp;


            return sonuc;
        }

        private void btnOdemeIslemi_Click(object sender, EventArgs e)
        {

            decimal tempSonuc = 0;
            int deger = Convert.ToInt32(cmbTekYolcu.Text);
            for (int i = 1; i <= deger; i++)
            {
                Control c1 = grpYolcu.Controls["pnlTekYolcu" + i];
                Yolcu y = new Yolcu();
                
                y.TC = c1.Controls["txtTc" + i].Text;
                y.Ad = c1.Controls["txtAd" + i].Text;
                y.Soyad = c1.Controls["txtSoyad" + i].Text;

                

                var Kayit = yolcuveri.KayitliYolcular.Where(x => x.TC == y.TC).FirstOrDefault();
                if (Kayit != null)
                {
                    y.Puan = yolcuveri.YolcuPuani(y);
                    y.Ad = Kayit.Ad;
                    y.Soyad = Kayit.Soyad;
                }
                else
                {
                    yolcuveri.KayitliYolcular.Add(y);
                }
                y1 = y;
                RadioButton rd1 = c1.Controls["rdTam" + i] as RadioButton;
                RadioButton rd2 = c1.Controls["rdOgrenci" + i] as RadioButton;
                
                if (rd1.Checked) { Tam t = new Tam(y); tempSonuc = BiletHesapla(t, i); }
                else if (rd2.Checked) { Ogrenci o = new Ogrenci(y); tempSonuc = BiletHesapla(o, i); }
                else { Ogretmen o = new Ogretmen(y); tempSonuc = BiletHesapla(o, i); }

                grpOdeme.Enabled = true;
                lblTutar.Text = sonuc.ToString("C2");
                grpSeyahat.Enabled = grpYolcu.Enabled = false;
                
            }
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            
            BiletGoruntuleme bg = new BiletGoruntuleme();
            bg.Text = "Bilet Görüntüleme (Sayfa 1)";
            bg.Show();
            if (rdNakit.Checked == true)
            {
                Nakit n = new Nakit(y1);
                MessageBox.Show(n.Ode());
            }
            else if (rdKrediKarti.Checked == true)
            {
                KrediKarti k = new KrediKarti(y1);
                MessageBox.Show(k.Ode());
            }
            for (int i = 1; i <= deger; i++)
            {
                Control c1 = grpYolcu.Controls["pnlTekYolcu" + i];
                c1.Controls["txtTc" + i].Text = "";
                c1.Controls["txtAd" + i].Text = "";
                c1.Controls["txtSoyad" + i].Text = "";

            }

            rdTekYon.Checked = true;
            cmbTekYolcu.SelectedIndex = 0;
            sonuc = 0;             
            grpSeyahat.Enabled = grpYolcu.Enabled = true;
            lblTutar.Text = 0.ToString("C2");
        }

        private void rdGidisDonus_CheckedChanged(object sender, EventArgs e)
        {
            lblDonusTarihi.Visible = dtpGidisDonus.Visible = true;
        }

        private void rdTekYon_CheckedChanged(object sender, EventArgs e)
        {
            lblDonusTarihi.Visible = dtpGidisDonus.Visible = false;
        }

        List<Seyahat> TrenSecim;
        private void btnSecim_Click(object sender, EventArgs e)
        {
            string s = "";
            listYolcular.Items.Clear();
            TrenSecim = TCdd.TrenListesi(TCdd.Trenler, dateTrenTarih.Value.ToShortDateString());
            if (TrenSecim != null)
            {
                foreach (Seyahat t in TrenSecim)
                {
                    s += t.bilet.BiletNo + " - " + t.bilet.yolcu.TC + " - " + t.bilet.yolcu.Ad + " " + t.bilet.yolcu.Soyad + " - " + t.VarisNokta;
                    listYolcular.Items.Add(s);
                }
                grpYolcuSec.Enabled = true;
                grpTrenSec.Enabled = false;
            }
            else
                MessageBox.Show("Lütfen doğru tarihi seçiniz. (Bugün dahil 5 gün)");

        }

        private void btnYolcuSec_Click(object sender, EventArgs e)
        {
            string s = listYolcular.Text;
            s = s.Substring(0, 10);
            Seyahat sonuc = TrenSecim.Where(x => x.bilet.BiletNo == s).FirstOrDefault();
            txtDuzeltAd.Text = sonuc.bilet.yolcu.Ad;
            txtDuzeltTC.Text = sonuc.bilet.yolcu.TC;
            txtDuzeltSoyad.Text = sonuc.bilet.yolcu.Soyad;
            dateDuzeltTarih.Value = Convert.ToDateTime(sonuc.GidisTarihi);
            cmbDuzeltVaris.Text = sonuc.VarisNokta;
            grpYolcuSec.Enabled = false;
            grpDuzeltSil.Enabled = true;
        }

        private void btnBiletSil_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Seçilen yolcu silinecektir. Onaylıyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (secim == DialogResult.Yes)
            {
                string s = listYolcular.Text;
                s = s.Substring(0, 10);
                Seyahat sonuc = TrenSecim.Where(x => x.bilet.BiletNo == s).FirstOrDefault();
                TrenSecim.Remove(sonuc);
                listYolcular.Items.Clear();
                txtDuzeltAd.Text = "";
                txtDuzeltSoyad.Text = "";
                txtDuzeltTC.Text = "";
                grpDuzeltSil.Enabled = false;
                grpTrenSec.Enabled = true;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string s = listYolcular.Text;
            s = s.Substring(0, 10);
            Seyahat sonuc = TrenSecim.Where(x => x.bilet.BiletNo == s).FirstOrDefault();
            sonuc.bilet.yolcu.Ad = txtDuzeltAd.Text;
            sonuc.bilet.yolcu.TC = txtDuzeltTC.Text;
            sonuc.bilet.yolcu.Soyad = txtDuzeltSoyad.Text;
            sonuc.GidisTarihi = dateDuzeltTarih.Value;
            sonuc.VarisNokta = cmbDuzeltVaris.Text;
            listYolcular.Items.Clear();
            txtDuzeltAd.Text = "";
            txtDuzeltSoyad.Text = "";
            txtDuzeltTC.Text = "";
            MessageBox.Show("Güncelleme Başarıyla tamamlandı", "İşlem Başarılı",MessageBoxButtons.OK, MessageBoxIcon.Information);
            grpDuzeltSil.Enabled = false;
            grpTrenSec.Enabled = true;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Programdan çıkılacak. Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (secim == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

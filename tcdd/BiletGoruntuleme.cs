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
    public partial class BiletGoruntuleme : Form
    {
        public BiletGoruntuleme()
        {
            InitializeComponent();
        } 
        private void BiletGoruntuleme_Load(object sender, EventArgs e)
        {
            int f = frmTcdd.biletbas.Count();
            
            int i = 0; 
            foreach (BiletBas x in frmTcdd.biletbas)
            {         
                i++;
                if(i == 1)
                    this.Size = new System.Drawing.Size(590, 240);
                else if (i == 2)
                    this.Size = new System.Drawing.Size(1155, 240);
                else if (i == 3)
                    this.Size = new System.Drawing.Size(1155, 434);
                else if (i > 4)
                {
                    frmTcdd.biletbas.RemoveAt(1);
                    frmTcdd.biletbas.RemoveAt(2);
                    frmTcdd.biletbas.RemoveAt(3);
                    frmTcdd.biletbas.RemoveAt(4);
                    BiletGoruntuleme BiletGoruntuleDevam = new BiletGoruntuleme();
                    BiletGoruntuleDevam.Text = "Bilet Görüntüleme (Sayfa 2)";
                    BiletGoruntuleDevam.Show();
                    break;
                }  
                Control c = new Control();
                c = this.Controls["bilet" + i];

                c.Controls["lblAd" + i].Text = x.AdSoyad;
                c.Controls["lblCikis" + i].Text = x.Cikis;
                c.Controls["lblVaris" + i].Text = x.Varis;
                c.Controls["lblTren" + i].Text = x.Tren;
                c.Controls["lblTarih" + i].Text = x.Tarih.ToShortDateString();
                c.Controls["lblSaat" + i].Text = x.Saat;
                c.Controls["lblKoltuk" + i].Text = x.KoltukNo.ToString();
                c.Controls["lblBiletNo" + i].Text = x.BiletNo;
                c.Controls["lblUcret" + i].Text = x.Ucret.ToString();
                c.Controls["lblTarife" + i].Text = x.Tarife;

                this.Controls["bilet" + i].Visible = true; 
            }

            if (f < 5)
                frmTcdd.biletbas.Clear();
        }
    }
}
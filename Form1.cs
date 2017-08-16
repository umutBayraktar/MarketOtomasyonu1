using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NesneyeYonelilProgramlamaFinalProjesi
{
    public partial class Form1 : Form
    {
        Dukkan ByBUY = new Dukkan();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            if (txtKullaniciAdi.Text == "patron" && txtSifre.Text == "123")// patron girişi için 
            {
                tabControl1.Visible = true;//tabcontrol görünür oluyor
                tabControl1.TabPages.Remove(tpSatis); //patronun satışla işi yok
                lblKullaniciAdi.Visible = false;  //giriş ekranı kayboluyoru
                lblSifre.Visible = false;
                txtKullaniciAdi.Visible = false;
                txtSifre.Visible = false;
                btnGiris.Visible = false;
                lblKarsilamaYazisi.Visible = false;
            }
            else
            {
                KasaGorevlisi girisgorevli = new KasaGorevlisi(); //kullanıcı adıyla eşleştirmek için kasiyer oluşturdum
                girisgorevli = ByBUY.KasaGorevlisiBul(txtKullaniciAdi.Text); //kullanıcı adı girişinden kasiyer buluyor
                if (girisgorevli == null)//değer dönmezse hatalı giriş
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı Girdiniz");
                }
                else if(girisgorevli.Sifre == txtSifre.Text) //görevli eşleşti ve  şifre uyuşuyorsa 
                    {
                    tabControl1.Visible = true; // tab control görünür oldu
                    lblKullaniciAdi.Visible = false;//giriş ekranı ortadan kalktı
                    lblSifre.Visible = false;
                    txtKullaniciAdi.Visible = false;
                    txtSifre.Visible = false;
                    btnGiris.Visible = false;
                    tabControl1.TabPages.Remove(tpStokIslemleri); //bunlarla işi yok sildik
                    tabControl1.TabPages.Remove(tpTerminalBilgi);
                    tabControl1.TabPages.Remove(tpKasiyerİslemleri);
                    tabControl1.TabPages.Remove(tpHesapDefteri);
                }
            }
        }

        private void btnKullaniciDegistir_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tpStokIslemleri);
            tabControl1.TabPages.Add(tpSatis);
            tabControl1.TabPages.Add(tpTerminalBilgi);
            tabControl1.TabPages.Add(tpKatalog);
            tabControl1.TabPages.Add(tpHesapDefteri);
            tabControl1.TabPages.Add(tpKasiyerİslemleri);
            tabControl1.Visible = false;
            lblKullaniciAdi.Visible = true;
            lblSifre.Visible = true;
            txtKullaniciAdi.Visible = true;
            txtSifre.Visible = true;
            btnGiris.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            KasaGorevlisi gorevli = new KasaGorevlisi();
            gorevli.Ad = txtPersonelAd.Text;
            gorevli.Adres = txtPersonelAdres.Text;
            gorevli.KullaniciAdi = txtPersonelKullaniciAdi.Text;
            gorevli.Maas = Convert.ToDecimal(txtPersonelMaas.Text);
            gorevli.PersonelNo = Convert.ToInt32(txtPersonelNo.Text); ;
            gorevli.Sifre = txtPersonelSifre.Text;
            gorevli.Soyad = txtPersonelSoyad.Text;
            gorevli.TelefonNumarasi = txtPersonelTelefonNo.Text;
            ByBUY.KasiyerEkle(gorevli);
            txtPersonelGörmeEkranı.Text = ByBUY.GorevliListele();
            cmbKasaGorevlisiSecimi.Items.Add(gorevli.KullaniciAdi);
        }

        private void btnPersonelAra_Click(object sender, EventArgs e)
        {
            txtPersonelGörmeEkranı.Text = ByBUY.GorevliAra(txtPersonelArama.Text); ;
        }

        private void btnPersonelListele_Click(object sender, EventArgs e)
        {
            txtPersonelGörmeEkranı.Text = ByBUY.GorevliListele();
        }

        private void btnStokUrunEkle_Click(object sender, EventArgs e)
        {
            Urun yeniurun = new Urun();
            yeniurun.Kalem = new SatisKalemi();
            yeniurun.UrunAdi = txtUrunAdi.Text;
            yeniurun.UrunDetay = txtUrunDetayi.Text;
            yeniurun.UrunKodu = txtUrunKodu.Text;
            yeniurun.StokAdet = Convert.ToInt32(nmUDStokAdeti.Value);
            yeniurun.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
            ByBUY.DukkanStogu.StokEkle(yeniurun);
            cmbStokUrunSecimi.Items.Add(yeniurun.UrunAdi);
            cmbAlinacakUrunler.Items.Add(yeniurun.UrunAdi);
            txtKatalogGoruntuEkrani.Text = "";
            txtKatalogGoruntuEkrani.Text = ByBUY.DukkanStogu.StokListele();
            txtUrunAdi.Text = txtUrunDetayi.Text = txtUrunFiyati.Text = txtUrunKodu.Text = "";
            nmUDStokAdeti.Value = 0;
           
            MessageBox.Show("Ürün Başarıyla Eklendi.");
        }

        private void btnStokArttir_Click(object sender, EventArgs e)
        {
         
            ByBUY.DukkanStogu.StokArttır(ByBUY.DukkanStogu.UrunBul(cmbStokUrunSecimi.SelectedItem.ToString()),Convert.ToInt32(nmUDStokArtis.Value));
            txtKatalogGoruntuEkrani.Text = "";
            txtKatalogGoruntuEkrani.Text = ByBUY.DukkanStogu.StokListele();
            /*
            stok artttır metodu'nun birinci parametresi urun tipinde,ikinci parametresi int tipinde artacak urun miktarı
            new ile yeni ürün oluşturup atamak yerine urunbul metodunu kullanıp ürün döndürtüyoruz. ikinci parametreyi de numerikUpDown'dan aldık.     
            */
            MessageBox.Show("Ürün Stoğu Başarıyla Arttırıldı.");
        }

        private void btnKatalogUrunAra_Click(object sender, EventArgs e)
        {
            txtKatalogGoruntuEkrani.Text = "";
            txtKatalogGoruntuEkrani.Text = ByBUY.DukkanStogu.StoktaUrunAra(txtKatalogUrunAra.Text);
        }

        private void btnKatalogGoruntule_Click(object sender, EventArgs e)
        {
            txtKatalogGoruntuEkrani.Text = "";
            txtKatalogGoruntuEkrani.Text=ByBUY.DukkanStogu.StokListele();
        }

        private void btnTerminalEkle_Click(object sender, EventArgs e)
        {
            Terminal t = new Terminal();
            t.TerminalNo = Convert.ToInt32(txtTerminalNo.Text);
            t.Gorevli = ByBUY.KasaGorevlisiBul(cmbKasaGorevlisiSecimi.SelectedItem.ToString());
            ByBUY.TerminalEkle(t);
            cmbTerminaller.Items.Add(t.TerminalNo.ToString());
        }

        private void btnTerminallistele_Click(object sender, EventArgs e)
        {
            txtTerminalListelemeEkrani.Text = ByBUY.Terminallistele();
        }
        Terminal terminal = new Terminal();
        
        private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            terminal = ByBUY.TerminalBul(Convert.ToInt32(cmbTerminaller.SelectedItem.ToString()));
           
            if (terminal == null)
            {
                MessageBox.Show("Lutfen terminal bilgisini seçiniz!");
            }
            else {
                terminal.s.musteri.Ad = txtMusteriAdi.Text;
                terminal.s.musteri.Soyad = txtMusteriSoyad.Text;
                terminal.s.musteri.TelefonNumarasi = txtMusteriTelefon.Text;
                terminal.s.musteri.Adres = txtMusteriAdres.Text;
                MessageBox.Show("Kayıt başarı ile gerçekleştirildi!");
                terminal.s.SatisSepeti.Clear();
            }
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
           
            terminal = ByBUY.TerminalBul(Convert.ToInt32(cmbTerminaller.SelectedItem.ToString()));
            if (terminal == null)
            {
                MessageBox.Show("Lutfen terminal bilgisini seçiniz!");
            }
            else
            {
                Urun u = new Urun();// fonksiyon ürün döndürecek döndürdüğü değeri ürüne eşitleyeceğiz.Ürün bilgilerini kullanacağız.
                u.Kalem = new SatisKalemi();
                u = ByBUY.DukkanStogu.UrunBul(cmbAlinacakUrunler.SelectedItem.ToString());
                u.Kalem.AlinacakMiktar=Convert.ToInt32(nmUDAlinacakUrunMiktari.Value); // numerik updown decimal değer dönüyor convert onun için 
                terminal.s.SepeteUrunEkle(u);
                lblAlinanUrunBilgisi.Text = "Ürün Kodu:"+u.UrunKodu+"\nÜrün Adı:" + u.UrunAdi + "\nAlınan Ürün Adeti:" + u.Kalem.AlinacakMiktar + "\nBirim Ürün Fiyatı:" + u.UrunFiyati;
                ByBUY.DukkanStogu.StokAzalt(u,u.Kalem.AlinacakMiktar);
            }
        }
      public  decimal kazanc = 0;//toplam kazanc hesaplanın dinamik olması için
        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            terminal = ByBUY.TerminalBul(Convert.ToInt32(cmbTerminaller.SelectedItem.ToString()));
            ByBUY.TerminalEkle(terminal);
            
            terminal.s.odeme.OdemeMiktari = Convert.ToDecimal(txtSatisOdemeMiktari.Text);
            terminal.s.ToplamT = terminal.s.ToplamTutarHesapla();
            if (terminal.s.odeme.OdemeMiktari < terminal.s.ToplamT)
            {
                MessageBox.Show("Yetersiz Para Girişi Yaptınız!");
            }
            else {
                lblFaturaBilgisi.Text = "Satış Tutarı:" + terminal.s.ToplamT + Environment.NewLine + "Ödenen Miktar:" + terminal.s.odeme.OdemeMiktari +
                    Environment.NewLine + "Para Üstü:" + (terminal.s.odeme.OdemeMiktari - terminal.s.ToplamT);
                terminal.s.SatisTarihi = DateTime.Now;
         //       ByBUY.Defter.DeftereTerminalEKle(terminal);
                kazanc += terminal.s.ToplamT;
                lblToplamKazanc.Text = kazanc.ToString();
                
                txtHesapDefteriEkrani.Text += Environment.NewLine+"Terminal No:" + terminal.TerminalNo + "Satış Tarihi:" + terminal.s.SatisTarihi + Environment.NewLine + "Ürünler:" + Environment.NewLine +
                    terminal.s.UrunListele() +Environment.NewLine+ "Müşter:" + terminal.s.musteri.Ad + " " + terminal.s.musteri.Soyad + Environment.NewLine +
                    "Tutar" + terminal.s.ToplamT+Environment.NewLine;
            }
                    
        }

        private void btnDefTerGoruntule_Click(object sender, EventArgs e)
        {
            terminal = ByBUY.TerminalBul(Convert.ToInt32(cmbTerminaller.SelectedItem.ToString()));
            ByBUY.TerminalEkle(terminal);
        //    ByBUY.Defter.DeftereTerminalEKle(terminal);
          //  txtHesapDefteriEkrani.Text = ByBUY.Defter.DefterGoruntule();
            
        }
    }
}

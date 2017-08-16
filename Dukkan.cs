using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneyeYonelilProgramlamaFinalProjesi
{
    public class Dukkan
    {
       public List<KasaGorevlisi> KasaGörevlileri = new List<KasaGorevlisi>();
        public List<Terminal> Terminaller = new List<Terminal>();
        
       public  Stok DukkanStogu = new Stok();
       public  KasaGorevlisi KasaGorevlisiBul(string kullaniciadi) 
        {/*Giriş ekranında isim aldığı için listeleme metodunda kullanmaktan ziyade girişte bulmak için oluşturuldu*/
            KasaGorevlisi temp=null;
            foreach (KasaGorevlisi gorevli in KasaGörevlileri)
            {
                if (gorevli.KullaniciAdi == kullaniciadi)
                            {
                    temp= gorevli;
                    break;  } 
            }
           return temp;
        }
        public string GorevliListele()
        {
            string temp = "";
            foreach (KasaGorevlisi gorevli in KasaGörevlileri)
            {
                temp += gorevli.BilgiGoster();
            }
            return temp;
        }
        public string GorevliAra(string isim)// agörevli ararken aynı isimde birden fazla görevli varsa diye yazıldı.
        {
            string temp = "";
            foreach (KasaGorevlisi gorevli in KasaGörevlileri)
            {
                if (gorevli.Ad == isim)
                {
                    temp += "Ad Soyad:   " + gorevli.Ad + " " + gorevli.Soyad + "   Personel No:   " + gorevli.PersonelNo +
                        "   Kullanıcı Adı:   " + gorevli.KullaniciAdi + "   Telefon Numarası:   " + gorevli.TelefonNumarasi + "   Adres:   " + gorevli.Adres +
                        "   Maas:   " + gorevli.Maas+Environment.NewLine;
                }
            }
            return temp;
        }
        public void KasiyerEkle(KasaGorevlisi gorevli)
        {
            KasaGörevlileri.Add(gorevli);
        }
        public void KasiyerCikar(KasaGorevlisi gorevli)
        {
            KasaGörevlileri.Add(gorevli);
        }

        public void TerminalEkle(Terminal t)
        {
            Terminaller.Add(t);
        }
        public void TerminalSil(Terminal t)
        {
            Terminaller.Remove(t);
        }
        public string Terminallistele()
        {
            string temp = "";
            foreach (Terminal trm in Terminaller)
            {
                temp += "Terminal no:" + trm.TerminalNo + "Görevli:" + trm.Gorevli.Ad + " " + trm.Gorevli.Soyad + "Personel No:" + trm.Gorevli.PersonelNo+Environment.NewLine+Environment.NewLine;
            }
            return temp;
        }
        public Terminal TerminalBul(int terminalno)
        {
            Terminal t=null;
            foreach (Terminal trm in Terminaller)
            {
                if (trm.TerminalNo == terminalno)
                {
                    t = trm;
                    break;
                }
            }
            return t;
        }




    }
}

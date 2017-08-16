using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneyeYonelilProgramlamaFinalProjesi
{
  public   class KasaGorevlisi:Kisi
    {
        public int PersonelNo { get; set; }
        public string KullaniciAdi { get; set; }//Giriş Ekranında kullanmak için
        public string Sifre { get; set; } //Giriş Ekranında kullanılmak içing
        public decimal Maas { get; set; }
        public override string BilgiGoster()
        {
            return  "Ad:" + Ad + "Soyadi :" + Soyad + "Adres :" + Adres +
                "Telefon No :" + TelefonNumarasi + "Personel No:" + PersonelNo + "Maas:" + Maas+"Kullanıcı Adı:"+KullaniciAdi+Environment.NewLine+Environment.NewLine;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneyeYonelilProgramlamaFinalProjesi
{
   public  class Stok
    {
        List<Urun> Urunler = new List<Urun>();
        public void StokEkle(Urun urn)
        {
            Urunler.Add(urn);
        }
        public void StokCikar(Urun urn)
        {
            Urunler.Remove(urn);
        }

        /*
        Urun Urunbul(string urunismi) fonksiyonu  
        -Satış Ekranında comboboxtan ürün bilgilerini çekmek için
        -Stok arttırma işlemince ürün bilgilerini edinmede kullanılmak için oluşturuldu.
        Katalogda aynı isimde farklı ürünler olabileceğin için Kasiyer bulma fonksiyonuna benzer bir fonksiyon kullanılacak  
            */
        public Urun UrunBul(string urunismi) 
        {
            Urun temp = null;
            foreach (Urun urn in Urunler)
            {
                if (urn.UrunAdi == urunismi)
                {
                    temp = urn;
                    break;
                }
            }
            return temp;
        }
        public void StokArttır(Urun urn,int eklenecekmiktar)
        {
            urn.StokAdet += eklenecekmiktar;
        }
        public void StokAzalt(Urun urn,int cikarilacakmiktar)
        {
            urn.StokAdet -= cikarilacakmiktar;
        }
        public string StoktaUrunAra(string urunismi) //katalogta ürün araken bu kullanılacak birden fazla aynı isimde ürün olabileceği için
        {
            string temp = "";
            foreach (Urun urn in Urunler)
            {
                if (urn.UrunAdi == urunismi)
                {
                    temp += "Ürün Adı:   " + urn.UrunAdi + "   Ürün Kodu:   " + urn.UrunKodu + "   Ürün Detayı:   " + urn.UrunDetay +
                        "   Ürün Fiyatı:   " + urn.UrunFiyati + "   Stok Adeti:   " + urn.StokAdet + Environment.NewLine + Environment.NewLine;
                }
            }
            return temp;
        }
        public string StokListele()
        {
            string temp = "";
            foreach (Urun urn in Urunler)
            {
                temp += "Ürün Adı:   " + urn.UrunAdi + "   Ürün Kodu:   " + urn.UrunKodu + "   Ürün Detayı:   " + urn.UrunDetay +
                       "   Ürün Fiyatı:   " + urn.UrunFiyati + "   Stok Adeti:   " + urn.StokAdet + Environment.NewLine + Environment.NewLine;
            }
            return temp;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneyeYonelilProgramlamaFinalProjesi
{
    public class Satis
    {
      public   Odeme odeme = new Odeme();
        public DateTime SatisTarihi { get; set; }
        public List<Urun> SatisSepeti = new List<Urun>();
        public Musteri musteri = new Musteri();
        public decimal ToplamT; //liste silindiği için toplamtutarhespalamada hatasını gidermek için
        public void SepeteUrunEkle(Urun u)
        {
            SatisSepeti.Add(u);
        }
        public decimal ToplamTutarHesapla()
        {
            decimal ToplamTutar = 0;
            foreach (Urun urn in SatisSepeti)
            {
                
                ToplamTutar += urn.UrunFiyati * urn.Kalem.AlinacakMiktar;
            }
            return ToplamTutar;
        }
        public string UrunListele()
        {//satış sepetindeki ürünleri listelemesi için Hesap defterinde kullanılmak üzere
            string temp = "";
                foreach (Urun urn in SatisSepeti)
            	{
                temp += urn.UrunAdi+" Fiyati:"+urn.UrunFiyati+Environment.NewLine;
	            }
            return temp;
            }


    }
}

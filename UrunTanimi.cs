using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneyeYonelilProgramlamaFinalProjesi
{
    public abstract class UrunTanimi
    {
        public string UrunAdi { get; set; }
        public string UrunKodu { get; set; }
        public string UrunDetay { get; set; }
        public decimal UrunFiyati { get; set; }
        public int StokAdet { get; set; }

    }
}

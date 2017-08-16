using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneyeYonelilProgramlamaFinalProjesi
{
    public abstract class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string TelefonNumarasi { get; set; }
        public virtual string  BilgiGoster()
        {

            return "Ad:" + Ad + "   Soyad:" + Soyad + "   Telefon Numarası:" + TelefonNumarasi + "   Adres:" + Adres;
        }
    }
}

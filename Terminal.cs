using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneyeYonelilProgramlamaFinalProjesi
{
   public  class Terminal
    {
        public int TerminalNo { get; set; }
        public KasaGorevlisi Gorevli = new KasaGorevlisi();
        public Satis s = new Satis();
    }
}

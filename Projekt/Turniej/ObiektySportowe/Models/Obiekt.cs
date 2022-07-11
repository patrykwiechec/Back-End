using System;
using System.Collections.Generic;

namespace ObiektySportowe.Models
{
    public partial class Obiekt
    {
        public int IdObiekt { get; set; }
        public string Lokalizacja { get; set; } = null!;
        public string Nazwa { get; set; } = null!;
        public int IloscMiejsc { get; set; }
        public int CenaBiletu { get; set; }
        public int CenaBiletuVip { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Turniej.Models
{
    public partial class Zawodnicy
    {
        public Zawodnicy()
        {
            Uczestnictwos = new HashSet<Uczestnictwo>();
        }

        public int IdZawodnika { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Kraj { get; set; } = null!;
        public int IleMedaliT { get; set; }
        public int? IdTrenera { get; set; }

        public virtual Trenerzy? IdTreneraNavigation { get; set; }
        public virtual ICollection<Uczestnictwo> Uczestnictwos { get; set; }
    }
}

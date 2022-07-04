using System;
using System.Collections.Generic;

namespace Turniej.Models
{
    public partial class Zawody
    {
        public Zawody()
        {
            Uczestnictwos = new HashSet<Uczestnictwo>();
        }

        public int IdZawodow { get; set; }
        public string Nazwa { get; set; } = null!;
        public string Lokalizacja { get; set; } = null!;

        public virtual ICollection<Uczestnictwo> Uczestnictwos { get; set; }
    }
}

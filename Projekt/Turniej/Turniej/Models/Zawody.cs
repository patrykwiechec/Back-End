using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turniej.Models
{
    public partial class Zawody
    {
        public Zawody()
        {
            Uczestnictwos = new HashSet<Uczestnictwo>();
        }

        public int IdZawodow { get; set; }
        [Required]
        public string Nazwa { get; set; } = null!;
        [Required]
        public string Lokalizacja { get; set; } = null!;

        public virtual ICollection<Uczestnictwo> Uczestnictwos { get; set; }
    }
}

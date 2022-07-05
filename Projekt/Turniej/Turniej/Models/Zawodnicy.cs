using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Turniej.Models
{
    public partial class Zawodnicy
    {
        public Zawodnicy()
        {
            Uczestnictwos = new HashSet<Uczestnictwo>();
        }

        public int IdZawodnika { get; set; }
        [DisplayName("Imię")]
        [Required]
        public string Imie { get; set; } = null!;
        [DisplayName("Nazwisko")]
        [Required]
        public string Nazwisko { get; set; } = null!;
        [DisplayName("Pochodzenie")]
        [Required]
        public string Kraj { get; set; } = null!;
        [DisplayName("Ilość Medali")]
        [Required]
        public int IleMedaliT { get; set; }
        [DisplayName("ID trenera")]
        [Required]
        public int? IdTrenera { get; set; }

        public virtual Trenerzy? IdTreneraNavigation { get; set; }
        public virtual ICollection<Uczestnictwo> Uczestnictwos { get; set; }
    }
}

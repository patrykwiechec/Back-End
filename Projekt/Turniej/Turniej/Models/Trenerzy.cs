using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Turniej.Models
{
    public partial class Trenerzy
    {
        public Trenerzy()
        {
            Zawodnicies = new HashSet<Zawodnicy>();
        }

        [DisplayName("ID trenera")]
        public int IdTrenera { get; set; }
        [DisplayName("Imię trenera")]
        [Required]
        public string ImieT { get; set; } = null!;
        [DisplayName("Nazwisko trenera")]
        [Required]
        public string NazwiskoT { get; set; } = null!;
        [DisplayName("Ilość Medali")]
        [Required]
        public int IleMedaliT { get; set;}

        public virtual ICollection<Zawodnicy> Zawodnicies { get; set; }
    }
}

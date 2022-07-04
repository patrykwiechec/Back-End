using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Turniej.Models
{
    public partial class Trenerzy
    {
        public Trenerzy()
        {
            Zawodnicies = new HashSet<Zawodnicy>();
        }
       
        
        public int IdTrenera { get; set; }
        [DisplayName("Imię trenera")]
        public string ImieT { get; set; } = null!;
        [DisplayName("Nazwisko trenera")]
        public string NazwiskoT { get; set; } = null!;
        [DisplayName("Ilość Medali")]
        public int IleMedaliT { get; set; }

        public virtual ICollection<Zawodnicy> Zawodnicies { get; set; }
    }
}

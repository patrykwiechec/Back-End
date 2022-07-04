using System;
using System.Collections.Generic;

namespace Turniej.Models
{
    public partial class Trenerzy
    {
        public Trenerzy()
        {
            Zawodnicies = new HashSet<Zawodnicy>();
        }

        public int IdTrenera { get; set; }
        public string ImieT { get; set; } = null!;
        public string NazwiskoT { get; set; } = null!;
        public int IleMedaliT { get; set; }

        public virtual ICollection<Zawodnicy> Zawodnicies { get; set; }
    }
}

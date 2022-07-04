 using System;
using System.Collections.Generic;

namespace Turniej.Models
{
    public partial class Uczestnictwo
    {
        public int IdUczestnictwa { get; set; }
        public int? IdZawodnika { get; set; }
        public int? IdZawodow { get; set; }

        public virtual Zawodnicy? IdZawodnikaNavigation { get; set; }
        public virtual Zawody? IdZawodowNavigation { get; set; }
    }
}

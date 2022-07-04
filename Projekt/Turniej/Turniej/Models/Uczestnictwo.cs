 using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Turniej.Models
{
    public partial class Uczestnictwo
    {
        [DisplayName("ID Uczestnictwa")]
        public int IdUczestnictwa { get; set; }
        [DisplayName("ID Zawodnika")]
        public int? IdZawodnika { get; set; }
        [DisplayName("ID Zawodów")]
        public int? IdZawodow { get; set; }

        public virtual Zawodnicy? IdZawodnikaNavigation { get; set; }
        public virtual Zawody? IdZawodowNavigation { get; set; }
    }
}

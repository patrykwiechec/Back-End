 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Turniej.Models
{
    public partial class Uczestnictwo
    {
        public int IdUczestnictwa { get; set; }
        public int? IdZawodnika { get; set; }
        public int? IdZawodow { get; set; }

        [DisplayName("ID Zawodnika")]
        [Required]
        public virtual Zawodnicy? IdZawodnikaNavigation { get; set; }

        [DisplayName("ID Zawodów")]
        [Required]
        public virtual Zawody? IdZawodowNavigation { get; set; }
    }
}

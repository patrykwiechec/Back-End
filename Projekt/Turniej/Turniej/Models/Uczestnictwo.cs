 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Turniej.Models
{
    public partial class Uczestnictwo
    {
        [DisplayName("ID Uczestnictwa")]
        public int IdUczestnictwa { get; set; }
        [DisplayName("ID Zawodnika")]
        [Required]
        public int? IdZawodnika { get; set; }
        [DisplayName("ID Zawodów")]
        [Required]
        public int? IdZawodow { get; set; }

        public virtual Zawodnicy? IdZawodnikaNavigation { get; set; }
        public virtual Zawody? IdZawodowNavigation { get; set; }
    }
}

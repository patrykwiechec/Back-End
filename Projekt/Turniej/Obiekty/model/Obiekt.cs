using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Obiekty.model
{
    [Table("obiekt")]
    public partial class Obiekt
    {
        [Key]
        public int IdObiekt { get; set; }
        [Column("lokalizacja")]
        [StringLength(30)]
        [Unicode(false)]
        public string Lokalizacja { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Nazwa { get; set; } = null!;
        [Column("Ilosc_miejsc")]
        public int IloscMiejsc { get; set; }
        [Column("Cena_biletu")]
        public int CenaBiletu { get; set; }
        [Column("Cena_biletu_vip")]
        public int CenaBiletuVip { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace calendario.Models
{
    [Table("tiporiego")]
    public partial class Tiporiego
    {
        public Tiporiego()
        {
            Detallecultivos = new HashSet<Detallecultivo>();
        }

        [Key]
        [Column("idTipoRiego", TypeName = "int(11)")]
        public int IdTipoRiego { get; set; }
        [Required]
        [StringLength(45)]
        public string NombreTipoRiego { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty(nameof(Detallecultivo.IdTipoRiegoNavigation))]
        public virtual ICollection<Detallecultivo> Detallecultivos { get; set; }
    }
}

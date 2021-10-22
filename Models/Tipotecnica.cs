using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace calendario.Models
{
    [Table("tipotecnica")]
    public partial class Tipotecnica
    {
        public Tipotecnica()
        {
            Detallecultivos = new HashSet<Detallecultivo>();
        }

        [Key]
        [Column("idTipoTecnica", TypeName = "int(11)")]
        public int IdTipoTecnica { get; set; }
        [Required]
        [StringLength(45)]
        public string NombreTipoTecnica { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty(nameof(Detallecultivo.IdTipoTecnicaNavigation))]
        public virtual ICollection<Detallecultivo> Detallecultivos { get; set; }
    }
}

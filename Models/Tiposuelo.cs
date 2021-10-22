using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace calendario.Models
{
    [Table("tiposuelo")]
    public partial class Tiposuelo
    {
        public Tiposuelo()
        {
            Detallecultivos = new HashSet<Detallecultivo>();
        }

        [Key]
        [Column("idTipoSuelo", TypeName = "int(11)")]
        public int IdTipoSuelo { get; set; }
        [Required]
        [StringLength(45)]
        public string NombreTipoSuelo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty(nameof(Detallecultivo.IdTipoSueloNavigation))]
        public virtual ICollection<Detallecultivo> Detallecultivos { get; set; }
    }
}

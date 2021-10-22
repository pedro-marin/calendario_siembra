using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace calendario.Models
{
    [Table("tiporecurso")]
    public partial class Tiporecurso
    {
        public Tiporecurso()
        {
            Recursos = new HashSet<Recurso>();
        }

        [Key]
        [Column("idTipoRecurso", TypeName = "int(11)")]
        public int IdTipoRecurso { get; set; }
        [Required]
        [StringLength(45)]
        public string NombreTipoRecurso { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty(nameof(Recurso.IdTipoRecursoNavigation))]
        public virtual ICollection<Recurso> Recursos { get; set; }
    }
}

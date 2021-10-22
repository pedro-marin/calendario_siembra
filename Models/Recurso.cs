using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace calendario.Models
{
    [Table("recurso")]
    [Index(nameof(IdCultivo), Name = "FK_Recurso_Cultivo_idx")]
    [Index(nameof(IdTipoRecurso), Name = "FK_Recurso_TipoRecurso_idx")]
    public partial class Recurso
    {
        [Key]
        [Column("idRecurso", TypeName = "int(11)")]
        public int IdRecurso { get; set; }
        [Column("idCultivo", TypeName = "int(11)")]
        public int IdCultivo { get; set; }
        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }
        [Column("idTipoRecurso", TypeName = "int(11)")]
        public int IdTipoRecurso { get; set; }
        [Required]
        [StringLength(45)]
        public string UbicacionRecurso { get; set; }
        public float Tamano { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(IdCultivo))]
        [InverseProperty(nameof(Cultivo.Recursos))]
        public virtual Cultivo IdCultivoNavigation { get; set; }
        [ForeignKey(nameof(IdTipoRecurso))]
        [InverseProperty(nameof(Tiporecurso.Recursos))]
        public virtual Tiporecurso IdTipoRecursoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace calendario.Models
{
    [Table("detallecultivo")]
    [Index(nameof(IdTipoRiego), Name = "FK_DetalleCultivo_TipoRiego_idx")]
    [Index(nameof(IdTipoSuelo), Name = "FK_DetalleCultivo_TipoSuelo_idx")]
    [Index(nameof(IdTipoTecnica), Name = "FK_DetalleCultivo_TipoTecnica_idx")]
    public partial class Detallecultivo
    {
        public Detallecultivo()
        {
            Cultivos = new HashSet<Cultivo>();
        }

        [Key]
        [Column("idDetalleCultivo", TypeName = "int(11)")]
        public int IdDetalleCultivo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Column("idTipoTecnica", TypeName = "int(11)")]
        public int IdTipoTecnica { get; set; }
        [Column("idTipoSuelo", TypeName = "int(11)")]
        public int IdTipoSuelo { get; set; }
        [Column("idTipoRiego", TypeName = "int(11)")]
        public int IdTipoRiego { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(IdTipoRiego))]
        [InverseProperty(nameof(Tiporiego.Detallecultivos))]
        public virtual Tiporiego IdTipoRiegoNavigation { get; set; }
        [ForeignKey(nameof(IdTipoSuelo))]
        [InverseProperty(nameof(Tiposuelo.Detallecultivos))]
        public virtual Tiposuelo IdTipoSueloNavigation { get; set; }
        [ForeignKey(nameof(IdTipoTecnica))]
        [InverseProperty(nameof(Tipotecnica.Detallecultivos))]
        public virtual Tipotecnica IdTipoTecnicaNavigation { get; set; }
        [InverseProperty(nameof(Cultivo.IdDetalleCultivoNavigation))]
        public virtual ICollection<Cultivo> Cultivos { get; set; }

        // Para Listar
        public List<Detallecultivo> Listar()
        {
            var detallecultivos = new List<Detallecultivo>();
            try
            {
                 using(var context = new innodbContext() )
                 {
                     detallecultivos = context.Detallecultivos.ToList();
                 }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return detallecultivos;
        }
    }
}

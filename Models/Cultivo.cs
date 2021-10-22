using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace calendario.Models
{
    [Table("cultivo")]
    [Index(nameof(IdCategoriaCultivo), Name = "FK_Cultivo_CategoriaCultivo_idx")]
    [Index(nameof(IdDetalleCultivo), Name = "FK_Cultivo_DetalleCultivo_idx")]
    public partial class Cultivo
    {
        public Cultivo()
        {
            Recursos = new HashSet<Recurso>();
        }

        [Key]
        [Column("idCultivo", TypeName = "int(11)")]
        public int IdCultivo { get; set; }
        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }
        [Column("idCategoriaCultivo", TypeName = "int(11)")]
        public int IdCategoriaCultivo { get; set; }
        [Column("idDetalleCultivo", TypeName = "int(11)")]
        public int IdDetalleCultivo { get; set; }
        [Required]
        [StringLength(45)]
        public string Estacion { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaTermino { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(IdCategoriaCultivo))]
        [InverseProperty(nameof(Categoriacultivo.Cultivos))]
        public virtual Categoriacultivo IdCategoriaCultivoNavigation { get; set; }
        [ForeignKey(nameof(IdDetalleCultivo))]
        [InverseProperty(nameof(Detallecultivo.Cultivos))]
        public virtual Detallecultivo IdDetalleCultivoNavigation { get; set; }
        [InverseProperty(nameof(Recurso.IdCultivoNavigation))]
        public virtual ICollection<Recurso> Recursos { get; set; }

        // Para Listar
        public List<Cultivo> Listar()
        {
            var cultivos = new List<Cultivo>();
            try
            {
                 using(var context = new innodbContext() )
                 {
                     cultivos = context.Cultivos.ToList();
                 }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return cultivos;
        }
    }
}

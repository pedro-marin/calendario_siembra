using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace calendario.Models
{
    [Table("categoriacultivo")]
    public partial class Categoriacultivo
    {
        public Categoriacultivo()
        {
            Cultivos = new HashSet<Cultivo>();
        }

        [Key]
        [Column("idCategoriaCultivo", TypeName = "int(11)")]
        public int IdCategoriaCultivo { get; set; }
        [Required]
        [StringLength(45)]
        public string NombreCategoria { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty(nameof(Cultivo.IdCategoriaCultivoNavigation))]
        public virtual ICollection<Cultivo> Cultivos { get; set; }
        // Para Listar
        public List<Categoriacultivo> Listar()
        {
            var categoriacultivos = new List<Categoriacultivo>();
            try
            {
                 using(var context = new innodbContext() )
                 {
                     categoriacultivos = context.Categoriacultivos.ToList();
                 }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return categoriacultivos;
        }
    }
}

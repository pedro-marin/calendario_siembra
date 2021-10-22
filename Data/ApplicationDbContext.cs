using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using calendario.Models;

namespace calendario.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<calendario.Models.Categoriacultivo> Categoriacultivo { get; set; }
        public DbSet<calendario.Models.Cultivo> Cultivo { get; set; }
        public DbSet<calendario.Models.Detallecultivo> Detallecultivo { get; set; }
        public DbSet<calendario.Models.Recurso> Recurso { get; set; }
        public DbSet<calendario.Models.Tiporecurso> Tiporecurso { get; set; }
        public DbSet<calendario.Models.Tiporiego> Tiporiego { get; set; }
        public DbSet<calendario.Models.Tiposuelo> Tiposuelo { get; set; }
        public DbSet<calendario.Models.Tipotecnica> Tipotecnica { get; set; }
    }
}

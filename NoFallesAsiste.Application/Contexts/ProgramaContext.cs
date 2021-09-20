using Microsoft.EntityFrameworkCore;
using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Contexts
{
    public class ProgramaContext : DbContext
    {
        public ProgramaContext(DbContextOptions options)
            :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Programa>()
                .HasData
                (
                 new Programa
                 {
                     Id = 1,
                     Name = "Analísis y Desarrollo de sistemas de información",
                     Description = "Programa para el estudio del ciclo de vida del software y su desarrollo",
                     Version = 1.0,
                     TypeProgramId = 1,
                 },
                 new Programa
                 {
                     Id = 2,
                     Name = "Analísis y Desarrollo de software",
                     Description = "Programa para el estudio del ciclo de vida del software y su desarrollo",
                     Version = 2.0,
                     TypeProgramId = 1,
                 }
                );
        }
        public DbSet<Programa> Programas { get; set; }

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoFallesAsiste.Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
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
                     Name = "Analisis y Desarrollo de sistemas de informacion",
                     Description = "Programa para el estudio del ciclo de vida del software y su desarrollo",
                     Version = 1.0,
                     TypeProgramId = 1,
                 },
                 new Programa
                 {
                     Id = 2,
                     Name = "Analisis y Desarrollo de software",
                     Description = "Programa para el estudio del ciclo de vida del software y su desarrollo",
                     Version = 2.0,
                     TypeProgramId = 1,
                 }
                );
        
                modelBuilder.Entity<Ficha>()
                .HasData
                (
                 new Ficha
                 {
                     Id = 1,
                     StartTraining = new DateTime(2021, 01, 01),
                     EndTraining = new DateTime(2022, 01, 01),
                     StartPractice = new DateTime(2021, 06, 01),
                     HoraryId = 1,
                     ProgramId = 1
                 },
                 new Ficha
                 {
                     Id = 2,
                     StartTraining = new DateTime(2022, 01, 01),
                     EndTraining = new DateTime(2023, 01, 01),
                     StartPractice = new DateTime(2022, 06, 01),
                     HoraryId = 1,
                     ProgramId = 2
                 }
                );
        }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Programa> Programas { get; set; }
    }
}

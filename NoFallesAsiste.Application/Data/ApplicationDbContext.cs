using ControlAsitencia.Models;
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
            modelBuilder.Entity<Programs>()
                .HasData
                (
                 new Programs
                 {
                     ProgramsId = 1,
                     Name = "Analisis y Desarrollo de sistemas de informacion",
                     Description = "Programss para el estudio del ciclo de vida del software y su desarrollo",
                     Version = 1.0,
                     TypeProgramId = 1,
                 },
                 new Programs
                 {
                     ProgramsId = 2,
                     Name = "Analisis y Desarrollo de software",
                     Description = "Programss para el estudio del ciclo de vida del software y su desarrollo",
                     Version = 2.0,
                     TypeProgramId = 1,
                 }
                );
        
                modelBuilder.Entity<Ficha>()
                .HasData
                (
                 new Ficha
                 {
                     FichaId = 1,
                     StartTraining = new DateTime(2021, 01, 01),
                     EndTraining = new DateTime(2022, 01, 01),
                     StartPractice = new DateTime(2021, 06, 01),
                     HoraryId = 1,
                     ProgramId = 1
                 },
                 new Ficha
                 {
                     FichaId = 2,
                     StartTraining = new DateTime(2022, 01, 01),
                     EndTraining = new DateTime(2023, 01, 01),
                     StartPractice = new DateTime(2022, 06, 01),
                     HoraryId = 1,
                     ProgramId = 2
                 }
                );
            modelBuilder.Entity<Class>()
           .HasData
           (
            new Class
            {
                ClassId= 1,
                ClassStartDateTime = new DateTime(2021,09,21,12,0,0),
                ClassRoom = "Meet",
                Name = "Programssción profunda",
                Description = "Manejo de framework Entity de .net",
                FichaId = 1
            },
            new Class
            {
                ClassId = 2,
                ClassStartDateTime = new DateTime(2021, 09, 21, 12, 0, 0),
                ClassRoom = "Meet",
                Name = "English 2",
                Description = "Future with will",
                FichaId = 1
            }
           );
        }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Programs> Programss { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AssignedFicha> AssignedFichas { get; set; }
        public DbSet<Class> classes { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Contexts
{
    public class FichaContext : DbContext
    {
        public FichaContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ficha>()
                .HasData
                (
                 new Ficha
                 {
                     Id = 1,
                     StartTraining = new DateTime(2021,01,01),
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
    }
}

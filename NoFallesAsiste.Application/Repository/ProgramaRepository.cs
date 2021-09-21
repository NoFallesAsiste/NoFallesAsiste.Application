using NoFallesAsiste.Application.Contracts;
using NoFallesAsiste.Application.Data;
using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Repository
{
    public class ProgramaRepository : IProgramaRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreatePrograma(Programa programa)
        {
            _context.Add(programa);
            _context.SaveChanges();
        }


            public void DeletePrograma(int id)
            {
                var programa = _context.Programas.Find(id);
                _context.Programas.Remove(programa);
                _context.SaveChanges();
            }

            public void EditPrograma(Programa programa)
            {
                _context.Update(programa);
                _context.SaveChanges();
            }

            public bool ProgramaExists(int id) => _context.Programas.Any(e => e.Id == id);

            public IEnumerable<Programa> GetAll() => _context.Programas.ToList();

            public Programa GetPrograma(int id) => _context.Programas
                .SingleOrDefault(e => e.Id.Equals(id));
        }
    }
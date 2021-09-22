using NoFallesAsiste.Application.Contracts;
using NoFallesAsiste.Application.Data;
using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Repository
{
    public class ProgramsRepository : IProgramsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreatePrograms(Programs programs)
        {
            _context.Add(programs);
            _context.SaveChanges();
        }


            public void DeletePrograms(int id)
            {
                var programs = _context.Programss.Find(id);
                _context.Programss.Remove(programs);
                _context.SaveChanges();
            }

            public void EditPrograms(Programs programs)
            {
                _context.Update(programs);
                _context.SaveChanges();
            }

            public bool ProgramsExists(int id) => _context.Programss.Any(e => e.ProgramsId == id);

            public IEnumerable<Programs> GetAll() => _context.Programss.ToList();

            public Programs GetPrograms(int id) => _context.Programss
                .SingleOrDefault(e => e.ProgramsId.Equals(id));
        }
    }
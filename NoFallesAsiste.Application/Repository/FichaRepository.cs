using NoFallesAsiste.Application.Contracts;
using NoFallesAsiste.Application.Data;
using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Repository
{
    public class FichaRepository : IFichaRepository
    {
        private readonly ApplicationDbContext _context;

        public FichaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateFicha(Ficha ficha)
        {
            _context.Add(ficha);
            _context.SaveChanges();
        }    

        public void DeleteFicha(int id)
        {
            var ficha = _context.Fichas.Find(id);
            _context.Fichas.Remove(ficha);
            _context.SaveChanges();
        }

        public void EditFicha(Ficha ficha)
        {
            _context.Update(ficha);
            _context.SaveChanges();
        }

        public bool FichaExists(int id) => _context.Fichas.Any(e => e.FichaId == id);

        public IEnumerable<Ficha> GetAll() => _context.Fichas.ToList();

        public Ficha GetFicha(int id) => _context.Fichas
            .SingleOrDefault(e => e.FichaId.Equals(id));
    }
}

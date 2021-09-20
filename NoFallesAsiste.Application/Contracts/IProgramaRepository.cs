using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Contracts
{
    public interface IProgramaRepository
    {
        IEnumerable<Programa> GetAll();
        Programa GetPrograma(int id);
        void CreatePrograma(Programa programa);
        void DeletePrograma(int id);
        void EditPrograma(Programa programa);
        bool ProgramaExists(int id);
    }
}

using NoFallesAsiste.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.WebApp.Contracts
{
    public interface IFichaRepository
    {
        IEnumerable<Ficha> GetAll();
        Ficha GetFicha(int id);
        void CreateFicha(Ficha ficha);
        void DeleteFicha(int id);
        void EditFicha(Ficha ficha);
        bool FichaExists(int id);
    }
}

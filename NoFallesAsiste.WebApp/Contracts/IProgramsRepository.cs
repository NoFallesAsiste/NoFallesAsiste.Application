using NoFallesAsiste.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.WebApp.Contracts
{
    public interface IProgramsRepository
    {
        IEnumerable<Programs> GetAll();
        Programs GetPrograms(int id);
        void CreatePrograms(Programs Programss);
        void DeletePrograms(int id);
        void EditPrograms(Programs Programss);
        bool ProgramsExists(int id);
    }
}

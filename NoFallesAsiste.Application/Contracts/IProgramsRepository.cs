using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Contracts
{
    public interface IProgramsRepository
    {
        IEnumerable<Programs> GetAll();
        Programs GetPrograms(int id);
        void CreatePrograms(Programs programs);
        void DeletePrograms(int id);
        void EditPrograms(Programs programs);
        bool ProgramsExists(int id);
    }
}

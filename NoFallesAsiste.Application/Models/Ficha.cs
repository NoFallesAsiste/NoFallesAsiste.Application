using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Models
{
    [Table("Ficha")]
    public class Ficha
    {
        [Key]
        public int FichaId { get; set; }
        [Required(ErrorMessage = "La fecha de inicio de la formación es requerida")]
        public DateTime StartTraining { get; set; }
        public DateTime EndTraining { get; set; }
        public DateTime StartPractice { get; set; }

        [Required(ErrorMessage = "El horario de la ficha es requerido")]
        public int HoraryId { get; set; }

        //Foreing Key
        [Required(ErrorMessage = "El programa de la ficha es requerido")]
        public int ProgramId { get; set; }
        public Programs Programs { get; set; }

        //Navegation properties
        private ICollection<AssignedFicha> AssignedFicha { get; set; }
    }
}

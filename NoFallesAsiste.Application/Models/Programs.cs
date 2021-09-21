using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Models
{
    [Table("Programs")]
    public class Programs
    {
        [Key]
        public int ProgramsId { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Nombre del programa requerido")]
        public string Name { get; set; }

        [StringLength(450)]
        [Required(ErrorMessage = "Descripcion del programa requerido")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Version del programa requerida")]
        public double Version { get; set; }

        //Foreing Key        
        [Required(ErrorMessage = "El tipo de programa requerido")]
        public int TypeProgramId { get; set; }

        //Mapping Objet
        public ICollection<Ficha> Fichas { get; set; }
    }
}

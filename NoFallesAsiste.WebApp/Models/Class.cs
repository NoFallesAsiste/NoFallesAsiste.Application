using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.WebApp.Models
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "La fecha de inicio de la clase es requerida")]
        public DateTime ClassStartDateTime { get; set; }

        [Required(ErrorMessage = "El aula de la clase es requerida")]
        public string ClassRoom { get; set; }

        [Required(ErrorMessage = "El nombre de la clase es requerida")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El descripción de la clase es requerida")]
        public string Description { get; set; }

        //Foreing Key
        [Required(ErrorMessage = "La ficha a la es asignada la clase es requerida")]
        public int FichaId { get; set; }
        public Ficha Ficha { get; set; }
    }
}

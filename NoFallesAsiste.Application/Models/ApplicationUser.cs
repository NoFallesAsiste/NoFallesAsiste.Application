using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.Application.Models
{
    
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Pais { get; set; }

        //propiedad de navegacion
        private ICollection<AssignedFicha> AssignedFicha { get; set; }
        //public ICollection<Asistencia> Asistencias { get; set; }


    }
}

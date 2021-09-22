using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.WebApp.Models
{
    [Table("AssignedFicha")]
    public class AssignedFicha
    {
        [Key]
        public int AssignedFichaId { get; set; }

        //Foreing Key Status Assigned Ficha
        [Required(ErrorMessage = "El estado del usuario en la ficha es requerido")]
        public int StatusAssignedFichaId { get; set; }

        //Foreing Key Ficha
        [Required(ErrorMessage = "La ficha asignada al usuario requerida")]
        public int FichaId { get; set; }
        public Ficha Ficha { get; set; }

        //Foreing Key AspUser
        [Required(ErrorMessage = "El usuario asignado a la ficha es requerido")]
        public int AspNetUsersId { get; set; }
        public IdentityUser AspNetUsers { get; set; }
    }
}

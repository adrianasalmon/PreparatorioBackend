using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIPrueba.Models
{
    public enum CategoryType
    {
        Estudiante=10,
        Administrativo=20,
        Docente=30,
        Seguridad=40,
        Limpieza=50

    }
    public class Prueba
    {
        [Key]
        public int SalmonID { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [StringLength(24, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 2)]
        [Display(Name = "Nombre Completo")]
        public string FriendofSalmon { get; set; }


        [Required(ErrorMessage = "You must enter the field {0}")]
        public CategoryType Place { get; set; }


        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; } 


        [Display(Name = "Cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy]", ApplyFormatInEditMode = true)]
        public int Birthdate { get; set; }
    }
}
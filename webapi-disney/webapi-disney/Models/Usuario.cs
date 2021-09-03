using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDisney.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El usuario no puede estar vacio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña no puede estar vacia")]
        public string Password { get; set; }
        //[Compare("Password", ErrorMessage ="Las contraseñasno coinciden")]
        //[NotMapped]
        //public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}

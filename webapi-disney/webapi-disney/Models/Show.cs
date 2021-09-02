using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using webapi_disney.Validation;

namespace webapi_disney.Models
{
    public class Show
    {
        [Key]
        public int IdShow { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime Creacion { get; set; }

        [CheckValidQualification]
        public float Calificacion { get; set; }
        public List<Show> Personajes { get; set; }
        //public int IdGenero { get; set; }
        //[ForeignKey("IdGenero")]
        public Genero Genero { get; set; }
    }
}

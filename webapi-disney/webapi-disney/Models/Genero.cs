using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_disney.Models
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public List<Show> ShowsAsociados { get; set; }
    }
}

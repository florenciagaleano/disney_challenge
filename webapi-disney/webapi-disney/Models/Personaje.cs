using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDisney.Models
{
    public class Personaje
    {
        [Key]
        public int IdPersonaje { get; set; }
        /// <summary>
        /// Imagen del personaje
        /// </summary>
        public string Imagen { get; set; }
        /// <summary>
        /// Nombre del personaje
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Edad del personaje
        /// </summary>
        public int Edad { get; set; }
        /// <summary>
        /// Peso del personaje
        /// </summary>
        public double Peso { get; set; }
        /// <summary>
        /// Historia del personaje
        /// </summary>
        public string Historia { get; set; }
        /// <summary>
        /// Películas o series asociadas del persoanaje
        /// </summary>
        public List<Show> Filmografia { get; set; }
    }
}

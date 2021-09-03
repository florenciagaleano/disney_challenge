using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDisney.Models;
using WebAPIDisney.Data;

namespace WebAPIDisney.Controllers
{
    public class ShowController : Controller
    {
        ApplicationDbContext context;

        public ShowController(ApplicationDbContext context)
        {

            this.context = context;

        }

        [HttpGet("movies")]
        public IEnumerable<Show> Get()
        {
            return context.Shows.ToList().Select(x => new Show
            {
                Imagen = x.Imagen,
                Titulo = x.Titulo,
                Creacion = x.Creacion
            });
        }

        [HttpGet("movies/{id}")]
        public ActionResult<Show> Get(int id)
        {
            Show aux = context.Shows.Find(id);
            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        [HttpPost("movies/create")]
        public ActionResult Post(Show show)
        {
            context.Shows.Add(show);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("movies/update/{show_id}")]
        public ActionResult Put(int show_id, [FromBody] Show show)
        {
            if (show_id != show.IdShow)
            {
                return BadRequest();
            }

            context.Entry(show).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("movies/delete/{show_id}")]
        public ActionResult<Show> Delete(int show_id)
        {
            var show = context.Shows.Find(show_id);

            if (show == null)
            {
                return NotFound();
            }

            context.Shows.Remove(show);
            context.SaveChanges();

            return show;
        }

        [HttpGet("characters/getByTitle/{title}")]
        public IEnumerable<Show> GetByMovie(string title)
        {
            var movies = (from c in context.Shows where c.Titulo.Equals(title) select c).ToList();
            return movies;
        }

    }
}

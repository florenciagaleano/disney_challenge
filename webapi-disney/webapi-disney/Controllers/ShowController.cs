using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_disney.Models;
using WebAPIDisney.Data;

namespace webapi_disney.Controllers
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

        [HttpGet("{id}")]
        public ActionResult<Show> Get(int id)
        {
            Show aux = context.Shows.Find(id);
            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        [HttpPost("create")]
        public ActionResult Post(Show show)
        {
            context.Shows.Add(show);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("update/{show_id}")]
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

        [HttpDelete("delete/{show_id}")]
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

    }
}

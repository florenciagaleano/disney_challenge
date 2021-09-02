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
    public class PersonajeController : Controller
    {
            private readonly ApplicationDbContext context;

            public PersonajeController(ApplicationDbContext context)
            {
                this.context = context;
            }

            [HttpGet("characters")]
            public IEnumerable<Personaje> Get()
            {
                return context.Personajes.ToList().Select(x => new Personaje
                {
                    Imagen = x.Imagen,
                    Nombre = x.Nombre
                });
            }

            [HttpGet("{id}")]
            public ActionResult<Personaje> Get(int id)
            {
                Personaje aux = context.Personajes.Find(id);
                if (aux == null)
                {
                    return NotFound();
                }
                return aux;
            }

            [HttpPost("create")]
            public ActionResult Post(Personaje personaje)
            {
                context.Personajes.Add(personaje);
                context.SaveChanges();

                return Ok();
            }

            [HttpPut("update/{personaje_id}")]
            public ActionResult Put(int personaje_id, [FromBody] Personaje personaje)
            {
                if (personaje_id != personaje.IdPersonaje)
                {
                    return BadRequest();
                }

                context.Entry(personaje).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }

            [HttpDelete("delete/{personaje_id}")]
            public ActionResult<Personaje> Delete(int personaje_id)
            {
                var personaje = context.Personajes.Find(personaje_id);

                if (personaje == null)
                {
                    return NotFound();
                }

                context.Personajes.Remove(personaje);
                context.SaveChanges();

                return personaje;
            }

            //[HttpGet("characters?name={nombre}")]
            [HttpGet("characters/getByName/{nombre}")]
            public IEnumerable<Personaje> GetByName(string nombre)
            {
                var character = (from c in context.Personajes where c.Nombre.Contains(nombre) select c).ToList();
                return character;
            }

            [HttpGet("characters/getByAge/{edad}")]
            public IEnumerable<Personaje> GetByAge(int edad)
            {
                var character = (from c in context.Personajes where c.Edad.Equals(edad) select c).ToList();
                return character;
            }

            [HttpGet("characters/getByMovie/{idMovie}")]
            public IEnumerable<Personaje> GetByMovie(int idMovie)
            {
                var character = (from c in context.Personajes where c.Filmografia.Equals(idMovie) select c).ToList();
                return character;
            }
    }
}

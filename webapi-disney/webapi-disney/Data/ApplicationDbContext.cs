using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDisney.Models;

namespace WebAPIDisney.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
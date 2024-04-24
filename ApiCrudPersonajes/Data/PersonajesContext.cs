using ApiCrudPersonajes.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ApiCrudPersonajes.Data
{
    public class PersonajesContext: DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) : base(options) { }

        public DbSet<Personaje> Personajes { get; set; }
    }
}

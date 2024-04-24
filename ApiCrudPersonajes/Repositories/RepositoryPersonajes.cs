using ApiCrudPersonajes.Data;
using ApiCrudPersonajes.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ApiCrudPersonajes.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            List<Personaje> personajes = await this.context.Personajes.ToListAsync();

            return personajes;
        }

        public async Task<Personaje> FindPersonajeAsync(int idPersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(Z => Z.IdPersonaje == idPersonaje);
        }
        public async Task InsertPersonajeAsync(Personaje personaje)
        {
            Personaje per = new Personaje();
            per.IdPersonaje = personaje.IdPersonaje;
            per.Nombre = personaje.Nombre;
            per.Imagen = personaje.Imagen;
            per.Serie = personaje.Serie;
            this.context.Personajes.Add(per);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonaje(int idPersonaje)
        {
            Personaje per = await this.FindPersonajeAsync(idPersonaje);
            this.context.Personajes.Remove(per);
            await this.context.SaveChangesAsync();

        }

        public async Task UpdateDoctorAsync(int id, string nombre, string imagen, string serie)
        {
            Personaje per = await this.FindPersonajeAsync(id);
            per.Nombre = nombre;
            per.Imagen = imagen;
            per.Serie = serie;
            await this.context.SaveChangesAsync();
        }


        public async Task<List<string>> GetSeriesAsync()
        {
            List<string> especialidades = await this.context.Personajes.Select(x => x.Serie).Distinct().ToListAsync();

            return especialidades;
        }

        public async Task<List<Personaje>> GetPersonajesSerieAsync(string serie)
        {
            List<Personaje> personajes = await this.context.Personajes.Where(x => x.Serie == serie).ToListAsync();

            return personajes;
        }

    }
}

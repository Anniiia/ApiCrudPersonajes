using ApiCrudPersonajes.Models;
using ApiCrudPersonajes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindDoctor(int id)
        {
            Personaje per = await this.repo.FindPersonajeAsync(id);

            return per;

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonajeAsync(personaje);

            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonaje(id);

            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdateDoctorAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<ActionResult<List<string>>> Series()
        {
            List<string> series = await this.repo.GetSeriesAsync();

            return series;
        }

        [HttpGet]
        [Route("[action]/{serie}")]

        public async Task<ActionResult<List<Personaje>>> PersonajesSerie(string serie)
        {
            List<Personaje> personajes = await this.repo.GetPersonajesSerieAsync(serie);

            return personajes;
        }
    }
}

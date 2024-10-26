using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminPokemonController : PokemonController
    {
        private readonly IPokemonRepository repository;
        public AdminPokemonController(IPokemonRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesErrorResponseType(typeof(Exception))]
        public override IActionResult GetAll()
        {
            var pokemons = repository.GetAll();

            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public override IActionResult GetPokemonById(int id)
        {
            var pokemon = repository.GetPokemonById(id);
            if (pokemon == null)
            {
                return NotFound(); // Return a 404 if the Pokemon is not found
            }

            return Ok(pokemon);
        }

    }
}

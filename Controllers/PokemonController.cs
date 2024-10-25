using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;
        public PokemonController(IPokemonRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pokemons = _repository.GetAll();

            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public IActionResult GetPokemonById(int id)
        {
            if (!_repository.PokemonExists(id))
                return NotFound();

            
            var pokemon = _repository.GetPokemonById(id);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(pokemon);
        }

        [HttpGet("{name}/getbyName")]
        public IActionResult GetPokemon(string name)
        {
            if (!_repository.PokemonExists(name))
            {
                return NotFound();
            }


            var pokemon = _repository.GetPokemon(name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemon);
        }

        [HttpGet("{id}/exists")]
        public IActionResult Exists(int id)
        {
            var doesPokemonExist = _repository.PokemonExists(id);
            return Ok(doesPokemonExist);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _repository.Delete(id);

            return isDeleted ? Ok(isDeleted) : BadRequest();
        }

        [HttpPost]
        public IActionResult Add(Pokemon pokemon)
        {
            var addedPokemon = _repository.Add(pokemon);

            return Ok(addedPokemon);
        }

        
        
    }
}

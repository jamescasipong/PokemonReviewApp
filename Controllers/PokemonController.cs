using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;


namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {

        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;



        public PokemonController(IPokemonRepository repository, IMapper mapper = null)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual IActionResult GetAll()
        {
        

            var pokemon = _mapper.Map<ICollection<PokemonDto>>(_repository.GetAll());

            return Ok(pokemon);
        }


        [HttpGet("{id}"), 
        ProducesResponseType(typeof(Pokemon), 200), 
        ProducesResponseType(404), 
        ProducesResponseType(400), 
        Tags("Pokemon")]
        public virtual IActionResult GetPokemonById(int id)
        {
            if (!_repository.PokemonExists(id))
                return NotFound();


            var pokemon = _mapper.Map<PokemonDto>(_repository.GetPokemonById(id));


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

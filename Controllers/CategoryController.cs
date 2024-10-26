using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using System.Collections;

namespace PokemonReviewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        
        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<ICollection<CategoryDto>>(_repository.GetCategories());

            return Ok(categories);
        }


        [HttpGet("{id}/")]
        [ProducesResponseType(200, Type = typeof(ICollection))]
        public IActionResult GetCategory(int id)
        {
            if (!_repository.CategoryExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categories = _mapper.Map<CategoryDto>(_repository.GetCategory(id));

            return Ok(categories);
        }


        [HttpGet("{id}/pokemoncategory")]
        [ProducesResponseType(200, Type = typeof(ICollection))]
        public IActionResult GetPokemonCategories(int id)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var pokemonCategories = _repository.GetPokemonCategories(id);

            return Ok(pokemonCategories);
        }

        [HttpGet("{id}/exists")]
        public IActionResult CategoryExists(int id)
        {
            var pokemonCategories = _repository.CategoryExists(id);

            return Ok(pokemonCategories);
        }
    }
}

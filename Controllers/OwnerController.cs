using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;
using System.Collections.Generic;

namespace PokemonReviewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController: Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper) {
            _mapper = mapper;
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<ICollection<ReviewDto>>(_ownerRepository.GetOwners());

            return Ok(owners);
        }

        [HttpGet("{id}")]
        public IActionResult GetOwner(int id) {
            var owner = _mapper.Map<PokemonDto>(_ownerRepository.GetOwner(id));

            return Ok(owner);
        }

        [HttpGet("owners/{id}")]
        public IActionResult GetOwnersOfAPokemon(int id)
        {
            var owners = _mapper.Map<ICollection<PokemonDto>>(_ownerRepository.GetOwnersOfAPokemon(id));

            return Ok(owners);
        }

        [HttpGet("pokemonByOwner/{id}")]
        public IActionResult GetPokemonByOwner(int id)
        {
            var pokemons = _mapper.Map<ICollection<PokemonDto>>(_ownerRepository.GetPokemonByOwner(id));

            return Ok(pokemons);
        }

        [HttpGet("ownerExist/{id}")]
        public IActionResult OwnerExist(int id)
        {
            return Ok(_ownerRepository.OwnerExist(id));
        }
    }
}

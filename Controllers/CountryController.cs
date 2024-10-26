using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController: Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository countryRepository, IMapper mapper) {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<ICollection<CountryDto>>(_countryRepository.GetCountries());

            if (countries == null )
                return NotFound();
            

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountry(int id)
        {

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(id));

            if (!_countryRepository.CountryExist(id))
                return NotFound();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            return Ok(country);

        }

        [HttpGet("{id}/owners")]
        public IActionResult GetCountriesByOnwers(int id) {

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(id));

            if (!_countryRepository.CountryExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        public IActionResult GetOwnersFromCountry(int id)
        {
            var ownersByCountry = _countryRepository.GetOwnersFromCountry(id);

            if (ownersByCountry == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ownersByCountry);
        }
    }
}

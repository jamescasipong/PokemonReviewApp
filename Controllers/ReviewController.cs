using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        IReviewRepository _reviewRepository;
        IMapper _mapper;
        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetReviews()
        {

            var reviews = _reviewRepository.GetReviews();

            if (reviews == null || reviews.Count == 0) return NotFound();


            if (!ModelState.IsValid) return BadRequest(ModelState);

            var reviewsDto = _mapper.Map<ICollection<ReviewDto>>(reviews);


            return Ok(reviewsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            if (!_reviewRepository.ReviewExist(id)) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);


            var review = _mapper.Map<ICollection<ReviewDto>>(_reviewRepository.GetReview(id));

            return Ok(review);
        }

        [HttpGet("pokemonReviews/{id}")]
        public IActionResult GetReviewsOfAPokemon(int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var reviews = _reviewRepository.GetReviewsOfAPokemon(id);
            var reviewDtos = _mapper.Map<ICollection<ReviewDto>>(reviews);

            if (reviewDtos.Count == 0) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(reviewDtos);
        }

        [HttpGet("reviewExist/{id}")]
        public IActionResult ReviewExist(int id)
        {
            if (!_reviewRepository.ReviewExist(id)) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(_reviewRepository.ReviewExist(id));
        }

    }
}

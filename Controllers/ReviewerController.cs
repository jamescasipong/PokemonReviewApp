using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewerController : Controller
    {
        IReviewerRepository _repository;
        IMapper _mapper;
        public ReviewerController(IReviewerRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetReviewers()
        {
            var reviewers = _repository.GetReviewers();

            if (reviewers.Count == 0) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var revewersDto = _mapper.Map<ICollection<ReviewerDto>>(reviewers);

            return Ok(revewersDto);
        }

        [HttpGet("reviewerId")]
        public IActionResult GetReviewer(int id)
        {
            var reviwer = _repository.GetReviewer(id);

            if (reviwer == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var reviwerDto = _mapper.Map<ReviewerDto>(reviwer);

            return Ok(reviwerDto);
        }

        [HttpGet("reviewsByReviewer")]
        public IActionResult GetReviewsByReviewer(int id)
        {
            var reviews = _repository.GetReviewsByReviwer(id);

            if (reviews.Count == 0) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            var reviewDtos = _mapper.Map<ICollection<Review>>(reviews);

            return Ok(reviewDtos);
        }

        [HttpGet("exists/id")]
        public IActionResult ReviewerExist(int id)
        {
            var reviews = _repository.ReviewerExist(id);

            return Ok(reviews);
        }
    }
}

using AdoptiPet.DTO;
using AdoptiPet.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptiPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IMapper mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetReviews()
        {
            var reviews = mapper.Map<List<ReviewDTO>>(reviewRepository.GetReviews());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }
        [HttpGet("{reviewId}")]
        public IActionResult GetReviewById(int reviewId)
        {
            var review = mapper.Map<ReviewDTO>(reviewRepository.GetById(reviewId));
            if (!reviewRepository.ReviewExists(reviewId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(review);
        }
        [HttpGet("/pet/{petId}")]
        public IActionResult GetReviewsForPet(int petId)
        {
            var review = mapper.Map<List<ReviewDTO>>(reviewRepository.GetReviewsOfAPet(petId));
            if (!reviewRepository.ReviewExists(petId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(review);
        }
    }
}

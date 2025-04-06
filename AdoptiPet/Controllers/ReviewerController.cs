using AdoptiPet.DTO;
using AdoptiPet.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptiPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository reviewerRepository;
        private readonly IMapper mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            this.reviewerRepository = reviewerRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetReviewers()
        {
            var reviewers = mapper.Map<List<ReviewerDTO>>(reviewerRepository.GetReviewers());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviewers);
        }
        [HttpGet("{reviewerId}")]
        public IActionResult GetReviewById(int reviewerId)
        {
            var reviewer = mapper.Map<ReviewerDTO>(reviewerRepository.GetById(reviewerId));
            if (!reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviewer);
        }
        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            var reviews = mapper.Map<List<ReviewDTO>>(reviewerRepository.GetReviewsByReviewer(reviewerId));
            if (!reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }
    }
}

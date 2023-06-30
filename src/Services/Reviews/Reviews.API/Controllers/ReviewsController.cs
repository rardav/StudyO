using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reviews.Domain.Dtos;
using Reviews.Domain.Dtos.CrudDtos;
using Reviews.Domain.Entities;
using Reviews.Infrastructure.Repositories.Contracts;

namespace Reviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private IReviewsRepository _reviewsRepository;
        private IMapper _mapper;

        public ReviewsController(IReviewsRepository reviewsRepository, IMapper mapper)
        {
            _reviewsRepository = reviewsRepository;
            _mapper = mapper;
        }

        [HttpGet("courses/{id}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                var reviews = await _reviewsRepository.GetAllByCourseAsync(id);

                var reviewsDtos = reviews
                    .Select(clss => _mapper.Map<ReviewDto>(clss));

                return Ok(reviewsDtos);
            }

            return BadRequest();
        }

        /// <summary>
        /// Add an review to a particular course.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createReviewDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateReviewDto createReviewDto)
        {
            var review = _mapper.Map<Review>(createReviewDto);

            await _reviewsRepository.CreateAsync(review);

            return NoContent();
        }
    }
}

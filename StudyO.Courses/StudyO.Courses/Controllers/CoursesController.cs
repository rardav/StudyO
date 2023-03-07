using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudyO.Courses.Domain.Dtos;
using StudyO.Courses.Domain.Entities;
using StudyO.Courses.Infrastructure.Repositories.Contracts;

namespace StudyO.Courses.API.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICoursesRepository coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> GetAsync()
        {
            var courses = await _coursesRepository.GetAllAsync();

            var coursesDtos = courses
                .Select(course => _mapper.Map<CourseDto>(course));

            return coursesDtos;  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetByIdAsync(Guid id)
        {
            var course = await _coursesRepository.GetAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return _mapper.Map<CourseDto>(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post(CreateCourseDto createCourseDto)
        {
            var course = _mapper.Map<Course>(createCourseDto);

            await _coursesRepository.CreateAsync(course);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = course.Id }, course);
        }
    }
}

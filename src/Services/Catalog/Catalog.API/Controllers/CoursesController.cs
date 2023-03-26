using AutoMapper;
using Catalog.Domain.Dtos;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            var courses = await _coursesRepository.GetAllAsync();

            var coursesDtos = courses
                .Select(course => _mapper.Map<CourseDto>(course));

            return Ok(coursesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetById(Guid id)
        {
            var course = await _coursesRepository.GetAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            var courseDto = _mapper.Map<CourseDto>(course);

            return Ok(courseDto);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post(CreateCourseDto createCourseDto)
        {
            var course = _mapper.Map<Course>(createCourseDto);

            await _coursesRepository.CreateAsync(course);

            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateCourseDto updateCourseDto)
        {
            var existingCourse = await _coursesRepository.GetAsync(id);

            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse = _mapper.Map<Course>(updateCourseDto);

            await _coursesRepository.UpdateAsync(existingCourse);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var course = await _coursesRepository.GetAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            await _coursesRepository.RemoveAsync(course.Id);

            return NoContent();
        }
    }
}

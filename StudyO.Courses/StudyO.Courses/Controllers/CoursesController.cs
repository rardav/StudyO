using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudyO.Courses.Domain.Dtos;
using StudyO.Courses.Infrastructure.Repositories;

namespace StudyO.Courses.API.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesRepository _coursesRepository = new();
        private readonly IMapper _mapper;

        public CoursesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> Get()
        {
            var courses = await _coursesRepository.GetAllAsync();

            var coursesDtos = courses
                .Select(course => _mapper.Map<CourseDto>(course));

            return coursesDtos;
                
        }
    }
}

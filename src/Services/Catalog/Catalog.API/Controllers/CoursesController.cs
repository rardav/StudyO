using AutoMapper;
using Catalog.Domain.Dtos;
using Catalog.Domain.Dtos.CrudDtos;
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

        /// <summary>
        /// Get all courses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            var courses = await _coursesRepository.GetAllAsync();

            var coursesDtos = courses
                .Select(course => _mapper.Map<CourseDto>(course));

            return Ok(coursesDtos);
        }

        /// <summary>
        /// Get course by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetById(Guid id)
        {
            var course = await _coursesRepository.GetAsync(id);

            if (course is null)
            {
                return NotFound();
            }

            var courseDto = _mapper.Map<CourseDto>(course);

            return Ok(courseDto);
        }

        /// <summary>
        /// Insert a new course.
        /// </summary>
        /// <param name="createCourseDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post(CreateCourseDto createCourseDto)
        {
            var course = _mapper.Map<Course>(createCourseDto);

            await _coursesRepository.CreateAsync(course);

            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        /// <summary>
        /// Update a course information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCourseDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateCourseDto updateCourseDto)
        {
            var existingCourse = await _coursesRepository.GetAsync(id);

            if (existingCourse is null)
            {
                return NotFound();
            }

            existingCourse = _mapper.Map<Course>(updateCourseDto);

            await _coursesRepository.UpdateAsync(existingCourse);

            return NoContent();
        }

        /// <summary>
        /// Delete a course.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var course = await _coursesRepository.GetAsync(id);

            if (course is null)
            {
                return NotFound();
            }

            await _coursesRepository.RemoveAsync(course.Id);

            return NoContent();
        }

        /// <summary>
        /// Insert a new chapter.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="createChapterDto"></param>
        /// <returns></returns>
        [HttpPost("{courseId}/chapters")]
        public async Task<ActionResult> Post(Guid courseId, CreateChapterDto createChapterDto)
        {
            var course = await _coursesRepository.GetAsync(courseId);

            if (course is null)
            {
                return NotFound("Course does not exist.");
            }

            var chapter = _mapper.Map<Chapter>(createChapterDto);

            await _coursesRepository.AddChapterAsync(courseId, chapter);

            return NoContent();
        }

        /// <summary>
        /// Insert a new lesson.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="chapterId"></param>
        /// <param name="createLessonDto"></param>
        /// <returns></returns>
        [HttpPost("{courseId}/chapters/{chapterId}/lessons")]
        public async Task<ActionResult> Post(Guid courseId, Guid chapterId, CreateLessonDto createLessonDto)
        {
            var course = await _coursesRepository.GetAsync(courseId);

            if (course is null)
            {
                return NotFound("Course does not exist.");
            }

            var chapter = course.Chapters.FirstOrDefault(chapter => chapter.Id.Equals(chapterId));

            if (chapter is null)
            {
                return NotFound("Chapter does not exist.");
            }

            var lesson = _mapper.Map<Lesson>(createLessonDto);

            await _coursesRepository.AddLessonAsync(courseId, chapterId, lesson);

            return NoContent();
        }

        /// <summary>
        /// Insert a new lesson.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="createChapterDto"></param>
        /// <returns></returns>
        [HttpPost("{courseId}/chapters/{chapterId}/lessons/{lessonId}/sections")]
        public async Task<ActionResult> Post(Guid courseId, Guid chapterId, Guid lessonId, CreateSectionDto createSectionDto)
        {
            var course = await _coursesRepository.GetAsync(courseId);

            if (course is null)
            {
                return NotFound("Course does not exist.");
            }

            var chapter = course.Chapters.FirstOrDefault(chapter => chapter.Id.Equals(chapterId));

            if (chapter is null)
            {
                return NotFound("Chapter does not exist.");
            }

            var lesson = chapter.Lessons.FirstOrDefault(lesson => lesson.Id.Equals(lessonId));

            if (lesson is null)
            {
                return NotFound("Lesson does not exist.");
            }

            var section = _mapper.Map<Section>(createSectionDto);

            await _coursesRepository.AddSectionAsync(courseId, chapterId, lessonId, section);

            return NoContent();
        }
    }
}

using AutoMapper;
using Classes.Domain.Dtos;
using Classes.Domain.Entities;
using Classes.Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Classes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private IClassesRepository _classesRepository;
        private IMapper _mapper;

        public ClassesController(IClassesRepository classesRepository, IMapper mapper)
        {
            _classesRepository = classesRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> GetById(Guid id)
        {
            var clss = await _classesRepository.GetAsync(id);

            if (clss == null)
            {
                return NotFound();
            }

            return _mapper.Map<ClassDto>(clss);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDto>>> Get([FromQuery] Guid studentId, [FromQuery] Guid instructorId)
        {
            if (studentId != Guid.Empty)
            {
                var classes = await _classesRepository.GetAllByStudentAsync(studentId);

                var classesDtos = classes
                    .Select(clss => _mapper.Map<ClassDto>(clss));

                return Ok(classesDtos);
            }

            if (instructorId != Guid.Empty)
            {
                var classes = await _classesRepository.GetAllByInstructorAsync(instructorId);

                var classesDtos = classes
                    .Select(clss => _mapper.Map<ClassDto>(clss));

                return Ok(classesDtos);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<ClassDto>> Post(CreateClassDto createClassDto)
        {
            var clss = _mapper.Map<Class>(createClassDto);

            await _classesRepository.CreateAsync(clss);

            return CreatedAtAction(nameof(GetById), new { id = clss.Id }, clss);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateClassDto updateClassDto)
        {
            var existingClass = await _classesRepository.GetAsync(id);

            if (existingClass == null)
            {
                return NotFound();
            }

            existingClass = _mapper.Map<Class>(updateClassDto);

            await _classesRepository.UpdateAsync(existingClass);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clss = await _classesRepository.GetAsync(id);

            if (clss == null)
            {
                return NotFound();
            }

            await _classesRepository.RemoveAsync(clss.Id);

            return NoContent();
        }
    }
}

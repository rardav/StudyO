using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Users.Domain.Dtos;
using Users.Domain.Dtos.CrudDtos;
using Users.Infrastucture.Repositories.Contracts;
using Users.Infrastucture.Services.Contracts;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(ITokenService tokenService, IUsersRepository usersRepository, IMapper mapper)
        {
            _tokenService = tokenService;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var user = await _usersRepository.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserDto>(user);
        }

        [HttpGet]
        public async Task<ActionResult<UserDetailsDto>> GetByEmail([FromQuery] string email)
        {
            var user = await _usersRepository.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserDetailsDto>(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            var userExists = await _usersRepository.UserExists(registerDto.Email);

            if (userExists) return BadRequest("An account is already registered with this email address.");

            var user = await _usersRepository.Register(registerDto);

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _tokenService.CreateToken(user);

            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _usersRepository.GetUserByEmail(loginDto.Email);

            if (user == null) return Unauthorized("Incorrect email and/or password.");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Incorrect email and/or password.");
            }

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _tokenService.CreateToken(user);

            return Ok(userDto);
        }
    }
}

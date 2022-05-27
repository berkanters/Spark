using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spark.API.DTOs;
using Spark.Core.IntService;
using Spark.Core.Models;

namespace Spark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet("{gender:alpha}/{minAge:int}/{maxAge:int}")]
        public async Task<IActionResult> GetByGenderAndAge(string gender, short minAge, short maxAge)
        {
            var user = await _userService.GetUserByGenderAndAge(gender, minAge, maxAge);
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var users = await _userService.AddAsync(_mapper.Map<User>(userDto));
            return Created(string.Empty, userDto);
        }
        [HttpPut]
        public  IActionResult Update(UserDto userDto)
        {
            _userService.Update(_mapper.Map<User>(userDto));
            return NoContent();
        }

        [HttpPut("delete/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _userService.SoftDelete(id);
            return NoContent();
        }

        [HttpGet("location/{id:guid}/{id2:guid}")]
        public async Task<IActionResult> CalculateDistance(Guid id, Guid id2)
        {
            var location =  _userService.CalculateDistance(id, id2);
            
            return Ok((int)location + " KM");
        }

        [HttpPost("Login/{email}&{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.FirstOrDefaultAsync(x => x.Email == email);
            if (user.Email != email && user.Password == password)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }
            
            return BadRequest("Wrong Password or Email");
        }

    }
}

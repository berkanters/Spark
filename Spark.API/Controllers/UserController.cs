using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spark.Core.IntService;
using Spark.Core.Models;

namespace Spark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpGet("{gender:alpha}/{minAge:min}/{maxAge:min}")]
        public async Task<IActionResult> GetByGenderAndAge(string gender, short minAge, short maxAge)
        {
            var user = await _userService.GetUserByGenderAndAge(gender, minAge, maxAge);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Save(User user)
        {
            var users = await  _userService.AddAsync(user);
            return Created(string.Empty, users);
        }
        [HttpPut]
        public  IActionResult Update(User user)
        {
            var users =  _userService.Update(user);
            return NoContent();
        }

    }
}

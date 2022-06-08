﻿using AutoMapper;
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

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet("filterby={gender:alpha}&{minAge:int}&{maxAge:int}&{distance:int}&{user1:guid}")]
        public async Task<IActionResult> GetByGenderAndAge(string gender, int minAge, int maxAge,int distance,Guid user1)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByGenderAndAge(gender, minAge, maxAge, distance, user1);
                return Ok(_mapper.Map<IEnumerable<UserDto>>(user));
            }

            return BadRequest();
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

        [HttpPut("/deletebyid")]
        public IActionResult Delete(Guid id)
        {
            _userService.SoftDelete(id);
            return NoContent();
        }

        [HttpGet("/location=id&id1")]
        public async Task<IActionResult> CalculateDistance(Guid id, Guid id2)
        {
            var location =  _userService.CalculateDistance(id, id2);
            
            return Ok((int)location + " KM");
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginDto userdto1)
        {
            var user = await _userService.FirstOrDefaultAsync(x => x.Email == userdto1.Email) ;
            if (user.Email != null && user.Password == userdto1.Password)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }
            
            return BadRequest("Wrong Password or Email");
        }
        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var users = await _userService.AddAsync(_mapper.Map<User>(registerDto));
            return Created(string.Empty, registerDto);
        }
        [HttpPut("/SetLocation")]
        public IActionResult SetLocation(Guid userId, double latitude, double longitude)
        {
            _userService.SetLocation(userId, latitude, longitude);
            return NoContent();
        }
    }
}

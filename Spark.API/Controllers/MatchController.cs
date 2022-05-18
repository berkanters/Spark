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
    public class MatchController : ControllerBase
    {
        private ILikeService _likeService;
        private IMapper _mapper;

        public MatchController(ILikeService likeService, IMapper mapper)
        {
            _likeService = likeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var like = await _likeService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<LikeDto>>(like));
        }

        [HttpPost("{id:guid}/{lId:guid}")]
        public async Task<IActionResult> Save(Guid id, Guid lId)
        {
            _likeService.MatchUsersWithUserIDs(id, lId);
            if (_likeService.IsThereAnyMatch(id,lId))
            {
                return Ok("Match=True");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("unmatch/{id:guid}/{lId:guid}")]
        public async Task<IActionResult> UnMatch(Guid id, Guid lId)
        {
            _likeService.RemoveMatch(id,lId);
            return Ok("Unmatch Succeed");

        }
        
    }
}

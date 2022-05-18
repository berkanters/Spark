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
            return Ok(like);
        }

        [HttpPost("{id:guid}/{lId:guid}")]
        public async Task<IActionResult> Save(LikeDto likeDto,Guid id,Guid lId)
        {
            if (await _likeService.GetByIdAsync().FirstOrDefaultAsync(l => l.LikedUserId != id && l.UserId != lId) == null)
                sparkDbContext.AddAsync(entity);
            return entity;

            //entity.UserId = id;
            //entity.LikedUserId = lId;
            //await sparkDbContext.Likes.AddAsync(entity);
            //await sparkDbContext.SaveChangesAsync();
            //return entity;
        }
        else
        {
            var like = await sparkDbContext.Likes.FirstOrDefaultAsync(x => x.LikedUserId == id && x.UserId == lId);
            return await GetByIdAsync(like.Id);
        }
}
    }
}

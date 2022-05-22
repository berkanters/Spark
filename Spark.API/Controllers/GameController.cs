using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spark.Core.IntService;
using Spark.Core.Models;

namespace Spark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWithAnswer()
        {
            var que= await _gameService.GetAllWithAnswersAsync();
            return  Ok(que);
        }
        [HttpGet("{qId:guid}")]
        public async Task<IActionResult> GetById(Guid qId)
        {
            var que = await _gameService.GetWithAnswersByIdAsync(qId);
            return Ok(que);
        }
    }
}

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
        private IGameService _questionService;

        public GameController(IGameService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public async Task<IEnumerable<IActionResult>> GetAllWithAnswer()
        {
            var que= await _questionService.GetAllWithAnswersAsync();
            return Ok(que);
        }
        [HttpGet("{qId:guid}")]
        public async Task<IActionResult> GetById(Guid qId)
        {
            var que = await _questionService.GetWithAnswersByIdAsync(qId);
            return Ok(que);
        }
    }
}

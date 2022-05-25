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
        private IUserAnswerService _userAnswerService;

        public GameController(IGameService gameService, IUserAnswerService userAnswerService)
        {
            _gameService = gameService;
            _userAnswerService = userAnswerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithAnswer()
        {
            var que = await _gameService.GetAllWithAnswersAsync();
            return Ok(que);
        }

        [HttpGet("{qId:guid}")]
        public async Task<IActionResult> GetById(Guid qId)
        {
            var que = await _gameService.GetWithAnswersByIdAsync(qId);
            return Ok(que);
        }

        [HttpGet("/useranswer")]
        public async Task<IActionResult> GetUserAnswer()
        {
            var que = await _userAnswerService.GetAllAsync();
            return Ok(que);
        }
        [HttpGet("/useranswer/{userId:guid}/{qId:guid}")]
        public async Task<IActionResult> GetUserAnswer(Guid userId, Guid qId)
        {
            var que = await _userAnswerService.GetUserAnswer(userId, qId);
            return Ok(que);
        }

        [HttpPost("{uId:guid}/{aId:guid}/{qId:guid}")]
        public async Task<IActionResult> ChooseAnswerCont(Guid uId, Guid aId,Guid qId)
        {
            await _gameService.GetWithAnswersByIdAsync(aId);
            var userAns = await _userAnswerService.ChooseAnswer(uId, aId,qId);
            if (userAns != null)
            {
                return BadRequest("You have already answered this question");
            }

            return Ok();
        }

        [HttpGet("{qId:guid}/{uId:guid}/answers")]
        public async Task<IActionResult> GetFakeAnswers(Guid qId, Guid uId)
        {
            return Ok(_gameService.GetFakeAnswers(qId, uId));
        }
    }
}

﻿using System.Collections;
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
    public class GameController : ControllerBase
    {
        private IGameService _gameService;
        private IUserAnswerService _userAnswerService;
        private ILikeService _likeService;
        private IMapper _mapper;

        public GameController(IGameService gameService, IUserAnswerService userAnswerService, ILikeService likeService, IMapper mapper)
        {
            _gameService = gameService;
            _userAnswerService = userAnswerService;
            _likeService = likeService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWithAnswer()
        {
            var que = await _gameService.GetAllWithAnswersAsync();
            return Ok(que);
        }

        [HttpGet("/getquestions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var que = await _gameService.GetAllQuestions();
            return Ok(_mapper.Map<IEnumerable<QuestionDto>>(que));
        }

        [HttpGet("/getquestionwithanswer=id")]
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
        [HttpGet("/useranswer=id&qid")]
        public async Task<IActionResult> GetUserAnswer(Guid userId, Guid qId)
        {
            var que = await _userAnswerService.GetUserAnswer(userId, qId);
            return Ok(que);
        }

        [HttpPost("/chooseuseranswer=uid&aid&qid")]
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


        [HttpPut("/ScoreUp=id1&id2&score")]
        public async Task<IActionResult> ScoreUp(Guid id1, Guid id2, int score)
        {

            _likeService.ScoreUp(id1, id2, score);

            if (_likeService.IsThereAnyWin(id1, id2))
            {
                return Ok("IsWin = True");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet("/wronganswers=qid&uid")]
        public async Task<IActionResult> GetFakeAnswers(Guid qId, Guid uId)
        {
            var fake = _gameService.GetFakeAnswers(qId, uId);
            var userAns = _userAnswerService.GetUserAnswer(uId, qId);

            return Ok((fake, userAns != null ? userAns.Result : null));

        }
    }
}

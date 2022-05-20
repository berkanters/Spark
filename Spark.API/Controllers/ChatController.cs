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
    public class ChatController : ControllerBase
    {
        private IChatService _chatService;
        private IMapper _mapper;

        public ChatController(IChatService chatService, IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chats = await _chatService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ChatDto>>(chats));
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatDto chatDto)
        {
            ModelState.Remove("MessageDate");
            var chat = _mapper.Map<Chat>(chatDto);
            chat.MessageDate = DateTime.Now;
            await _chatService.AddAsync(chat);
            return Ok();
        }
        [HttpGet("messages/{id:guid}/{id2:guid}")]
        public async Task<IActionResult> GetMessages(Guid id, Guid id2)
        {
            var messages = await _chatService.GetMessagesBetween2Person(id, id2);
            return Ok(_mapper.Map<IEnumerable<ChatDto>>(messages));
        }
    }
}

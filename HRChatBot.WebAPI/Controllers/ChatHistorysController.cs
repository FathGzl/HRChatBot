using HRChatBot.Shared.Dtos.ChatHistory;
using HRChatBot.WebAPI.Context;
using HRChatBot.WebAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRChatBot.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHistorysController : ControllerBase
    {
        private readonly HRChatBotContext _context;

        public ChatHistorysController(HRChatBotContext context)
        {
            _context = context;
        }

        [HttpPost("addchathistory")]
        public async Task<ActionResult> AddChatHistory(CreateChatHistoryDto createChatHistoryDto)
        {
            _context.ChatHistories.Add(new ChatHistory
            {
                FromUserId = createChatHistoryDto.FromUserId,
                ToUserId = createChatHistoryDto.ToUserId,
                Message = createChatHistoryDto.Message,
                CreatedDate = DateTime.Now

            });
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("getallchathistory/{fromUserId}")]
        public async Task<List<ResultChatHistoryDto>> GetAllChatHistory(long fromUserId)
        {
            var list = await _context.ChatHistories.Where(u => u.FromUserId == fromUserId).ToListAsync();
            return list.Select(x => new ResultChatHistoryDto
            {
                FromUserId = x.FromUserId,
                ToUserId = x.ToUserId,
                ChatHistoryId = x.ChatHistoryId,
                CreatedDate = x.CreatedDate,
                Message = x.Message
            }).ToList();
        }
    }
}

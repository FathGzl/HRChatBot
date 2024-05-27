using HRChatBot.Shared.Dtos.ChatHistory;
using HRChatBot.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRChatBot.ViewModels
{
    public interface IChatHistoryViewModel
    {
        Task AddChatHistoryAsync(CreateChatHistoryDto createChatHistoryDto);
        Task<List<ResultChatHistoryDto>> GetAllChatHistory(string id);

    }
}

using HRChatBot.Shared.Dtos.ChatHistory;
using HRChatBot.Shared.Extensions;
using HRChatBot.Shared.Models;
using HRChatBot.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRChatBot.ViewModels
{
    public class ChatHistoryViewModel : IChatHistoryViewModel
    {
        private readonly HttpClient _httpClient;
        private readonly IAccessTokenService _accessTokenService;
        public ChatHistoryViewModel()
        {
        }
        public ChatHistoryViewModel(HttpClient httpClient, IAccessTokenService accessTokenService = null)
        {
            _httpClient = httpClient;
            _accessTokenService = accessTokenService;
        }

        public async Task AddChatHistoryAsync(CreateChatHistoryDto createChatHistoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateChatHistoryDto>("api/chathistorys/addchathistory", createChatHistoryDto);
        }
        public async Task<List<ResultChatHistoryDto>> GetAllChatHistory(string id)
        {
            var responseMessage = await _httpClient.GetAsync("api/chathistorys/getallchathistory/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<List<ResultChatHistoryDto>>();
            return value;
        }
    }
}

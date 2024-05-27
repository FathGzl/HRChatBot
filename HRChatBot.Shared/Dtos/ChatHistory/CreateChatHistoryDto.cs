using System;

namespace HRChatBot.Shared.Dtos.ChatHistory
{
    public class CreateChatHistoryDto
    {
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

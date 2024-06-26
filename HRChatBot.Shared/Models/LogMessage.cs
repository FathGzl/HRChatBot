﻿using System;

namespace HRChatBot.Shared.Models
{
    public sealed record LogMessage
    {
        public long LogId { get; init; }
        public string LogLevel { get; init; }
        public string Source { get; init; }
        public string ExceptionMessage { get; init; }
        public string StackTrace { get; init; }
        public DateTime CreatedDate { get; init; }
        public long? UserId { get; init; }
    }
}

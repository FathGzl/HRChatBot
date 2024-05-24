using HRChatBot.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRChatBot.WebAPI.Logging
{
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        private readonly IDbContextFactory<LoggingHRChatBotContext> _contextFactory;

        public ApplicationLoggerProvider(IDbContextFactory<LoggingHRChatBotContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(_contextFactory);
        }

        public void Dispose()
        {

        }
    }
}

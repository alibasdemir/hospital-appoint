using Infrastructure.SignalR.Entities;

namespace Infrastructure.SignalR.HubService
{
    public class LiveChatHubService : ILiveChatHubService
    {
        private readonly List<ChatMessage> _messages = new();
        public Task<List<ChatMessage>> GetMessagesAsync()
        {
            return Task.FromResult(_messages);
        }

        public Task SendMessageAsync(string user, string message)
        {
            _messages.Add(new ChatMessage { User = user, Message = message, Timestamp = DateTime.Now });
            return Task.CompletedTask;
        }
    }
}

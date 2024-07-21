using Infrastructure.SignalR.Entities;

namespace Infrastructure.SignalR.HubService
{
    public interface ILiveChatHubService
    {
        Task SendMessageAsync(string user, string message);
        Task<List<ChatMessage>> GetMessagesAsync();
    }
}

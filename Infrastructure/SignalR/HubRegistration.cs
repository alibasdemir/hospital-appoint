using Infrastructure.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.SignalR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<LiveChatHub>("/chathub");//()=>endpoint name/route
        }
    }
}

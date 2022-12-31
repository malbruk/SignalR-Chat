using Microsoft.AspNetCore.SignalR;

namespace Blazor_SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Message", user, message);
        }
    }
}

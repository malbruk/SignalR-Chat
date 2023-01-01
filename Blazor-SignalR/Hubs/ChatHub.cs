using Blazor_SignalR.Data;
using Microsoft.AspNetCore.SignalR;

namespace Blazor_SignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatService _chatService;

        public ChatHub(ChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string message, string toUser)
        {
            var userName = _chatService.Users[Context.ConnectionId];
            if (string.IsNullOrEmpty(toUser))
            {
                await Clients.All.SendAsync("ReceiveMessage", userName, message);
            }
            else
            {
                var toUserConnectionId = _chatService.Users.FirstOrDefault(u=>u.Value == toUser).Key;
                if(toUserConnectionId is not null)
                {
                    await Clients.Client(toUserConnectionId).SendAsync("PrivateMessage", userName, message);
                }
            }
        }
    }
}

namespace Blazor_SignalR.Data
{
    public class ChatService
    {
        public Dictionary<string, String> Users { get; set; }


        public ChatService()
        {
            Users = new Dictionary<string, String>();
        }

        public void AddUser(string? connectionId, string? userName)
        {
            if (string.IsNullOrEmpty(connectionId) || string.IsNullOrEmpty(userName))
                throw new Exception("ConnectionId and UserName must have a value");

            Users.Add(connectionId, userName);
        }

        public void RemoveUser()
        {

        }
    }
}

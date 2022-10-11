using Microsoft.AspNetCore.SignalR;

namespace ChatService.Hubs 
{ 
    public class MessageHub : Hub
    {
        public Task MessageAll(MessageHub message)
        {
            return Clients.All.SendAsync("MessageRecieved", message);
        }
    }
}

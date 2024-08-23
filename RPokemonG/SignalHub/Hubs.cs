using Microsoft.AspNetCore.SignalR;

namespace RPokemonG.SignalHub
{
    public class ChatHub : Hub //herda do signalR
    {
       public async Task NewMessage(long nome, string message) =>
       await Clients.All.SendAsync("messageReceived", nome, message);
    }
}

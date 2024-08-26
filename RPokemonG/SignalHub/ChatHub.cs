using Microsoft.AspNetCore.SignalR;

namespace RPokemonG.SignalHub
{
    public class ChatHub : Hub //herda do signalR
    {
        //recebe do front
       public async Task NewMessage(string nome, string message) =>
       Console.WriteLine($"{nome} says {message}");
    }


}

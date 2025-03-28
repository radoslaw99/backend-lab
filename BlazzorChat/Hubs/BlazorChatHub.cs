using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace BlazzorChat.Hubs;

public class BlazorChatHub : Hub
{
    public const string HubUrl = "/chat";

    public async Task Broadcast(string username, string message)
    {
        await Clients.All.SendAsync("Broadcast", username, message);
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"{Context.ConnectionId} connected");
        return base.OnConnectedAsync();
    }
    

    public override async Task OnDisconnectedAsync(Exception e)
    {
        Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
        await base.OnDisconnectedAsync(e);
    }
    public async Task Private(string from, string to, string message)
    {
        await Clients.Client(to).SendAsync("Private", from, message);
    }
}
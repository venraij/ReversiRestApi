using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApiMVC.Hubs
{
    public class GameHub : Hub
    {
        public async Task Zet(string user, int[] coords)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, coords);
        }
    }
}

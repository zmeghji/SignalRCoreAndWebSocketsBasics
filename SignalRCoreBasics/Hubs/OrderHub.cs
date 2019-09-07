using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRCoreBasics.Hubs
{
    public class OrderHub: Hub
    {
        public async Task GetUpdate()
        {
            for (int percentComplete = 0; percentComplete <= 100; percentComplete = percentComplete + 10)
            {
                Thread.Sleep(500);
                await Clients.Caller.SendAsync("OrderProgressUpdate", percentComplete.ToString());
            }
            await Clients.Caller.SendAsync("Finished");

        }
    }
}

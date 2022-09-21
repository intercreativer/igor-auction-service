using igor_auction_service.Entities;
using Microsoft.AspNetCore.SignalR;

namespace igor_auction_service.Hubs
{
    public class AuctionHub: Hub
    {
        public async Task NotifyNewBid(Bid auction)
        {
            await Clients.All.SendAsync("ReceiveNewBid", auction);
        }
    }
}

namespace igor_auction_service.Entities;

public class Auction
{
    public int AuctionId { get; set; }
    public string? AuctionName { get; set; }
    public int CurrentBid { get; set; }

}

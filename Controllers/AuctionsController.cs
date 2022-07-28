using igor_auction_service.Entities;
using Microsoft.AspNetCore.Mvc;

namespace igor_auction_service.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuctionsController : Controller
    {
        private static List<Auction> Auctions = new()
        {
            new Auction () {AuctionId = 1, AuctionName = "Red Bicycle", CurrentBid = 25},
            new Auction () {AuctionId = 2, AuctionName = "Blue T-Shirt", CurrentBid = 3},
            new Auction () {AuctionId = 3, AuctionName = "Soccer Ball", CurrentBid = 7},
            new Auction () {AuctionId = 4, AuctionName = "Baseball Bat", CurrentBid = 31},
            new Auction () {AuctionId = 5, AuctionName = "Fancy Snowboard", CurrentBid = 49},
        };

        [HttpGet("GetAuctions")]
        [ProducesResponseType(typeof(List<Auction>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetAuctions()
        {
            var result = Auctions;
            return result is not null ? Ok(result) : NoContent();
        }

        [HttpPost("PlaceBid")]
        [ProducesResponseType(typeof(List<Auction>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PlaceBid(int auctionId, int newBid)
        {
            var auction = Auctions.FirstOrDefault(x => x.AuctionId == auctionId);
            if (auction != null) auction.CurrentBid = newBid;
            return Ok();
        }
    }
}

namespace Auctify.Communication.Requests;

public class RequestAuctionJson
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }
}
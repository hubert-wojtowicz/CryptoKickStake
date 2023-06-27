namespace CryptoKickStake.Infrastructure.Database.Models;

public class Event
{
    public int EventId { get; set; }

    public DateTime StartAt { get; set; }

    public List<Party> Parties { get; set; }

    public int? ResultId { get; set; }

    public Result? Result { get; set; }
}
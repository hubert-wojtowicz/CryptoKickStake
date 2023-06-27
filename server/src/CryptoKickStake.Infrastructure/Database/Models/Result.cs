namespace CryptoKickStake.Infrastructure.Database.Models;

public class Result
{
    public int Id { get; set; }

    public Event Event { get; set; }

    public Party? Winner { get; set; }
}
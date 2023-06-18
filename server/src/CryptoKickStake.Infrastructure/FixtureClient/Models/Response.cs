using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Response
{
    [JsonProperty("fixture")]
    public Fixture Fixture { get; set; }

    [JsonProperty("league")]
    public League League { get; set; }

    [JsonProperty("teams")]
    public Teams Teams { get; set; }

    [JsonProperty("goals")]
    public Goals Goals { get; set; }

    [JsonProperty("score")]
    public Score Score { get; set; }
}
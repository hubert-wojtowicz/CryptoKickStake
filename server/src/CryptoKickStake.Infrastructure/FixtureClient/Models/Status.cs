using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Status
{
    [JsonProperty("long")]
    public string Long { get; set; }

    [JsonProperty("short")]
    public string Short { get; set; }

    [JsonProperty("elapsed")]
    public object Elapsed { get; set; }
}
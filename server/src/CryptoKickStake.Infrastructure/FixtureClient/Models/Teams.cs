using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Teams
{
    [JsonProperty("home")]
    public Home Home { get; set; }

    [JsonProperty("away")]
    public Away Away { get; set; }
}
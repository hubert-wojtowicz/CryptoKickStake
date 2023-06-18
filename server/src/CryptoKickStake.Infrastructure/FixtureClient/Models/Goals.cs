using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Goals
{
    [JsonProperty("home")]
    public object Home { get; set; }

    [JsonProperty("away")]
    public object Away { get; set; }
}
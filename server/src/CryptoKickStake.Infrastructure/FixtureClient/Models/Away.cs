using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Away
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("logo")]
    public string Logo { get; set; }

    [JsonProperty("winner")]
    public object Winner { get; set; }
}
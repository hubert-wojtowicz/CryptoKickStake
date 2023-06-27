using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class League
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("logo")]
    public string Logo { get; set; }

    [JsonProperty("flag")]
    public string Flag { get; set; }

    [JsonProperty("season")]
    public int Season { get; set; }

    [JsonProperty("round")]
    public string Round { get; set; }
}
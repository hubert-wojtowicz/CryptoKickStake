using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Parameters
{
    [JsonProperty("next")]
    public string Next { get; set; }
}
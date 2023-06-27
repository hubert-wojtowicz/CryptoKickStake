using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Score
{
    [JsonProperty("halftime")]
    public Halftime Halftime { get; set; }

    [JsonProperty("fulltime")]
    public Fulltime Fulltime { get; set; }

    [JsonProperty("extratime")]
    public Extratime Extratime { get; set; }

    [JsonProperty("penalty")]
    public Penalty Penalty { get; set; }
}
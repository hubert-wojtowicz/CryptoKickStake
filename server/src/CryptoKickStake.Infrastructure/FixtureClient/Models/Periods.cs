using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Periods
{
    [JsonProperty("first")]
    public object First { get; set; }

    [JsonProperty("second")]
    public object Second { get; set; }
}
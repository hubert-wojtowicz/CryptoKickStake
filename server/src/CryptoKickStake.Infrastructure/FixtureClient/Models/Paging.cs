using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient.Models;

public class Paging
{
    [JsonProperty("current")]
    public int Current { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }
}
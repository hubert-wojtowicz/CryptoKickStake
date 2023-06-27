using CryptoKickStake.Infrastructure.FixtureClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CryptoKickStake.Infrastructure.FixtureClient;

public class FixtureClient : IFixtureClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<FixtureClient> _logger;

    public FixtureClient(HttpClient httpClient, ILogger<FixtureClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Root> GetNextFixtures(int next)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/v3/fixtures?next={next}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Root>(content);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public async Task<Root> GetFixturesByIds(ICollection<string> fixturesIds)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/v3/fixtures?ids={string.Join('-', fixturesIds)}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Root>(content);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(GetFixturesByIds)} failed for {nameof(fixturesIds)}: '{string.Join(", ", fixturesIds)}'.");
            throw;
        }
    }
}
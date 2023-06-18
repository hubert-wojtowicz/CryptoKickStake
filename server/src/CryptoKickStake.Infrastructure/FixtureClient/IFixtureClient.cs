using CryptoKickStake.Infrastructure.FixtureClient.Models;

namespace CryptoKickStake.Infrastructure.FixtureClient;

public interface IFixtureClient
{
    Task<Root> GetNextFixtures(int next);

    Task<Root> GetFixturesByIds(ICollection<string> fixturesIds);
}
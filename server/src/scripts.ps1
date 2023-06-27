dotnet ef migrations add InitialCreate -p CryptoKickStake.Infrastructure -s KryptoKickStake.Api -o .\CryptoKickStake.Infrastructure\Database\Migrarions

dotnet ef database update -p CryptoKickStake.Infrastructure -s KryptoKickStake.Api
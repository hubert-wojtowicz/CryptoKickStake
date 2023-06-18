using CryptoKickStake.Infrastructure.FixtureClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IFixtureClient, FixtureClient>((serviceProvider, client) =>
{
    var config = serviceProvider.GetService<IConfiguration>();
    client.BaseAddress = new Uri(config["FixtureClient:HostBaseUrl"]);
    var xRapidApiKey = config["FixtureClient:XRapidApiKey"];
    var xRapidApiHost = config["FixtureClient:XRapidApiHost"];
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", xRapidApiKey);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", xRapidApiHost);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

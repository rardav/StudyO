using Identity.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new Config(builder.Configuration);

builder.Services.AddSingleton(config);

builder.Services
    .AddIdentityServer(options =>
    {
        options.IssuerUri = builder.Configuration.GetSection("ApiSettings").GetSection("IssuerUri").Value;
    })
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddTestUsers(Config.TestUsers)
    .AddDeveloperSigningCredential();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseIdentityServer();

app.MapControllers();

app.Run();

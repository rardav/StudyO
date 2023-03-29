using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, appConfiguration) =>
{
    var env = hostingContext.HostingEnvironment;

    appConfiguration.AddJsonFile($"ocelot.{env.EnvironmentName}.json", true, true);
});

builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

app.Run();

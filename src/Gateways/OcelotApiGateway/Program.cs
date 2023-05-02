using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, appConfiguration) =>
{
    var env = hostingContext.HostingEnvironment;

    appConfiguration.AddJsonFile($"ocelot.{env.EnvironmentName}.json", true, true);
});

builder.Services.AddOcelot();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseCors();
await app.UseOcelot();

app.Run();

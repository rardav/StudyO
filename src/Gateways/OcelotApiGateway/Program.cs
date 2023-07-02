using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, appConfiguration) =>
{
    var env = hostingContext.HostingEnvironment;

    appConfiguration.AddJsonFile($"ocelot.{env.EnvironmentName}.json", true, true);
});

builder.Services.AddControllers();
builder.Services.AddOcelot();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true));
});

var app = builder.Build();

app.UseCors("AllowOrigin");
await app.UseOcelot();

app.Run();

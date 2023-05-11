using Catalog.Infrastructure.Extensions;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = builder.Configuration.GetSection("ApiSettings").GetSection("IdentityUrl").Value; ;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "catalogClient"));
});

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper();
builder.Services.AddMongo();
builder.Services.AddRepositories();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseHttpsRedirection();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    IdentityModelEventSource.ShowPII = true;
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
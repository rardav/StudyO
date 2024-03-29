using Aggregator.Services;
using Aggregator.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<IReviewsService, ReviewsService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:ReviewsUrl"]);
});
builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:CatalogUrl"]);
}); builder.Services.AddHttpClient<IProgressService, ProgressService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:ProgressUrl"]);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyHeader()
                   .AllowAnyMethod().WithOrigins("http://localhost:4200"));
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

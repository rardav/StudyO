using AutoMapper;
using MongoDB.Driver;
using StudyO.Courses.API.Settings;
using StudyO.Courses.Infrastructure.Profiles;
using StudyO.Courses.Infrastructure.Repositories;
using StudyO.Courses.Infrastructure.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile<CourseProfile>();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//builder.Services.Configure<ServiceSettings>(builder.Configuration.GetSection("ServiceSettings"));
builder.Services.AddSingleton(serviceProvider =>
{
    var serviceSettings = builder.Configuration.GetSection("ServiceSettings").Get<ServiceSettings>();
    var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
    var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

    return mongoClient.GetDatabase(serviceSettings.ServiceName);
});

builder.Services.AddSingleton<ICoursesRepository, CoursesRepository>();

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

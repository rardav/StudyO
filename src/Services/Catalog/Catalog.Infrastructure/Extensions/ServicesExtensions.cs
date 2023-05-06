﻿using AutoMapper;
using Catalog.Infrastructure.Profiles;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Repositories.Contracts;
using Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();

                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
           
            services.AddSingleton<ICoursesRepository, CoursesRepository>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<CourseProfile>();
                config.AddProfile<ChapterProfile>();
                config.AddProfile<LessonProfile>();
                config.AddProfile<SectionProfile>();
                config.AddProfile<ReviewProfile>();
                config.AddProfile<FaqProfile>();
            });
            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}

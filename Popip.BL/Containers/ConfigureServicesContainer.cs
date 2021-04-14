using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Popip.Infrastructure.Dtos;
using Popip.Infrastructure.Validators;
using Popip.Model;
using Popip.Model.Repositories;

namespace Popip.Infrastructure.Containers
{
    public static class ConfigureServicesContainer
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PopipContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        public static void AddSwaggerOpenAPI(this IServiceCollection services)
        {
            //TODO: Preguntar si es una buena practicar utilizar el swagger desde Infrastructure

        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ItemDto>, ItemValidator>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IItemRepository, ItemRepository>();
        }

        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin()));
        }
    }
}

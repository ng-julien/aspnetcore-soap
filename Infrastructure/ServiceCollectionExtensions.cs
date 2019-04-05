namespace Microsoft.Extensions.DependencyInjection
{
    using System.Linq;

    using Infrastructure.Adapters.Roi;
    using Infrastructure.Repositories;
    using Infrastructure.Repositories.Entities;
    using Infrastructure.Specifications;
    using Infrastructure.Transforms;
    using Infrastructure.Transforms.Core;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    using Roi.Domain.UserAggregate;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserInformationSpecification, UserInformationSpecification>()
                    .AddScoped<ITranform<Person, UserInformation>, UserInformationTransform>()
                    .AddScoped<IUserInformationAdapter, UserInformationAdapter>()
                    .AddScoped(typeof(IReader<>), typeof(Reader<>))
                    .AddEntityFrameworkSqlServer()
                    .AddDbContext<IAdventureworks2017Context, Adventureworks2017Context>(
                        (serviceProvider, options) =>
                            {
                                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                                options.UseSqlServer(configuration.GetConnectionString("Adventureworks"))
                                       .UseInternalServiceProvider(serviceProvider);
                            })
                    .AddScoped<IQueryable<Person>>(
                        serviceProvider =>
                            {
                                var dbContext = serviceProvider.GetRequiredService<IAdventureworks2017Context>();
                                return dbContext.Set<Person>();
                            });
            return services;
        }
    }
}
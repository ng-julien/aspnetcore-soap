namespace Microsoft.Extensions.DependencyInjection
{
    using Roi.Application.Queries;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.ConfigureInfrastructure().AddScoped<IGetUserInformationByIdQuery, GetUserInformationByIdQuery>();
            return services;
        }
    }
}
namespace Roi.Client
{
    using System;
    using System.IO;
    using System.ServiceModel;

    using AF.Extensions.ServiceModel;
    using AF.Extensions.ServiceModel.Settings;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Roi.Client.Soap;

    internal class Startup
    {
        private readonly ApplicationContext applicationContext;

        public Startup(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public IConfiguration Configure()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(
                $"appsettings.{this.applicationContext.Environment}.json",
                optional: true,
                reloadOnChange: true);

            return builder.Build();
        }

        public IServiceProvider ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            var roiServiceConfiguration = configuration.GetSection("SOAP:RoiService")
                                                    .Get<ServiceConfiguration<BasicAuth>>();
            
            return services.AddWcfClient<IRoiServiceChannel>(roiServiceConfiguration)
                           .AddLogging(opt => { opt.AddConsole(); })
                           .BuildServiceProvider();
        }
    }
}
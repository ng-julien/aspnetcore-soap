namespace Roi.Client
{
    using System;
    using System.Threading.Tasks;

    using AF.Extensions.ServiceModel;

    using CommandLine;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Roi.Client.Soap;

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ApplicationContext>(args).WithParsed(
                context => MainAsync(context).GetAwaiter().GetResult());
            Console.ReadKey();
        }

        static async Task MainAsync(ApplicationContext context)
        {
            Startup startup = new Startup(context);
            var provider = startup.ConfigureService(new ServiceCollection(), startup.Configure());
            var clientWrapper = provider.GetRequiredService<IServiceClientWrapper<IRoiServiceChannel>>();
            var logger = provider.GetRequiredService<ILogger<Program>>();
            
            logger.LogInformation($"Environnement: {context.Environment}{Environment.NewLine}");
            logger.LogInformation($"Saisissez l'identifiant utilisateur:{Environment.NewLine}");
            while (int.TryParse(Console.ReadKey().KeyChar.ToString(), out var userId))
            {
                var response = await clientWrapper.Channel.GetUserByIdAsync(new GetUserByIdRequest(userId))
                                                  .ConfigureAwait(false);
                logger.LogInformation($"{Environment.NewLine}{response.GetUserByIdResult}");
            }

            Console.ReadKey();
        }
    }
}
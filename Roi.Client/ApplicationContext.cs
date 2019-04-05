namespace Roi.Client
{
    using CommandLine;

    internal class ApplicationContext
    {
        [Option(
            'e',
            "environment",
            Required = true,
            HelpText = "Set Environment execution (Development:0, Recette:1, PProd:2, Prod:3).")]
        public EnvironmentType Environment { get; set; }
    }
}
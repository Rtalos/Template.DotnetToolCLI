using Microsoft.Extensions.DependencyInjection;
using Template.DotnetToolCLI.Steps;

namespace Template.DotnetToolCLI
{
    internal static class StepRunner
    {
        public static async Task Run(IServiceProvider serviceProvider)
        {
            var steps = serviceProvider.GetServices<IStep>();

            foreach (var step in steps)
            {
                var result = await step.Run();

                if (!result.IsSuccessful)
                {
                    foreach (var error in result.Errors)
                        Console.Error.WriteLine(error);

                    Environment.Exit(1);
                }
            }
        }
    }
}

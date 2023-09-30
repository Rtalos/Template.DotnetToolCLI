using Microsoft.Extensions.DependencyInjection;
using Template.DotnetToolCLI.Infrastructure;
using Template.DotnetToolCLI.Steps;

namespace Template.DotnetToolCLI.Bootstrapping
{
    internal static class RegisterStepsExtension
    {
        internal static void RegisterSteps(this IServiceCollection services)
        {
            services.AddSingleton<DialogContext>();
            services.AddSingleton<IConsoleHandler, ConsoleHandler>();
            services.AddSingleton<IStep, CreateDialogContextStep>();
            services.AddSingleton<IStep, RunPowershellStep>();
        }
    }
}

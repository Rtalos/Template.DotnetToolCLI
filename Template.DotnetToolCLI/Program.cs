using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.DotnetToolCLI;
using Template.DotnetToolCLI.Bootstrapping;
using Template.DotnetToolCLI.Infrastructure;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.RegisterSteps();
    })
    .Build();

var stepFactory = host.Services.GetRequiredService<IStepFactory>();
await StepOrchestrator.Start(stepFactory, host.Services);
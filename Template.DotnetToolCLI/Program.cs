using Microsoft.Extensions.Hosting;
using Template.DotnetToolCLI;
using Template.DotnetToolCLI.Bootstrapping;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.RegisterSteps();
    })
    .Build();

await StepRunner.Run(host.Services);
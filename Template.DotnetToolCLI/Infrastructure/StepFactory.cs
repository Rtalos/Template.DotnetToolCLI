using Microsoft.Extensions.DependencyInjection;
using Template.DotnetToolCLI.Steps;

namespace Template.DotnetToolCLI.Infrastructure;

internal interface IStep
{
    public Task<StepResult> Run();
}
internal interface IStepFactory
{
    IStep GetStep<TStep>();
}

internal class StepFactory : IStepFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IServiceProviderIsService _serviceProviderIsService;

    public StepFactory(IServiceProvider serviceProvider, IServiceProviderIsService serviceProviderIsService)
    {
        _serviceProvider = serviceProvider;
        _serviceProviderIsService = serviceProviderIsService;
    }

    public IStep GetStep<TStep>()
    {
        if (!_serviceProviderIsService.IsService(typeof(TStep)))
            throw new NullReferenceException("Generator does not exist in DI");

        var generator = _serviceProvider.GetService(typeof(TStep)) as IStep;

        if (generator is null)
            throw new NullReferenceException("Generator does not implement IFileGenerator");

        return generator;
    }
}


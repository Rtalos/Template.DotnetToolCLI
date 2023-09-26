using Template.DotnetToolCLI.Infrastructure;

namespace Template.DotnetToolCLI.Steps;

internal abstract class Step : IStep
{
    internal abstract string Title { get; }
    internal abstract string CommandLine { get; }
    internal abstract bool Progressbar { get; }

    internal readonly IConsoleHandler _consoleHandler;

    public Step(IConsoleHandler consoleHandler)
    {
        _consoleHandler = consoleHandler;
    }

    public abstract Task<StepResult> Run();
}


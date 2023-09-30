namespace Template.DotnetToolCLI.Steps;

internal interface IStep
{
    public Task<StepResult> Run();
}


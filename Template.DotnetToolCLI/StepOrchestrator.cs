using Template.DotnetToolCLI.Infrastructure;
using Template.DotnetToolCLI.Steps;

namespace Template.DotnetToolCLI;

internal class StepOrchestrator
{
    public static async Task Start(IStepFactory stepFactory, IServiceProvider serviceProvider)
    {
        var createDialogContextStep = stepFactory.GetStep<CreateDialogContextStep>();
        var createDialogContextResult = await createDialogContextStep.Run();

        if (!createDialogContextResult.IsSuccessful)
            Environment.Exit(0);

        var runPowershellStep = stepFactory.GetStep<RunPowershellStep>();
        var runPowershellResult = await runPowershellStep.Run();

    }
}


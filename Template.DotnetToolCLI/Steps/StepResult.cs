using System.Management.Automation;

namespace Template.DotnetToolCLI.Steps;

internal class StepResult
{
    public bool IsSuccessful { get; private set; }
    public IEnumerable<string> ErrorMessages { get; private set; } = new List<string>();

    public StepResult(PowerShell ps)
    {
        IsSuccessful = !ps.HadErrors;

        if (!IsSuccessful)
        {
            ErrorMessages = ps.Streams.Error.Select(s => s.Exception.Message).ToList();
        }
    }

    public StepResult(bool result)
    {
        IsSuccessful = result;
    }
}


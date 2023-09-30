using System.Management.Automation;

namespace Template.DotnetToolCLI.Steps;

internal class StepResult
{
    public bool IsSuccessful { get; private set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
    public IEnumerable<string> Warnings { get; set; } = new List<string>();

    public StepResult(PowerShell ps)
    {
        IsSuccessful = !ps.HadErrors;

        if (!IsSuccessful)
        {
            Errors = ps.Streams.Error.Select(s => s.Exception.Message).ToList();
        }

        Warnings = ps.Streams.Warning.Select(s => s.Message).ToList();
    }

    public StepResult(bool result, IEnumerable<string>? errors = null, IEnumerable<string>? warnings = null)
    {
        IsSuccessful = result;

        Errors = errors ?? Enumerable.Empty<string>();
        Warnings = warnings ?? Enumerable.Empty<string>();
    }
}


using System.Management.Automation;
using Template.DotnetToolCLI.Infrastructure;

namespace Template.DotnetToolCLI.Steps
{
    internal class RunPowershellStep : Step
    {
        private readonly DialogContext _dialogContex;

        public RunPowershellStep(DialogContext dialogContex, IConsoleHandler consoleHandler) : base(consoleHandler)
        {
            _dialogContex = dialogContex;
        }

        internal override string Title => "Running powershell step...";

        internal override string CommandLine => $"Write-Host Name: {_dialogContex.Name}; Write-Host Age: {_dialogContex.Age}; Write-Host Your favorite genre: {_dialogContex.FavoriteGenre}";

        internal override bool Progressbar => throw new NotImplementedException();

        public override async Task<StepResult> Run()
        {
            _consoleHandler.WriteLineStepHighlight(Title);

            using (var ps = PowerShell.Create())
            {
                ps.AddStatement().AddScript(CommandLine);

                ps.Streams.Information.DataAdded += (sender, eventargs) =>
                {
                    if (sender is null)
                        return;

                    PSDataCollection<InformationRecord> infoRecords = (PSDataCollection<InformationRecord>)sender;
                    _consoleHandler.WriteLine(infoRecords[eventargs.Index].ToString());
                };

                var result = await ps.InvokeAsync();

                return new StepResult(ps);
            }
        }
    }
}

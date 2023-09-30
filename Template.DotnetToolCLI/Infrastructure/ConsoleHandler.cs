using System.Management.Automation;
using System.Text;

namespace Template.DotnetToolCLI.Infrastructure;

internal interface IConsoleHandler
{
    void Write(string text);
    void WriteLine(string text);
    void WriteLineStepHighlight(string text);
    void WriteLineSuccessfulStepHighlight(string text);
    void PrintOutput(ICollection<PSObject> result);
}

internal class ConsoleHandler : IConsoleHandler
{
    public void WriteLine(string text) => Console.WriteLine(text);
    public void WriteLineStepHighlight(string text)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    public void WriteLineSuccessfulStepHighlight(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    public void Write(string text) => Console.Write(text);

    public void PrintOutput(ICollection<PSObject> result)
    {
        var stringBuilder = new StringBuilder();

        foreach (var item in result)
        {
            stringBuilder.AppendLine(item.ToString());
        }

        Console.WriteLine(stringBuilder.ToString());
    }
}

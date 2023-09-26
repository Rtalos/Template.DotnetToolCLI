using System.Management.Automation;
using System.Text;

namespace Template.DotnetToolCLI.Infrastructure;

internal interface IConsoleHandler
{
    void ReadKey();
    string? ReadLine();
    void Write(string text);
    void WriteLine(string text);
    void WriteLineStepHighlight(string text);
    void WriteLineSuccessfulStepHighlight(string text);
    void WriteError(string message);
    void WriteError_Exit0(string message);
    void WriteError_Exit0<TException>(TException exception) where TException : Exception;
    void PrintOutput(ICollection<PSObject> result);
}

internal class ConsoleHandler : IConsoleHandler
{
    public void ReadKey() => Console.ReadKey();

    public string? ReadLine()
    {
        var input = Console.ReadLine();
        return input;
    }
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
    public void WriteError(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void WriteError_Exit0(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();

        WaitForExitKey();

        Environment.Exit(0);
    }

    public void WriteError_Exit0<TException>(TException exception) where TException : Exception
    {
        WriteError_Exit0(exception.Message);
    }

    public void PrintOutput(ICollection<PSObject> result)
    {
        var stringBuilder = new StringBuilder();

        foreach (var item in result)
        {
            stringBuilder.AppendLine(item.ToString());
        }

        Console.WriteLine(stringBuilder.ToString());
    }

    private void WaitForExitKey()
    {
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

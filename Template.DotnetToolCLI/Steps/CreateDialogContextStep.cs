using Sharprompt;
using Template.DotnetToolCLI.Infrastructure;

namespace Template.DotnetToolCLI.Steps
{
    internal class CreateDialogContextStep : Step
    {
        private readonly DialogContext _dialogContext;

        public CreateDialogContextStep(DialogContext dialogContext, IConsoleHandler consoleHandler) : base(consoleHandler)
        {
            _dialogContext = dialogContext;
        }

        internal override string Title => "Welcome to the my CLI!";

        internal override string CommandLine => throw new NotImplementedException();

        internal override bool Progressbar => throw new NotImplementedException();

        public override async Task<StepResult> Run()
        {
            _consoleHandler.WriteLine(Title);

            var name = Prompt.Input<string>("Your name", defaultValue: "", validators: new[] { Validators.Required(), Validators.MinLength(3) });
            var age = Prompt.Input<int>("Your age");
            var genre = Prompt.Select<FavoriteGenre>("Choose your favorite genre");

            var userConfirmation = Prompt.Confirm("Confirm that the information above is correct");
            
            _dialogContext.Name = name;
            _dialogContext.Age = age;
            _dialogContext.FavoriteGenre = genre;

            return new StepResult(userConfirmation);
        }
    }
}

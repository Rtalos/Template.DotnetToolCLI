namespace Template.DotnetToolCLI.Infrastructure;

internal class DialogContext
{
    public string Name { get; set; } = default!;
    public int Age { get; set; } = default!;
    public FavoriteGenre FavoriteGenre { get; set; }

}

internal enum FavoriteGenre
{
    Horror,
    Scifi,
    Action,
    Thriller
}

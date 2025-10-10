namespace Bolek.Infrastructure.Lolek;

internal sealed record class LolekOptions
{
    public readonly static string SECTION_NAME = "Lolek";
    public required Uri BaseAddress { get; init; }
    public string UserAgent { get; init; } = "Bolek";
    public required string AccessToken { get; init; }
}

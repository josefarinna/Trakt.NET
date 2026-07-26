using TraktNET;

namespace Trakt.NET.Examples.Modules.Shows;

internal static class SingleShowExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Get Single Show Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string clientID = Console.ReadLine() ?? "";

        var client = new TraktClient(clientID, "");

        Console.WriteLine("Enter the Trakt-Id or -Slug of the Show:");
        string? showIdOrSlug = Console.ReadLine();

        showIdOrSlug = string.IsNullOrEmpty(showIdOrSlug) ? "game-of-thrones" : showIdOrSlug;

        try
        {
            TraktResponse<TraktShow> showResponse = await client.Shows.GetShowAsync(showIdOrSlug);

            TraktShow show = showResponse.Content!;

            Console.WriteLine($"Title: {show.Title}");
            Console.WriteLine($"Year: {show.Year ?? 0}");

            TraktShowIDs? ids = show.IDs;

            if (ids != null)
            {
                Console.WriteLine($"Trakt-Id: {ids.Trakt}");
                Console.WriteLine($"Slug: {ids.Slug}");
                Console.WriteLine($"ImDB-Id: {ids.IMDB}");
                Console.WriteLine($"TmDB-Id: {ids.TMDB ?? 0}");
                Console.WriteLine($"TVDB-Id: {ids.TVDB ?? 0}");
            }
        }
        catch (TraktException ex)
        {
            Console.WriteLine("-------------- Trakt Exception --------------");
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine();
    }
}

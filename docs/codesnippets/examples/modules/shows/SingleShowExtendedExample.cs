using TraktNET;

namespace Trakt.NET.Examples.Modules.Shows;

internal static class SingleShowExtendedExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Get Single Show with Extended Info Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string clientID = Console.ReadLine() ?? "";

        var client = new TraktClient(clientID, "");

        Console.WriteLine("Enter the Trakt-Id or -Slug of the Show:");
        string? showIdOrSlug = Console.ReadLine();

        showIdOrSlug = string.IsNullOrEmpty(showIdOrSlug) ? "game-of-thrones" : showIdOrSlug;

        try
        {
            TraktResponse<TraktShow> showResponse = await client.Shows.GetShowAsync(showIdOrSlug, TraktExtendedInfo.Full | TraktExtendedInfo.Images);

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

            Console.WriteLine($"Overview: {show.Overview}");

            if (show.FirstAired.HasValue)
            {
                Console.WriteLine($"First Aired (UTC): {show.FirstAired.Value}");
            }

            TraktShowAirs? airs = show.Airs;

            if (airs != null)
            {
                Console.WriteLine($"Airs on: {airs.Day}");
                Console.WriteLine($"Airs at: {airs.Time}");
                Console.WriteLine($"Airs in: {airs.Timezone}");
            }

            Console.WriteLine($"Runtime: {show.Runtime ?? 0} Minutes");

            if (show.Genres != null)
            {
                Console.WriteLine($"Genres: {string.Join(", ", show.Genres)}");
            }

            Console.WriteLine($"Certification: {show.Certification}");
            Console.WriteLine($"Network: {show.Network}");

            if (show.Status != null)
            {
                Console.WriteLine($"Status: {show.Status}");
            }

            Console.WriteLine($"Rating: {show.Rating ?? 0.0f}");
            Console.WriteLine($"Votes: {show.Votes ?? 0}");
            Console.WriteLine($"Country Code: {show.Country}");
            Console.WriteLine($"Language Code: {show.Language}");

            if (show.AvailableTranslations != null)
            {
                Console.WriteLine($"Available Translation Languages: {string.Join(", ", show.AvailableTranslations)}");
            }

            if (show.Images != null)
            {
                Console.WriteLine($"Poster Image: {show.Images.Poster?.FirstOrDefault()}");
            }

            Console.WriteLine($"Trailer: {show.Trailer}");
            Console.WriteLine($"Homepage: {show.Homepage}");
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

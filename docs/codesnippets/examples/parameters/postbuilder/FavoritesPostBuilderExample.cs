using TraktNET;

namespace Trakt.NET.Examples.Parameters.Filter;

internal static class FavoritesPostBuilderExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Favorites Post Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string clientID = Console.ReadLine() ?? "";

        Console.WriteLine("Please enter your Trakt Client-Secret:");
        string clientSecret = Console.ReadLine() ?? "";

        var client = TraktClient.CreateForSandbox(clientID, clientSecret);

        try
        {
            var favoritesPost = new TraktSyncFavoritesPost
            {
                Movies = new List<TraktSyncFavoritesPostMovie>
                {
                    new() { IDs = new TraktMovieIDs { Trakt = 1 } }
                }
            };

            TraktResponse<TraktSyncFavoritesPostResponse> response = await client.Sync.AddFavoriteItemsAsync(favoritesPost);
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

using TraktNET;

namespace Trakt.NET.Examples.Modules.Shows;

internal static class TrendingShowsExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Get Trending Shows Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string clientID = Console.ReadLine() ?? "";

        var client = new TraktClient(clientID, "");

        try
        {
            TraktPagedResponse<TraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(TraktExtendedInfo.Full);

            foreach (TraktTrendingShow trendingShow in trendingShowsResponse)
            {
                Console.WriteLine($"Watchers: {trendingShow.Watchers}, Title: {trendingShow.Show?.Title}, Year: {trendingShow.Show?.Year}, Rating: {trendingShow.Show?.Rating}");
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

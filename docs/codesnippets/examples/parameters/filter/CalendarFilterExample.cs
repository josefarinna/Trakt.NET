using TraktNET;

namespace Trakt.NET.Examples.Parameters.Filter;

internal static class CalendarFilterExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Calendar Filter Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string clientID = Console.ReadLine() ?? "";

        var client = new TraktClient(clientID, "");

        var calendarFilter = new TraktFilter
        {
            Genres = new[] { "action", "drama" },
            Year = 2022
        };

        try
        {
            TraktListResponse<TraktCalendarShow> calendarShowsResponse = await client.Calendar.GetAllNewShowsAsync(
                DateTime.UtcNow,
                7,
                filter: calendarFilter,
                extendedInfo: TraktExtendedInfo.Full
            );

            TraktCalendarShow calendarShow = calendarShowsResponse.Content![0];

            Console.WriteLine($"Title: {calendarShow.Show?.Title}");
            Console.WriteLine($"Year: {calendarShow.Show?.Year}");
            Console.WriteLine($"Rating: {calendarShow.Show?.Rating}");
            Console.WriteLine($"First Aired: {calendarShow.FirstAired}");
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

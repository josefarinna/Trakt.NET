# Filter Builder

Many requests in **Trakt.NET** provide the possibility to filter results using [`TraktFilter`](xref:TraktNET.TraktFilter).

In **Trakt.NET** v2.0, `TraktFilter` is instantiated directly using property initializers.

## Example

In this example, a filter is used to retrieve a filtered list of trending movies.

```csharp
using TraktNET;

// Create a filter instance
var movieFilter = new TraktFilter
{
    Years = new Range<uint>(2020, 2024),         // Only look for movies released between 2020 and 2024
    Genres = new[] { "action", "fantasy" },     // Only look for action and fantasy movies
    Runtimes = new Range<uint>(90, 120),        // Each movie should have a runtime between 90 and 120 minutes
    Ratings = new Range<uint>(80, 95)           // Each movie should have a rating between 80% and 95%
};

// Get trending movies with the specified filter
TraktPagedResponse<TraktTrendingMovie> trendingMoviesResponse = await client.Movies.GetTrendingMoviesAsync(filter: movieFilter);
```

For a list of all filter properties, see the [references section](../references/requestparameters.md#filters).

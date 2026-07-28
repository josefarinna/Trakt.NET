# Post Objects

The [Trakt.tv API](https://docs.trakt.tv/) has many requests which require sending structured post objects (such as adding favorites, history, collection items, or notes).

In **Trakt.NET** v2.0, post objects are concrete record models (such as `TraktSyncFavoritesPost`, `TraktSyncHistoryPost`, etc.) and are instantiated directly using standard C# object and collection initializers.

## Usage Example

The following example demonstrates how to construct a `TraktSyncFavoritesPost` object and send it to Trakt.tv:

```csharp
using TraktNET;

// 1. Retrieve items from Trakt
TraktPagedResponse<TraktTrendingMovie> trendingMovies = await client.Movies.GetTrendingMoviesAsync();
TraktPagedResponse<TraktTrendingShow> trendingShows = await client.Shows.GetTrendingShowsAsync();

// 2. Create the post object
var favoritesPost = new TraktSyncFavoritesPost
{
    // Note: The Movies and Shows properties are typed as List<T>?, so .ToList() is used when projecting via LINQ .Select()
    Movies = trendingMovies.Select(movie => new TraktSyncFavoritesPostMovie
    {
        IDs = movie.IDs,
        Title = movie.Title,
        Year = movie.Year,
        Notes = "A new favorite movie!"
    }).ToList(),

    Shows = trendingShows.Select(show => new TraktSyncFavoritesPostShow
    {
        IDs = show.IDs,
        Title = show.Title,
        Year = show.Year,
        Notes = "A new favorite show!"
    }).ToList()
};

// 3. Send the request to Trakt.tv (requires valid OAuth authorization)
TraktResponse<TraktSyncFavoritesPostResponse> response = await client.Sync.AddFavoriteItemsAsync(favoritesPost);
```

### Direct Initialization Example

You can also construct post objects directly using collection initializers:

```csharp
using TraktNET;

var favoritesPost = new TraktSyncFavoritesPost
{
    Movies = new List<TraktSyncFavoritesPostMovie>
    {
        new()
        {
            IDs = new TraktMovieIDs { Trakt = 1 },
            Notes = "My favorite movie"
        }
    }
};

TraktResponse<TraktSyncFavoritesPostResponse> response = await client.Sync.AddFavoriteItemsAsync(favoritesPost);
```

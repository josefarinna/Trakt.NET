# Request Parameters

Many methods in the [modules](modules.md) accept [extended info](#extended-info) specifications, [filters](#filters) and / or pagination parameters.

## Extended Info

In **Trakt.NET** v2.0, [`TraktExtendedInfo`](xref:TraktNET.TraktExtendedInfo) is a bitwise `[Flags]` enumeration. You can combine multiple options using standard bitwise OR operations.

```csharp
using TraktNET;

// Request full information along with media image URLs
TraktExtendedInfo extendedInfo = TraktExtendedInfo.Full | TraktExtendedInfo.Images;

TraktResponse<TraktShow> showResponse = await client.Shows.GetShowAsync("the-last-of-us", extendedInfo);
```

### Supported Flags

| Flag | Value | Description |
|------|-------|-------------|
| `TraktExtendedInfo.None` | `0` | Default level of details (no additional data). |
| `TraktExtendedInfo.Metadata` | `1` | Additional collection metadata (media format, audio, resolution, etc.). |
| `TraktExtendedInfo.Full` | `2` | Complete metadata returned by the Trakt API. |
| `TraktExtendedInfo.Min` | `4` | Minimum information for media objects. |
| `TraktExtendedInfo.NoSeasons` | `8` | Exclude seasons information from show responses (`noseasons`). |
| `TraktExtendedInfo.Progress` | `16` | Progress information for watched/collected progress queries. |
| `TraktExtendedInfo.Episodes` | `32` | Include episode details for season queries. |
| `TraktExtendedInfo.GuestStars` | `64` | Include guest stars in cast/people queries. |
| `TraktExtendedInfo.Comments` | `128` | Include comment media object details. |
| `TraktExtendedInfo.VIP` | `256` | Include VIP information for user profiles (`VIP` / `Vip`). |
| `TraktExtendedInfo.Images` | `512` | Include media image URLs (posters, fanart, banners, logos, thumbs, clearart). |
| `TraktExtendedInfo.Subgenres` | `1024` | Include subgenres information. |
| `TraktExtendedInfo.Browsing` | `2048` | Include browsing information. |

---

## Filters

In **Trakt.NET** v2.0, [`TraktFilter`](xref:TraktNET.TraktFilter) is a strongly-typed class used to refine queries across Shows, Movies, Search, and Calendar methods.

```csharp
using TraktNET;

var movieFilter = new TraktFilter
{
    Years = new Range<uint>(2020, 2024),
    Genres = new[] { "action", "fantasy" },
    Runtimes = new Range<uint>(90, 120),
    Ratings = new Range<uint>(80, 95)
};

TraktPagedResponse<TraktTrendingMovie> trendingMovies = await client.Movies.GetTrendingMoviesAsync(filter: movieFilter);
```

### Supported Filter Properties

| Property | Type | Description |
|----------|------|-------------|
| `Query` | `string?` | Free-text search query string. |
| `Year` | `uint?` | Specific 4-digit release year. |
| `Years` | `Range<uint>?` | Range of 4-digit release years. |
| `Genres` | `string[]?` | Array of genre slugs. |
| `Subgenres` | `string[]?` | Array of subgenre slugs. |
| `Languages` | `string[]?` | Array of 2-letter language codes. |
| `Countries` | `string[]?` | Array of 2-letter country codes. |
| `Runtimes` | `Range<uint>?` | Runtime range in minutes. |
| `StudioIDs` | `uint[]?` | Array of Trakt studio IDs. |
| `Ratings` | `Range<uint>?` | Trakt rating range (0 to 100). |
| `Votes` | `Range<uint>?` | Trakt vote count range (0 to 100,000). |
| `TMDBRatings` | `Range<float>?` | TMDB rating range (0.0 to 10.0). |
| `TMDBVotes` | `Range<uint>?` | TMDB vote count range (0 to 100,000). |
| `IMDBRatings` | `Range<float>?` | IMDB rating range (0.0 to 10.0). |
| `IMDBVotes` | `Range<uint>?` | IMDB vote count range (0 to 3,000,000). |
| `RottenTomatoesMeters` | `Range<uint>?` | Rotten Tomatoes Tomatometer score range (0 to 100). |
| `RottenTomatoesUserMeters` | `Range<uint>?` | Rotten Tomatoes Audience score range (0 to 100). |
| `Metascores` | `Range<float>?` | Metacritic score range (0 to 100). |
| `Certifications` | `string[]?` | US content certifications (e.g. "pg-13", "r"). |
| `NetworkIDs` | `uint[]?` | Array of Trakt network IDs. |
| `Status` | `TraktShowStatus[]?` | Collection of show statuses. |
| `EpisodeTypes` | `TraktEpisodeType[]?` | Collection of episode types. |
| `IgnoreWatched` | `bool?` | Ignore watched items filter. |
| `IgnoreCollected` | `bool?` | Ignore collected items filter. |
| `IgnoreWatchlisted` | `bool?` | Ignore watchlisted items filter. |
| `StartDate` | `DateTime?` | Start date filter boundary. |
| `EndDate` | `DateTime?` | End date filter boundary. |

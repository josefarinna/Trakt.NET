#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktMostCollectedMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostCollectedMovie>))]
    [JsonSerializable(typeof(TraktMostFavoritedMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostFavoritedMovie>))]
    [JsonSerializable(typeof(TraktMostPlayedMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostPlayedMovie>))]
    [JsonSerializable(typeof(TraktMostPWCMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostPWCMovie>))]
    [JsonSerializable(typeof(TraktMostWatchedMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostWatchedMovie>))]
    [JsonSerializable(typeof(TraktMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMovie>))]
    [JsonSerializable(typeof(TraktMovieIds))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMovieIds>))]
    [JsonSerializable(typeof(TraktMovieMinimal))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMovieMinimal>))]
    [JsonSerializable(typeof(TraktTrendingMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktTrendingMovie>))]
    public sealed partial class MoviesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

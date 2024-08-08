#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMovie>))]
    [JsonSerializable(typeof(TraktMovieIds))]
    [JsonSerializable(typeof(TraktMovieMinimal))]
    [JsonSerializable(typeof(TraktTrendingMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktTrendingMovie>))]
    public sealed partial class MoviesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

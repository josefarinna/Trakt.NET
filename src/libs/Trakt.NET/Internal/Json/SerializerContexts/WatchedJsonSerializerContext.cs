#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktWatchedMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktWatchedMovie>))]
    [JsonSerializable(typeof(TraktWatchedShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktWatchedShow>))]
    [JsonSerializable(typeof(TraktWatchedEpisode))]
    [JsonSerializable(typeof(IReadOnlyList<TraktWatchedEpisode>))]
    [JsonSerializable(typeof(TraktWatchedShowEpisode))]
    [JsonSerializable(typeof(IReadOnlyList<TraktWatchedShowEpisode>))]
    [JsonSerializable(typeof(TraktWatchedShowSeason))]
    [JsonSerializable(typeof(IReadOnlyList<TraktWatchedShowSeason>))]
    public sealed partial class WatchedJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

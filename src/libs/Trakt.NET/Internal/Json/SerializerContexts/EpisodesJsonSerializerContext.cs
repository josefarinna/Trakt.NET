#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktEpisode))]
    [JsonSerializable(typeof(IReadOnlyList<TraktEpisode>))]
    [JsonSerializable(typeof(TraktEpisodeCollectionProgress))]
    [JsonSerializable(typeof(IReadOnlyList<TraktEpisodeCollectionProgress>))]
    [JsonSerializable(typeof(TraktEpisodeIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktEpisodeIDs>))]
    [JsonSerializable(typeof(TraktEpisodeImages))]
    [JsonSerializable(typeof(IReadOnlyList<TraktEpisodeImages>))]
    [JsonSerializable(typeof(TraktEpisodeMinimal))]
    [JsonSerializable(typeof(IReadOnlyList<TraktEpisodeMinimal>))]
    [JsonSerializable(typeof(TraktEpisodeTranslation))]
    [JsonSerializable(typeof(IReadOnlyList<TraktEpisodeTranslation>))]
    [JsonSerializable(typeof(TraktEpisodeWatchedProgress))]
    [JsonSerializable(typeof(IReadOnlyList<TraktEpisodeWatchedProgress>))]
    public sealed partial class EpisodesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

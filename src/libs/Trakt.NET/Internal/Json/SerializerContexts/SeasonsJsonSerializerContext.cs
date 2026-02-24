#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktSeason))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeason>))]
    [JsonSerializable(typeof(TraktSeasonCollectionProgress))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeasonCollectionProgress>))]
    [JsonSerializable(typeof(TraktSeasonIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeasonIDs>))]
    [JsonSerializable(typeof(TraktSeasonImages))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeasonImages>))]
    [JsonSerializable(typeof(TraktSeasonMinimal))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeasonMinimal>))]
    [JsonSerializable(typeof(TraktSeasonWatchedProgress))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeasonWatchedProgress>))]
    public sealed partial class SeasonsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

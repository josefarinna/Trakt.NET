#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktMostAnticipatedShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostAnticipatedShow>))]
    [JsonSerializable(typeof(TraktMostCollectedShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostCollectedShow>))]
    [JsonSerializable(typeof(TraktMostFavoritedShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostFavoritedShow>))]
    [JsonSerializable(typeof(TraktMostPlayedShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostPlayedShow>))]
    [JsonSerializable(typeof(TraktMostPWCShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostPWCShow>))]
    [JsonSerializable(typeof(TraktMostWatchedShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktMostWatchedShow>))]
    [JsonSerializable(typeof(TraktShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShow>))]
    [JsonSerializable(typeof(TraktShowAirs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowAirs>))]
    [JsonSerializable(typeof(TraktShowAlias))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowAlias>))]
    [JsonSerializable(typeof(TraktShowCertification))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowCertification>))]
    [JsonSerializable(typeof(TraktShowCollectionProgress))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowCollectionProgress>))]
    [JsonSerializable(typeof(TraktShowIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowIDs>))]
    [JsonSerializable(typeof(TraktShowImages))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowImages>))]
    [JsonSerializable(typeof(TraktShowMinimal))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowMinimal>))]
    [JsonSerializable(typeof(TraktShowStatistics))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowStatistics>))]
    [JsonSerializable(typeof(TraktShowTranslation))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowTranslation>))]
    [JsonSerializable(typeof(TraktShowWatchedProgress))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowWatchedProgress>))]
    [JsonSerializable(typeof(TraktShowResetWatchedProgress))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowResetWatchedProgress>))]
    [JsonSerializable(typeof(TraktTrendingShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktTrendingShow>))]
    [JsonSerializable(typeof(TraktUpdatedShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktUpdatedShow>))]
    public sealed partial class ShowsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

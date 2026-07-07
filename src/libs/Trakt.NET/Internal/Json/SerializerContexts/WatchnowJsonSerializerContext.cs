#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktWatchnowSource))]
    [JsonSerializable(typeof(IReadOnlyList<TraktWatchnowSource>))]
    [JsonSerializable(typeof(Dictionary<string, IReadOnlyList<TraktWatchnowSource>>))]
    [JsonSerializable(typeof(IReadOnlyList<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>))]
    [JsonSerializable(typeof(TraktWatchnowSourceImages))]
    [JsonSerializable(typeof(TraktWatchnowSources))]
    [JsonSerializable(typeof(Dictionary<string, TraktWatchnowSources>))]
    [JsonSerializable(typeof(Dictionary<string, string>))]
    [JsonSerializable(typeof(TraktStreamingRank))]
    [JsonSerializable(typeof(TraktWatchnowOffer))]
    [JsonSerializable(typeof(IReadOnlyList<TraktWatchnowOffer>))]
    [JsonSerializable(typeof(TraktWatchnowPrices))]
    [JsonSerializable(typeof(TraktWatchnowWebos))]
    [JsonSerializable(typeof(TraktWatchnowWebosParams))]
    public sealed partial class WatchnowJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

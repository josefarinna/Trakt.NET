#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktWatchlistItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktWatchlistItem>))]
    public sealed partial class WatchlistJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktTrendingMedia))]
    [JsonSerializable(typeof(IReadOnlyList<TraktTrendingMedia>))]
    [JsonSerializable(typeof(TraktAnticipatedMedia))]
    [JsonSerializable(typeof(IReadOnlyList<TraktAnticipatedMedia>))]
    [JsonSerializable(typeof(TraktPopularMedia))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPopularMedia>))]
    public sealed partial class MediaJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

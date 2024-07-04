#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktEpisode))]
    [JsonSerializable(typeof(TraktEpisodeIds))]
    [JsonSerializable(typeof(TraktEpisodeMinimal))]
    [JsonSerializable(typeof(TraktEpisodeTranslation))]
    public sealed partial class EpisodesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

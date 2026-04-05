#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktFavoritedBy))]
    [JsonSerializable(typeof(IReadOnlyList<TraktFavoritedBy>))]
    [JsonSerializable(typeof(TraktRecommendedMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktRecommendedMovie>))]
    [JsonSerializable(typeof(TraktRecommendedShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktRecommendedShow>))]
    public sealed partial class RecommendationsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

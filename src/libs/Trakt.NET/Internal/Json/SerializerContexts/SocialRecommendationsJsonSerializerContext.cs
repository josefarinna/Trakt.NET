#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktSocialMovieRecommendation))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSocialMovieRecommendation>))]
    [JsonSerializable(typeof(TraktSocialShowRecommendation))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSocialShowRecommendation>))]
    public sealed partial class SocialRecommendationsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

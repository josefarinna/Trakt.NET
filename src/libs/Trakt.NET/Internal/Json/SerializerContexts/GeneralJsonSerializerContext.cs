#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(uint))]
    [JsonSerializable(typeof(IReadOnlyList<uint>))]
    [JsonSerializable(typeof(TraktCastAndCrew))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCastMember>))]
    [JsonSerializable(typeof(TraktCastMember))]
    [JsonSerializable(typeof(TraktColors))]
    [JsonSerializable(typeof(TraktCrew))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCrewMember>))]
    [JsonSerializable(typeof(TraktCrewMember))]
    [JsonSerializable(typeof(TraktMetadata))]
    [JsonSerializable(typeof(TraktRateLimitInfo))]
    [JsonSerializable(typeof(TraktRating))]
    [JsonSerializable(typeof(IReadOnlyList<TraktStudio>))]
    [JsonSerializable(typeof(TraktSentimentItem))]
    [JsonSerializable(typeof(TraktSentiments))]
    [JsonSerializable(typeof(TraktStudio))]
    [JsonSerializable(typeof(TraktStudioIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktVideo>))]
    [JsonSerializable(typeof(TraktVideo))]
    [JsonSerializable(typeof(TraktReportPost))]
    public sealed partial class GeneralJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktPostResponseNotFoundEpisode))]
    [JsonSerializable(typeof(TraktPostResponseNotFoundMovie))]
    [JsonSerializable(typeof(TraktPostResponseNotFoundPerson))]
    [JsonSerializable(typeof(TraktPostResponseNotFoundSeason))]
    [JsonSerializable(typeof(TraktPostResponseNotFoundShow))]
    public sealed partial class ResponsesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

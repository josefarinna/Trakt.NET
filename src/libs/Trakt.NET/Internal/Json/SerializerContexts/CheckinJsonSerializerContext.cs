#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktCheckinErrorResponse))]
    [JsonSerializable(typeof(TraktEpisodeCheckin))]
    [JsonSerializable(typeof(TraktEpisodeCheckinResponse))]
    [JsonSerializable(typeof(TraktMovieCheckin))]
    [JsonSerializable(typeof(TraktMovieCheckinResponse))]
    public sealed partial class CheckinJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

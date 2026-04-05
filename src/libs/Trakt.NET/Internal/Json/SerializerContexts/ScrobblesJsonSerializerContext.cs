#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktEpisodeScrobblePost))]
    [JsonSerializable(typeof(TraktEpisodeScrobblePostResponse))]
    [JsonSerializable(typeof(TraktMovieScrobblePost))]
    [JsonSerializable(typeof(TraktMovieScrobblePostResponse))]
    [JsonSerializable(typeof(TraktScrobblePost))]
    [JsonSerializable(typeof(TraktScrobblePostResponse))]
    public sealed partial class ScrobblesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktMovie))]
    [JsonSerializable(typeof(TraktMovieIds))]
    [JsonSerializable(typeof(TraktMovieMinimal))]
    public sealed partial class MoviesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

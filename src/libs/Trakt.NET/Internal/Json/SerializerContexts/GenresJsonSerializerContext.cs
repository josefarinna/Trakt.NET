#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktGenre))]
    [JsonSerializable(typeof(IReadOnlyList<TraktGenre>))]
    [JsonSerializable(typeof(TraktSubgenre))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSubgenre>))]
    public sealed partial class GenresJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

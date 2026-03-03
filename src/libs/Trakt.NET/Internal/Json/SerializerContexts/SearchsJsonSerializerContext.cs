#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktSearchResult))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSearchResult>))]
    public sealed partial class SearchsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

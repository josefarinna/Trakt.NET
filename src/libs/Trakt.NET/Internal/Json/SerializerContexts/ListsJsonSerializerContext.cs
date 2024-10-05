#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktList))]
    [JsonSerializable(typeof(IReadOnlyList<TraktList>))]
    [JsonSerializable(typeof(TraktListIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktListIDs>))]
    public sealed partial class ListsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

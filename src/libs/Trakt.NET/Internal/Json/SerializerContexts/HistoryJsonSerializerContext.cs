#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktHistoryItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktHistoryItem>))]
    public sealed partial class HistoryJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

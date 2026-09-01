#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktFilterOperator))]
    [JsonSerializable(typeof(TraktSmartList))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSmartList>))]
    [JsonSerializable(typeof(TraktSmartListImages))]
    [JsonSerializable(typeof(TraktSmartListFilters))]
    [JsonSerializable(typeof(TraktSmartListPost))]
    [JsonSerializable(typeof(TraktSmartListPostResponse))]
    public sealed partial class SmartListsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktNetwork))]
    [JsonSerializable(typeof(IReadOnlyList<TraktNetwork>))]
    [JsonSerializable(typeof(TraktNetworkIDs))]
    public sealed partial class NetworksJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

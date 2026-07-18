#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktYounifyConnection))]
    [JsonSerializable(typeof(IReadOnlyList<TraktYounifyConnection>))]
    [JsonSerializable(typeof(TraktYounifyConnectionImages))]
    [JsonSerializable(typeof(TraktYounifyConnectPost))]
    [JsonSerializable(typeof(TraktYounifyConnectResponse))]
    public sealed partial class YounifyJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

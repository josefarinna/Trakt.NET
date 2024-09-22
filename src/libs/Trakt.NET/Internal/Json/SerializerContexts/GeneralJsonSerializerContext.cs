#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(uint))]
    [JsonSerializable(typeof(IReadOnlyList<uint>))]
    [JsonSerializable(typeof(TraktRateLimitInfo))]
    public sealed partial class GeneralJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

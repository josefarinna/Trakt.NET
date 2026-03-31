#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktRatingsItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktRatingsItem>))]
    public sealed partial class RatingsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

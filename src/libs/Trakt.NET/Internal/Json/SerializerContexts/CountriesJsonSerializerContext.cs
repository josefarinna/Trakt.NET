#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktCountry))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCountry>))]
    public sealed partial class CountriesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

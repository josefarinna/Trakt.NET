#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktPerson))]
    [JsonSerializable(typeof(TraktPersonIDs))]
    [JsonSerializable(typeof(TraktPersonMinimal))]
    [JsonSerializable(typeof(TraktPersonSocialIDs))]
    public sealed partial class PeopleJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

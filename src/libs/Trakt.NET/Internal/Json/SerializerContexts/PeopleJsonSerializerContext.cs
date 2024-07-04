#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktPerson))]
    [JsonSerializable(typeof(TraktPersonIds))]
    [JsonSerializable(typeof(TraktPersonMinimal))]
    [JsonSerializable(typeof(TraktPersonSocialIds))]
    public sealed partial class PeopleJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

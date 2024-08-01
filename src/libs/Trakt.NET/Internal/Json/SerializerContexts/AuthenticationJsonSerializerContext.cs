#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktAuthorization))]
    [JsonSerializable(typeof(TraktDevice))]
    public sealed partial class AuthenticationJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

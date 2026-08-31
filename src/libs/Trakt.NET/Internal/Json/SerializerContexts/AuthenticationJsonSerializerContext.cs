#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktAuthorization))]
    [JsonSerializable(typeof(TraktAuthorizationPollPost))]
    [JsonSerializable(typeof(TraktAuthorizationPost))]
    [JsonSerializable(typeof(TraktAuthorizationRefreshPost))]
    [JsonSerializable(typeof(TraktAuthorizationRevokePost))]
    [JsonSerializable(typeof(TraktDevice))]
    [JsonSerializable(typeof(TraktDevicePost))]
    public sealed partial class AuthenticationJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

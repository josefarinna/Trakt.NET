#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktUser))]
    [JsonSerializable(typeof(TraktUserIds))]
    [JsonSerializable(typeof(TraktUserImages))]
    [JsonSerializable(typeof(TraktUserImagesAvatar))]
    [JsonSerializable(typeof(TraktUserMinimal))]
    public sealed partial class UsersJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

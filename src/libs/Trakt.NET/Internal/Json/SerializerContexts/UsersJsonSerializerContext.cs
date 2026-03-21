#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktUser))]
    [JsonSerializable(typeof(IReadOnlyList<TraktUser>))]
    [JsonSerializable(typeof(TraktUserComment))]
    [JsonSerializable(typeof(IReadOnlyList<TraktUserComment>))]
    [JsonSerializable(typeof(TraktUserIDs))]
    [JsonSerializable(typeof(TraktUserImages))]
    [JsonSerializable(typeof(TraktUserImagesAvatar))]
    [JsonSerializable(typeof(TraktUserMinimal))]
    public sealed partial class UsersJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

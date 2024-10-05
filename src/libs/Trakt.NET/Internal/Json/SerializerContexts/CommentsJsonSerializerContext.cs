#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktComment))]
    [JsonSerializable(typeof(IReadOnlyList<TraktComment>))]
    [JsonSerializable(typeof(TraktCommentUserStats))]
    public sealed partial class CommentsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

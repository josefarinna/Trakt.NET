#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktComment))]
    [JsonSerializable(typeof(IReadOnlyList<TraktComment>))]
    [JsonSerializable(typeof(TraktCommentUserStats))]
    [JsonSerializable(typeof(TraktCommentItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCommentItem>))]
    [JsonSerializable(typeof(TraktCommentLike))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCommentLike>))]
    [JsonSerializable(typeof(TraktUserComment))]
    [JsonSerializable(typeof(IReadOnlyList<TraktUserComment>))]
    [JsonSerializable(typeof(TraktCommentPostResponse))]
    [JsonSerializable(typeof(TraktCommentReaction))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCommentReaction>))]
    [JsonSerializable(typeof(TraktCommentUserReaction))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCommentUserReaction>))]
    [JsonSerializable(typeof(TraktCommentReactionSummary))]
    public sealed partial class CommentsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

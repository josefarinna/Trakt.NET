namespace TraktNET
{
    // -------------------------------------------------------
    // GET Requests
    // -------------------------------------------------------

    [TraktGetRequest("comments/{id!!}", SupportsExtendedInfo = true)]
    internal sealed partial class CommentSummaryGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    [TraktGetRequest("comments/{id!!}/replies", SupportsExtendedInfo = true, SupportsPagination = true,
        OAuthRequirement = TraktOAuthRequirement.Optional)]
    internal sealed partial class CommentRepliesGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    [TraktGetRequest("comments/{id!!}/item", SupportsExtendedInfo = true)]
    internal sealed partial class CommentItemGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    [TraktGetRequest("comments/{id!!}/likes", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class CommentLikesGetRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    [TraktGetRequest("comments/trending", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class CommentsTrendingGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentType? CommentType { get; set; }

        [TraktRequestParameter]
        internal TraktCommentObjectType? Type { get; set; }

        [TraktRequestQuery("include_replies")]
        internal bool? IncludeReplies { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    [TraktGetRequest("comments/recent", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class CommentsRecentGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentType? CommentType { get; set; }

        [TraktRequestParameter]
        internal TraktCommentObjectType? Type { get; set; }

        [TraktRequestQuery("include_replies")]
        internal bool? IncludeReplies { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    [TraktGetRequest("comments/updates", SupportsExtendedInfo = true, SupportsPagination = true)]
    internal sealed partial class CommentsUpdatesGetRequest
    {
        [TraktRequestParameter]
        internal TraktCommentType? CommentType { get; set; }

        [TraktRequestParameter]
        internal TraktCommentObjectType? Type { get; set; }

        [TraktRequestQuery("include_replies")]
        internal bool? IncludeReplies { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    // -------------------------------------------------------
    // POST Requests
    // -------------------------------------------------------

    [TraktPostRequest("comments", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CommentPostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;

        [TraktRequestPayload]
        internal required TraktCommentPost TraktCommentPost { get; set; }
    }

    [TraktPostRequest("comments/{id!!}/replies", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CommentReplyPostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;

        [TraktRequestPayload]
        internal required TraktCommentReplyPost TraktCommentReplyPost { get; set; }
    }

    [TraktPostRequest("comments/{id!!}/like", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CommentLikePostRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    [TraktPostRequest("comments/{id!!}/report", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CommentReportPostRequest
    {
        [TraktRequestPayload]
        internal required TraktReportPost TraktReportPost { get; set; }

        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    // -------------------------------------------------------
    // PUT Requests
    // -------------------------------------------------------

    [TraktPutRequest("comments/{id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CommentUpdatePutRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;

        [TraktRequestPayload]
        internal required TraktCommentUpdatePost TraktCommentUpdatePost { get; set; }
    }

    // -------------------------------------------------------
    // DELETE Requests
    // -------------------------------------------------------

    [TraktDeleteRequest("comments/{id!!}", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CommentDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }

    [TraktDeleteRequest("comments/{id!!}/like", OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class CommentUnlikeDeleteRequest
    {
        internal override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comment;
    }
}

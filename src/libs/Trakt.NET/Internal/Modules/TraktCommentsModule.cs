using System.Net.Http.Json;

namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to comments.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/comments">"Trakt API Documentation - Comments"</a> section.
    /// </summary>
    public sealed partial class TraktCommentsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktComment>> GetCommentImplAsync(uint commentId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new CommentSummaryGetRequest
            {
                Id = commentId.ToInvariantCultureString(),
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktComment>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCommentItem>> GetCommentItemImplAsync(uint commentId, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new CommentItemGetRequest
            {
                Id = commentId.ToInvariantCultureString(),
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCommentItem>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktCommentLike>> GetCommentLikesImplAsync(uint commentId, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new CommentLikesGetRequest
            {
                Id = commentId.ToInvariantCultureString(),
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktCommentLike>(_context, request, (page, limit)
                => new CommentLikesGetRequest
                {
                    Id = commentId.ToInvariantCultureString(),
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktUserComment>> GetRecentlyUpdatedCommentsImplAsync(TraktCommentType? commentType = null,
            TraktCommentObjectType? type = null, bool? includeReplies = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new CommentsUpdatesGetRequest
            {
                CommentType = commentType,
                Type = type,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktUserComment>(_context, request, (page, limit)
                => new CommentsUpdatesGetRequest
                {
                    CommentType = commentType,
                    Type = type,
                    IncludeReplies = includeReplies,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktUserComment>> GetRecentlyCreatedCommentsImplAsync(TraktCommentType? commentType = null,
            TraktCommentObjectType? type = null, bool? includeReplies = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new CommentsRecentGetRequest
            {
                CommentType = commentType,
                Type = type,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktUserComment>(_context, request, (page, limit)
                => new CommentsRecentGetRequest
                {
                    CommentType = commentType,
                    Type = type,
                    IncludeReplies = includeReplies,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktUserComment>> GetTrendingCommentsImplAsync(TraktCommentType? commentType = null,
            TraktCommentObjectType? type = null, bool? includeReplies = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new CommentsTrendingGetRequest
            {
                CommentType = commentType,
                Type = type,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktUserComment>(_context, request, (page, limit)
                => new CommentsTrendingGetRequest
                {
                    CommentType = commentType,
                    Type = type,
                    IncludeReplies = includeReplies,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktResponse<TraktCommentPostResponse>> PostMovieCommentImplAsync(TraktMovieCommentPost movieCommentPost,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(movieCommentPost);
            movieCommentPost.Validate();

            var request = new CommentPostRequest
            {
                Content = JsonContent.Create(movieCommentPost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCommentPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCommentPostResponse>> PostShowCommentImplAsync(TraktShowCommentPost showCommentPost,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(showCommentPost);
            showCommentPost.Validate();

            var request = new CommentPostRequest
            {
                Content = JsonContent.Create(showCommentPost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCommentPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCommentPostResponse>> PostSeasonCommentImplAsync(TraktSeasonCommentPost seasonCommentPost,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(seasonCommentPost);
            seasonCommentPost.Validate();

            var request = new CommentPostRequest
            {
                Content = JsonContent.Create(seasonCommentPost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCommentPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCommentPostResponse>> PostEpisodeCommentImplAsync(TraktEpisodeCommentPost episodeCommentPost,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(episodeCommentPost);
            episodeCommentPost.Validate();

            var request = new CommentPostRequest
            {
                Content = JsonContent.Create(episodeCommentPost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCommentPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCommentPostResponse>> PostListCommentImplAsync(TraktListCommentPost listCommentPost,
            CancellationToken cancellationToken = default)
        {
            ArgumentValidator.ThrowIfNull(listCommentPost);
            listCommentPost.Validate();

            var request = new CommentPostRequest
            {
                Content = JsonContent.Create(listCommentPost)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCommentPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCommentPostResponse>> UpdateCommentImplAsync(uint commentId, string comment, bool? containsSpoiler = null,
            CancellationToken cancellationToken = default)
        {
            var content = new TraktCommentUpdatePost
            {
                Comment = comment,
                Spoiler = containsSpoiler
            };
            content.Validate();

            var request = new CommentUpdatePutRequest
            {
                Id = commentId.ToInvariantCultureString(),
                Content = JsonContent.Create(content)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCommentPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse<TraktCommentPostResponse>> PostCommentReplyImplAsync(uint commentId, string comment, bool? containsSpoiler = null,
            CancellationToken cancellationToken = default)
        {
            var content = new TraktCommentReplyPost
            {
                Comment = comment,
                Spoiler = containsSpoiler
            };
            content.Validate();

            var request = new CommentReplyPostRequest
            {
                Id = commentId.ToInvariantCultureString(),
                Content = JsonContent.Create(content)
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktCommentPostResponse>(_context, request, cancellationToken);
        }

        private Task<TraktResponse> DeleteCommentImplAsync(uint commentId, CancellationToken cancellationToken = default)
        {
            var request = new CommentDeleteRequest
            {
                Id = commentId.ToInvariantCultureString()
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse> LikeCommentImplAsync(uint commentId, CancellationToken cancellationToken = default)
        {
            var request = new CommentLikePostRequest
            {
                Id = commentId.ToInvariantCultureString()
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse> UnlikeCommentImplAsync(uint commentId, CancellationToken cancellationToken = default)
        {
            var request = new CommentUnlikeDeleteRequest
            {
                Id = commentId.ToInvariantCultureString()
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktComment>> GetCommentRepliesImplAsync(uint commentId, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new CommentRepliesGetRequest
            {
                Id = commentId.ToInvariantCultureString(),
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktComment>(_context, request, (page, limit)
                => new CommentRepliesGetRequest
                {
                    Id = commentId.ToInvariantCultureString(),
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                }, cancellationToken);
        }
    }
}

using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed partial class GetRecentlyCreatedCommentsTests
    {
        private const string GetRecentlyCreatedCommentsUri = "comments/recent";

        [Theory]
        [InlineData(null, null, null, null, GetRecentlyCreatedCommentsUri, "Comments\\comments.json")]
        [InlineData(TraktCommentType.All, null, null, null, $"{GetRecentlyCreatedCommentsUri}/all", "Comments\\comments.json")]
        [InlineData(TraktCommentType.Review, null, null, null, "comments/recent/reviews", "Comments\\comments.json")]
        [InlineData(TraktCommentType.Shout, null, null, null, "comments/recent/shouts", "Comments\\comments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetRecentlyCreatedCommentsUri}?extended=full", "Comments\\comments.json")]
        [InlineData(null, null, 1U, null, $"{GetRecentlyCreatedCommentsUri}?page=1", "Comments\\comments.json")]
        [InlineData(null, null, null, 10U, $"{GetRecentlyCreatedCommentsUri}?limit=10", "Comments\\comments.json")]
        [InlineData(TraktCommentType.Review, TraktExtendedInfo.Full, 1U, 10U, "comments/recent/reviews?extended=full&page=1&limit=10", "Comments\\comments.json")]
        public async Task TestGetRecentlyCreatedComments(TraktCommentType? commentType, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktUserComment> response = await client.Comments.GetRecentlyCreatedCommentsAsync(commentType, null, null, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);

            List<TraktUserComment> comments = [.. response.Content];

            // Test first comment (Movie)
            comments[0].Type.ShouldBe(TraktCommentObjectType.Movie);
            comments[0].Movie.ShouldNotBeNull();
            comments[0].Movie!.Title.ShouldBe("Batman Begins");
            comments[0].Comment.ShouldNotBeNull();
            comments[0].Comment!.ID.ShouldBe(267U);
            comments[0].Comment!.Comment.ShouldBe("Great kickoff to a new Batman trilogy!");

            // Test second comment (Show)
            comments[1].Type.ShouldBe(TraktCommentObjectType.Show);
            comments[1].Show.ShouldNotBeNull();
            comments[1].Show!.Title.ShouldBe("Breaking Bad");
            comments[1].Comment.ShouldNotBeNull();
            comments[1].Comment!.ID.ShouldBe(199U);
            comments[1].Comment!.Comment.ShouldBe("Skyler, I AM THE DANGER.");
        }

        [Fact]
        public async Task TestGetRecentlyCreatedCommentsPaging()
        {
            const string requestUri = $"{GetRecentlyCreatedCommentsUri}/shouts/episodes?include_replies=true&page=1&limit=4";
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, 1, 2, 4, 2);

            TraktPagedResponse<TraktUserComment> response = await client.Comments.GetRecentlyCreatedCommentsAsync(TraktCommentType.Shout, TraktCommentObjectType.Episode, true, TraktExtendedInfo.Full, 1, 4, TestContext.Current.CancellationToken);

            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetRecentlyCreatedCommentsUri}/shouts/episodes?include_replies=true&page=2&limit=4", responseContent, 2, 2, 4, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.ItemCount.ShouldBe(2U);
            response.Limit.ShouldBe(4U);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetRecentlyCreatedCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyCreatedCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}

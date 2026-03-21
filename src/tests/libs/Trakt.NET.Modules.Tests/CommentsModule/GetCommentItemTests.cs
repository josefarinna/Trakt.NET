using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed partial class GetCommentItemTests
    {
        private const uint CommentID = 190U;
        private const string GetCommentItemUri = "comments";

        [Theory]
        [InlineData(null, $"{GetCommentItemUri}/190/item", "Comments\\commentitem.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetCommentItemUri}/190/item", "Comments\\commentitem.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetCommentItemUri}/190/item?extended=full", "Comments\\commentitem.json")]
        public async Task TestGetCommentItem(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktCommentItem> response = await client.Comments.GetCommentItemAsync(CommentID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCommentItem commentItem = response.Content!;

            commentItem.Type.ShouldBe(TraktCommentObjectType.Movie);

            commentItem.Movie.ShouldNotBeNull();
            commentItem.Movie!.Title.ShouldBe("Star Wars: The Force Awakens");
            commentItem.Movie.Year.ShouldBe(2015U);
            commentItem.Movie.IDs.ShouldNotBeNull();
            commentItem.Movie.IDs!.Trakt.ShouldBe(94024U);

            commentItem.Show.ShouldNotBeNull();
            commentItem.Show.Title.ShouldBe("Game of Thrones");
            commentItem.Show.Year.ShouldBe(2011U);
            commentItem.Show.IDs.ShouldNotBeNull();
            commentItem.Show.IDs.Trakt.ShouldBe(1390U);

            commentItem.Season.ShouldNotBeNull();
            commentItem.Season.Number.ShouldBe(1U);
            commentItem.Season.IDs.ShouldNotBeNull();
            commentItem.Season.IDs!.Trakt.ShouldBe(61430U);

            commentItem.Episode.ShouldNotBeNull();
            commentItem.Episode.Number.ShouldBe(1U);
            commentItem.Episode.Season.ShouldBe(1U);
            commentItem.Episode.Title.ShouldBe("Winter Is Coming");
            commentItem.Episode.IDs.ShouldNotBeNull();
            commentItem.Episode.IDs.Trakt.ShouldBe(73640U);

            commentItem.List.ShouldNotBeNull();
            commentItem.List.Name.ShouldBe("Star Wars in machete order");
            commentItem.List.IDs.ShouldNotBeNull();
            commentItem.List.IDs.Trakt.ShouldBe(55U);
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
        public async Task TestGetCommentItemThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentItemUri}/{CommentID}/item", statusCode);

            Func<Task<TraktResponse<TraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}

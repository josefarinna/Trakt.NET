using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentItemTests
    {
        private readonly string GetCommentItemUri = $"comments/{CommentID}/item";
        private const uint CommentID = 190U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetCommentItem()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentitem.json");
            
            TraktClient client = ModuleTestUtility.GetClient(GetCommentItemUri, responseContent);

            TraktResponse<TraktCommentItem> response = await client.Comments.GetCommentItemAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCommentItem responseValue = response.Content;

            responseValue.Type.ShouldBe(TraktCommentObjectType.Movie);

            responseValue.Movie.ShouldNotBeNull();
            responseValue.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            responseValue.Movie.Year.ShouldBe(2015U);
            responseValue.Movie.IDs.ShouldNotBeNull();
            responseValue.Movie.IDs!.Trakt.ShouldBe(94024U);

            responseValue.Show.ShouldNotBeNull();
            responseValue.Show.Title.ShouldBe("Game of Thrones");
            responseValue.Show.Year.ShouldBe(2011U);
            responseValue.Show.IDs.ShouldNotBeNull();
            responseValue.Show.IDs.Trakt.ShouldBe(1390U);

            responseValue.Season.ShouldNotBeNull();
            responseValue.Season.Number.ShouldBe(1U);
            responseValue.Season.IDs.ShouldNotBeNull();
            responseValue.Season.IDs!.Trakt.ShouldBe(61430U);

            responseValue.Episode.ShouldNotBeNull();
            responseValue.Episode.Number.ShouldBe(1U);
            responseValue.Episode.Season.ShouldBe(1U);
            responseValue.Episode.Title.ShouldBe("Winter Is Coming");
            responseValue.Episode.IDs.ShouldNotBeNull();
            responseValue.Episode.IDs.Trakt.ShouldBe(73640U);

            responseValue.List.ShouldNotBeNull();
            responseValue.List.Name.ShouldBe("Star Wars in machete order");
            responseValue.List.IDs.ShouldNotBeNull();
            responseValue.List.IDs.Trakt.ShouldBe(55U);
        }

        [Fact]
        public async Task TestGetCommentItemWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentitem.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentItemUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktCommentItem> response = await client.Comments.GetCommentItemAsync(CommentID, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCommentItem responseValue = response.Content;

            responseValue.Type.ShouldBe(TraktCommentObjectType.Movie);

            responseValue.Movie.ShouldNotBeNull();
            responseValue.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            responseValue.Movie.Year.ShouldBe(2015U);
            responseValue.Movie.IDs.ShouldNotBeNull();
            responseValue.Movie.IDs!.Trakt.ShouldBe(94024U);

            responseValue.Show.ShouldNotBeNull();
            responseValue.Show.Title.ShouldBe("Game of Thrones");
            responseValue.Show.Year.ShouldBe(2011U);
            responseValue.Show.IDs.ShouldNotBeNull();
            responseValue.Show.IDs.Trakt.ShouldBe(1390U);

            responseValue.Season.ShouldNotBeNull();
            responseValue.Season.Number.ShouldBe(1U);
            responseValue.Season.IDs.ShouldNotBeNull();
            responseValue.Season.IDs!.Trakt.ShouldBe(61430U);

            responseValue.Episode.ShouldNotBeNull();
            responseValue.Episode.Number.ShouldBe(1U);
            responseValue.Episode.Season.ShouldBe(1U);
            responseValue.Episode.Title.ShouldBe("Winter Is Coming");
            responseValue.Episode.IDs.ShouldNotBeNull();
            responseValue.Episode.IDs.Trakt.ShouldBe(73640U);

            responseValue.List.ShouldNotBeNull();
            responseValue.List.Name.ShouldBe("Star Wars in machete order");
            responseValue.List.IDs.ShouldNotBeNull();
            responseValue.List.IDs.Trakt.ShouldBe(55U);
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
            TraktClient client = ModuleTestUtility.GetClient(GetCommentItemUri, statusCode);

            Func<Task<TraktResponse<TraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}

using System.Net;

namespace TraktNET.ListsModule
{
    public sealed partial class GetListLikesTests
    {
        private const uint ListID = 1248149U;
        private const string GetListLikesUri = $"lists/1248149/likes";

        [Fact]
        public async Task TestGetListLikes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");
            TraktClient client = ModuleTestUtility.GetClient(GetListLikesUri, responseContent);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID.ToString(), cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);

            List<TraktListLike> likes = [.. response.Content];

            likes[0].LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            likes[0].User.ShouldNotBeNull();
            likes[0].User!.Username.ShouldBe("justin");
            likes[0].User!.Name.ShouldBe("Justin Nemeth");
            likes[0].User!.VIP.ShouldBe(true);
            likes[0].User!.VIPEP.ShouldBe(true);
            likes[0].User!.IDs.ShouldNotBeNull();
            likes[0].User!.IDs!.Slug.ShouldBe("justin");
        }

        [Theory]
        [InlineData(1U, null, $"{GetListLikesUri}?page=1")]
        [InlineData(null, 10U, $"{GetListLikesUri}?limit=10")]
        [InlineData(1U, 10U, $"{GetListLikesUri}?page=1&limit=10")]
        public async Task TestGetListLikesWithParameters(uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listlikes.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktListLike> response = await client.Lists.GetListLikesAsync(ListID, page: page, limit: limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
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
        public async Task TestGetListLikesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListLikesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListLike>>> act = () => client.Lists.GetListLikesAsync(ListID.ToString(), cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListLikesThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListLikesUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktListLike>>> act = () => client.Lists.GetListLikesAsync(default(string));
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktRequestValidationException>();

#pragma warning disable CS8625
            act = () => client.Lists.GetListLikesAsync(default(TraktList), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListLikesAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}

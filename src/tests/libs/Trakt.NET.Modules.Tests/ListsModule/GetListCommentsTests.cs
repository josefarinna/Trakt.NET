using System.Net;

namespace TraktNET.ListsModule
{
    public sealed partial class GetListCommentsTests
    {
        private const uint ListID = 1248149U;
        private const string GetListCommentsUri = $"lists/1248149/comments";

        [Theory]
        [InlineData(null, null, null, null, GetListCommentsUri, "Lists\\listcomments.json")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, null, $"{GetListCommentsUri}/newest", "Lists\\listcomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetListCommentsUri}?extended=full", "Lists\\listcomments.json")]
        [InlineData(null, null, 1U, null, $"{GetListCommentsUri}?page=1", "Lists\\listcomments.json")]
        [InlineData(null, null, null, 10U, $"{GetListCommentsUri}?limit=10", "Lists\\listcomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 1U, 10U, $"{GetListCommentsUri}/likes?extended=full&page=1&limit=10", "Lists\\listcomments.json")]
        public async Task TestGetListComments(TraktCommentSortOrder? sortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(ListID, sortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);

            List<TraktComment> comments = [.. response.Content];

            for (int i = 0; i < 2; i++)
            {
                comments[i].ID.ShouldBe(8U + (uint)i);
                comments[i].ParentID.ShouldBe(0U);
                comments[i].CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2011-03-25T22:35:17.000Z"));
                comments[i].UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2011-03-25T22:35:17.000Z"));
                comments[i].Comment.ShouldBe("Great episode!");
                comments[i].Spoiler.ShouldBe(false);
                comments[i].Review.ShouldBe(false);
                comments[i].Replies.ShouldBe(1U);
                comments[i].Likes.ShouldBe(0U);
                comments[i].UserRating.ShouldBe(8U);

                comments[i].User.ShouldNotBeNull();
                comments[i].User!.Username.ShouldBe("sean");
                comments[i].User!.Private.ShouldBe(false);
                comments[i].User!.Name.ShouldBe("Sean Rudford");
                comments[i].User!.VIP.ShouldBe(true);
                comments[i].User!.VIPEP.ShouldBe(false);
            }
        }

        [Fact]
        public async Task TestGetListCommentsPaging()
        {
            string requestUri = $"{GetListCommentsUri}?page=1&limit=4";
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listcomments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, 1, 2, 4, 2);

            TraktPagedResponse<TraktComment> response = await client.Lists.GetListCommentsAsync(ListID, null, null, 1, 4, TestContext.Current.CancellationToken);

            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetListCommentsUri}?page=2&limit=4", responseContent, 2, 2, 4, 2);

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
        public async Task TestGetListCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Lists.GetListCommentsAsync(ListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListCommentsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListCommentsUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Lists.GetListCommentsAsync(default(string), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktRequestValidationException>();

#pragma warning disable CS8625
            act = () => client.Lists.GetListCommentsAsync(default(TraktList), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListCommentsAsync(new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}

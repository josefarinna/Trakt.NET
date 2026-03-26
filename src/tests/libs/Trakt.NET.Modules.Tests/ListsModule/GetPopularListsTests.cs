using System.Net;

namespace TraktNET.ListsModule
{
    public sealed partial class GetPopularListsTests
    {
        private const string GetPopularListsUri = "lists/popular";

        [Theory]
        [InlineData(null, null, null, GetPopularListsUri)]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetPopularListsUri}?extended=full")]
        [InlineData(null, 1U, null, $"{GetPopularListsUri}?page=1")]
        [InlineData(null, null, 10U, $"{GetPopularListsUri}?limit=10")]
        [InlineData(null, 1U, 10U, $"{GetPopularListsUri}?page=1&limit=10")]
        [InlineData(TraktExtendedInfo.Full, 2U, 20U, $"{GetPopularListsUri}?extended=full&page=2&limit=20")]
        public async Task TestGetPopularLists(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktPopularList> response = await client.Lists.GetPopularListsAsync(extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);

            List<TraktPopularList> lists = [.. response.Content];

            // First List Validation
            lists[0].ShouldNotBeNull();
            lists[0].LikeCount.ShouldBe(5);
            lists[0].CommentCount.ShouldBe(5);

            lists[0].List.ShouldNotBeNull();
            lists[0].List!.Name.ShouldBe("Incredible Thoughts");
            lists[0].List!.Description.ShouldBe("How could my brain conceive them?");
            lists[0].List!.Privacy.ShouldBe(TraktListPrivacy.Public);
            lists[0].List!.ShareLink.ShouldBe("https://trakt.tv/lists/1337");
            lists[0].List!.Type.ShouldBe(TraktListType.Personal);
            lists[0].List!.DisplayNumbers.ShouldBe(true);
            lists[0].List!.AllowComments.ShouldBe(true);
            lists[0].List!.SortBy.ShouldBe(TraktSortBy.Rank);
            lists[0].List!.SortHow.ShouldBe(TraktSortHow.Ascending);
            lists[0].List!.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            lists[0].List!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            lists[0].List!.ItemCount.ShouldBe(50U);
            lists[0].List!.CommentCount.ShouldBe(10U);
            lists[0].List!.Likes.ShouldBe(99U);

            lists[0].List!.IDs.ShouldNotBeNull();
            lists[0].List!.IDs!.Trakt.ShouldBe(1337U);
            lists[0].List!.IDs!.Slug.ShouldBe("incredible-thoughts");

            lists[0].List!.User.ShouldNotBeNull();
            lists[0].List!.User!.Username.ShouldBe("justin");
            lists[0].List!.User!.Private.ShouldBe(false);
            lists[0].List!.User!.Name.ShouldBe("Justin Nemeth");
            lists[0].List!.User!.VIP.ShouldBe(true);
            lists[0].List!.User!.VIPEP.ShouldBe(false);
            lists[0].List!.User!.IDs.ShouldNotBeNull();
            lists[0].List!.User!.IDs!.Slug.ShouldBe("justin");

            // Second List Minimal Validation
            lists[1].LikeCount.ShouldBe(109);
            lists[1].List.ShouldNotBeNull();
            lists[1].List!.Name.ShouldBe("Top Chihuahua Movies");
        }

        [Fact]
        public async Task TestGetPopularListsPaging()
        {
            const uint page = 1;
            const uint limit = 2;
            string requestUri = $"{GetPopularListsUri}?page={page}&limit={limit}";
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 2, limit, 2);

            TraktPagedResponse<TraktPopularList> response = await client.Lists.GetPopularListsAsync(null, page, limit, TestContext.Current.CancellationToken);

            response.Page.ShouldBe(page);
            response.Limit.ShouldBe(limit);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetPopularListsUri}?page=2&limit={limit}", responseContent, 2, 2, limit, 2);
            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.Page.ShouldBe(2U);
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
        public async Task TestGetPopularListsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPopularListsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktPopularList>>> act = () => client.Lists.GetPopularListsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}

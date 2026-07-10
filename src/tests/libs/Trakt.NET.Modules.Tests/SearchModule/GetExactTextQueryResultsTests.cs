using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class GetExactTextQueryResultsTests
    {
        private readonly string GetExactTextQueryUri = $"search/{TextQueryTypeMovie.ToURI()}/exact?query={TextQuery}";
        private readonly string GetExactTextQueryUriMultipleTypes = $"search/{TextQueryTypeMovie.ToURI()},{TextQueryTypeShow.ToURI()}/exact?query={TextQuery}";
        private const TraktSearchResultType TextQueryTypes = TraktSearchResultType.Movie | TraktSearchResultType.Show;
        private const string TextQuery = "batman";
        private const uint TextQueryItemCount = 10U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktSearchResultType TextQueryTypeMovie = TraktSearchResultType.Movie;
        private const TraktSearchResultType TextQueryTypeShow = TraktSearchResultType.Show;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetExactTextQueryResults()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(GetExactTextQueryUri, responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsMultipleTypes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(GetExactTextQueryUriMultipleTypes, responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypes, TextQuery, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetExactTextQueryUri}&page={Page}", responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetExactTextQueryUri}&limit={Limit}", responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        public async Task TestGetExactTextQueryResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetExactTextQueryUri, statusCode);

            Func<Task<TraktPagedResponse<TraktSearchResult>>> act = () => client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetExactTextQueryUri, "{}");

            Func<Task<TraktPagedResponse<TraktSearchResult>>> act = () => client.Search.GetExactTextQueryResultsAsync(TraktSearchResultType.Unspecified, TextQuery, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, null!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, "  ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}

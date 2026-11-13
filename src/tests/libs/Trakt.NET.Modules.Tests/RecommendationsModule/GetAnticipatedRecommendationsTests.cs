using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class GetAnticipatedRecommendationsTests
    {
        private const string MoviesUri = "movies/recommendations/anticipated";
        private const string ShowsUri = "shows/recommendations/anticipated";
        private const string MediaUri = "media/recommendations/anticipated";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemsCount = 2U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetAnticipatedMovieRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmovierecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(MoviesUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMovieRecommendation> response = await client.Recommendations.GetAnticipatedMovieRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);

            TraktAnticipatedMovieRecommendation item = response.Content[0];
            item.Movie.ShouldNotBeNull();
            item.Movie.Title.ShouldBe("Dune: Part Three");
            item.Score.ShouldBe(0.82f);
#if NET7_0_OR_GREATER
            item.Released.ShouldBe(TestUtility.ParseDate("2027-03-12"));
#else
            item.Released.ShouldBe(TestUtility.ParseUTCDateTime("2027-03-12T00:00:00.000Z"));
#endif
        }

        [Fact]
        public async Task TestGetAnticipatedMovieRecommendationsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmovierecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MoviesUri}?page={Page}",
                                                                responseContent, Page, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMovieRecommendation> response = await client.Recommendations.GetAnticipatedMovieRecommendationsAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedMovieRecommendationsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmovierecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MoviesUri}?limit={Limit}",
                                                                responseContent, 1, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMovieRecommendation> response = await client.Recommendations.GetAnticipatedMovieRecommendationsAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedMovieRecommendationsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmovierecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MoviesUri}?page={Page}&limit={Limit}",
                                                                responseContent, Page, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMovieRecommendation> response = await client.Recommendations.GetAnticipatedMovieRecommendationsAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedMovieRecommendationsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmovierecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MoviesUri}?extended={ExtendedInfo.ToURI()}",
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMovieRecommendation> response = await client.Recommendations.GetAnticipatedMovieRecommendationsAsync(extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedMovieRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmovierecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MoviesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMovieRecommendation> response = await client.Recommendations.GetAnticipatedMovieRecommendationsAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{MoviesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetAnticipatedMovieRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmovierecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MoviesUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMovieRecommendation> response = await client.Recommendations.GetAnticipatedMovieRecommendationsAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{MoviesUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetAnticipatedMovieRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(MoviesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktAnticipatedMovieRecommendation>>> act = () => client.Recommendations.GetAnticipatedMovieRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ShowsUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Recommendations.GetAnticipatedShowRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);

            TraktAnticipatedShowRecommendation item = response.Content[0];
            item.Show.ShouldNotBeNull();
            item.Show.Title.ShouldBe("Euphoria");
            item.Score.ShouldBe(0.4f);
            item.Released.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendationsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{ShowsUri}?page={Page}",
                                                                responseContent, Page, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Recommendations.GetAnticipatedShowRecommendationsAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendationsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{ShowsUri}?limit={Limit}",
                                                                responseContent, 1, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Recommendations.GetAnticipatedShowRecommendationsAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendationsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{ShowsUri}?page={Page}&limit={Limit}",
                                                                responseContent, Page, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Recommendations.GetAnticipatedShowRecommendationsAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendationsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{ShowsUri}?extended={ExtendedInfo.ToURI()}",
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Recommendations.GetAnticipatedShowRecommendationsAsync(extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{ShowsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Recommendations.GetAnticipatedShowRecommendationsAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{ShowsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetAnticipatedShowRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedshowrecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{ShowsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedShowRecommendation> response = await client.Recommendations.GetAnticipatedShowRecommendationsAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{ShowsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetAnticipatedShowRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ShowsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktAnticipatedShowRecommendation>>> act = () => client.Recommendations.GetAnticipatedShowRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendations()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(MediaUri,
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Recommendations.GetAnticipatedMediaRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);

            TraktAnticipatedMediaRecommendation movieItem = response.Content[0];
            movieItem.Movie.ShouldNotBeNull();
            movieItem.Movie.Title.ShouldBe("Dune: Part Three");
            movieItem.Show.ShouldBeNull();
            movieItem.Score.ShouldBe(0.9f);
#if NET7_0_OR_GREATER
            movieItem.Released.ShouldBe(TestUtility.ParseDate("2027-03-12"));
#else
            movieItem.Released.ShouldBe(TestUtility.ParseUTCDateTime("2027-03-12T00:00:00.000Z"));
#endif
            movieItem.Type.ShouldBe(TraktSearchResultType.Movie);

            TraktAnticipatedMediaRecommendation showItem = response.Content[1];
            showItem.Movie.ShouldBeNull();
            showItem.Show.ShouldNotBeNull();
            showItem.Show.Title.ShouldBe("Euphoria");
            showItem.Score.ShouldBe(0.5f);
            showItem.Released.ShouldBeNull();
            showItem.Type.ShouldBe(TraktSearchResultType.Show);
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendationsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MediaUri}?page={Page}",
                                                                responseContent, Page, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Recommendations.GetAnticipatedMediaRecommendationsAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendationsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MediaUri}?limit={Limit}",
                                                                responseContent, 1, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Recommendations.GetAnticipatedMediaRecommendationsAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendationsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MediaUri}?page={Page}&limit={Limit}",
                                                                responseContent, Page, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Recommendations.GetAnticipatedMediaRecommendationsAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendationsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MediaUri}?extended={ExtendedInfo.ToURI()}",
                                                                responseContent, 1, 1, 10, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Recommendations.GetAnticipatedMediaRecommendationsAsync(extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendationsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MediaUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Recommendations.GetAnticipatedMediaRecommendationsAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{MediaUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetAnticipatedMediaRecommendationsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Recommendations\\anticipatedmediarecommendations.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{MediaUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktAnticipatedMediaRecommendation> response = await client.Recommendations.GetAnticipatedMediaRecommendationsAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{MediaUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetAnticipatedMediaRecommendationsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(MediaUri, statusCode);

            Func<Task<TraktPagedResponse<TraktAnticipatedMediaRecommendation>>> act = () => client.Recommendations.GetAnticipatedMediaRecommendationsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}

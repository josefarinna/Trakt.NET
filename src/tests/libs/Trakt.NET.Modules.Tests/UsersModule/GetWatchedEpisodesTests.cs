using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetWatchedEpisodesTests
    {
        private const string GetWatchedEpisodesUri = $"users/{Username}/watched/episodes";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint EpisodesCount = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetWatchedEpisodes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetWatchedEpisodesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response = await client.Users.GetWatchedEpisodesAsync(Username, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedEpisodesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedEpisodesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, EpisodesCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktWatchedEpisode> response = await client.Users.GetWatchedEpisodesAsync(Username, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedEpisodesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/watched/episodes?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response = await client.Users.GetWatchedEpisodesAsync("me", null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedEpisodesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response = await client.Users.GetWatchedEpisodesAsync(Username, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Users.GetWatchedEpisodesAsync(Username, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Users.GetWatchedEpisodesAsync(Username, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Users.GetWatchedEpisodesAsync(Username, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Users.GetWatchedEpisodesAsync(Username, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Users.GetWatchedEpisodesAsync(Username, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, EpisodesCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, EpisodesCount);

            TraktPagedResponse<TraktWatchedEpisode> response =
                await client.Users.GetWatchedEpisodesAsync(Username, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchedEpisodesUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, EpisodesCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)EpisodesCount);
            response.ItemCount.ShouldBe(EpisodesCount);
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
        public async Task TestGetWatchedEpisodesThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchedEpisodesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktWatchedEpisode>>> act = () => client.Users.GetWatchedEpisodesAsync(Username, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetWatchedEpisodesThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchedEpisodesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktWatchedEpisode>>> act = () => client.Users.GetWatchedEpisodesAsync(Username, null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetWatchedEpisodesAsync(Username, null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}

using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetPersonalListTests
    {
        private const string GetPersonalListUri = $"users/{Username}/lists/{ListID}";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";

        [Fact]
        public async Task TestGetPersonalList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListUri, responseContent);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, ListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{TraktListID}", responseContent);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, TraktListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithListIdsTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{TraktListID}", responseContent);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, listIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithListIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");

            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}", responseContent);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, listIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithListIds()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");
            
            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}", responseContent);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, listIds, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");
            
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPersonalListUri, responseContent, null, null, null, null);
            
            //client.Configuration.ForceAuthorization = true;

            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync(Username, ListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\list.json");
            
            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/lists/{ListID}", responseContent, null, null, null, null);
            
            TraktResponse<TraktList> response = await client.Users.GetPersonalListAsync("me", ListID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktList responseValue = response.Content;

            responseValue.Name.ShouldBe("Star Wars in machete order");
            responseValue.Description.ShouldBe("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.ShouldBe(TraktListPrivacy.Public);
            responseValue.DisplayNumbers.ShouldBe(true);
            responseValue.AllowComments.ShouldBe(false);
            responseValue.SortBy.ShouldBe(TraktSortBy.Rank);
            responseValue.SortHow.ShouldBe(TraktSortHow.Ascending);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-11-09T17:00:54.000Z"));
            responseValue.ItemCount.ShouldBe(5U);
            responseValue.CommentCount.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(55U);
            responseValue.IDs.Slug.ShouldBe("star-wars-in-machete-order");
            responseValue.User.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiUserNotFoundException))]
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
        public async Task TestGetPersonalListThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListUri, statusCode);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.GetPersonalListAsync(Username, ListID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Users.GetPersonalListAsync(Username, default(TraktListIDs)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetPersonalListAsync(Username, new TraktListIDs()!);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetPersonalListAsync(Username, 0);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}

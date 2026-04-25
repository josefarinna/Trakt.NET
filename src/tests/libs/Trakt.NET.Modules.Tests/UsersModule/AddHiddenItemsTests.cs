using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class AddHiddenItemsTests
    {
        private readonly string AddHiddenItemsUri = $"users/hidden/{HiddenItemsSection.ToURI()}";
        private const TraktHiddenItemsSection HiddenItemsSection = TraktHiddenItemsSection.Calendar;
        private readonly TraktUserHiddenItemsPost HiddenItemsPost = SetupHiddenItemsPost();

        [Fact]
        public async Task TestAddHiddenItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitemspostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddHiddenItemsUri, responseContent, null, null, null, null);

            TraktResponse<TraktUserHiddenItemsPostResponse> response =
                await client.Users.AddHiddenItemsAsync(HiddenItemsPost, HiddenItemsSection, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserHiddenItemsPostResponse responseValue = response.Content;

            responseValue.Added.ShouldNotBeNull();
            responseValue.Added.Movies.ShouldBe(1U);
            responseValue.Added.Shows.ShouldBe(2U);
            responseValue.Added.Seasons.ShouldBe(2U);

            responseValue.NotFound.ShouldNotBeNull();
            responseValue.NotFound.Movies.ShouldNotBeNull();
            responseValue.NotFound.Movies.Count.ShouldBe(1);

            TraktPostResponseNotFoundMovie[] movies = [.. responseValue.NotFound.Movies];

            movies[0].IDs.ShouldNotBeNull();
            movies[0].IDs!.Trakt.ShouldBeNull();
            movies[0].IDs!.Slug.ShouldBeNullOrEmpty();
            movies[0].IDs!.IMDB.ShouldBe("tt0000111");
            movies[0].IDs!.TMDB.ShouldBeNull();

            responseValue.NotFound.Shows.ShouldNotBeNull();
            responseValue.NotFound.Shows.Count.ShouldBe(0);
            responseValue.NotFound.Seasons.ShouldNotBeNull();
            responseValue.NotFound.Seasons.Count.ShouldBe(0);
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
        public async Task TestAddHiddenItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddHiddenItemsUri, statusCode);

            Func<Task<TraktResponse<TraktUserHiddenItemsPostResponse>>> act = () => client.Users.AddHiddenItemsAsync(HiddenItemsPost, HiddenItemsSection, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        private static TraktUserHiddenItemsPost SetupHiddenItemsPost()
        {
            return new TraktUserHiddenItemsPost
            {
                Movies =
                [
                    new TraktUserHiddenItemsPostMovie
                    {
                        IDs = new TraktMovieIDs { Trakt = 1U },
                    },
                    new TraktUserHiddenItemsPostMovie
                    {
                        IDs = new TraktMovieIDs { IMDB = "tt0000111" }
                    }
                ],
                Shows =
                [
                    new TraktUserHiddenItemsPostShow
                    {
                        IDs = new TraktShowIDs { Trakt = 1U }
                    },
                    new TraktUserHiddenItemsPostShow
                    {
                        Seasons =
                        [
                            new TraktUserHiddenItemsPostShowSeason
                            {
                                Number = 1
                            }
                        ],
                        IDs = new TraktShowIDs { Trakt = 2U }
                    },
                    new TraktUserHiddenItemsPostShow
                    {
                        Seasons =
                        [
                            new TraktUserHiddenItemsPostShowSeason
                            {
                                Number = 2
                            }
                        ],
                        IDs = new TraktShowIDs { Trakt = 3U }
                    }
                ],
                Seasons =
                [
                    new TraktUserHiddenItemsPostSeason
                    {
                        IDs = new TraktSeasonIDs
                        {
                            Trakt = 61430U,
                            TVDB = 578373U,
                            TMDB = 60523U
                        }
                    }
                ]
            };
        }
    }
}

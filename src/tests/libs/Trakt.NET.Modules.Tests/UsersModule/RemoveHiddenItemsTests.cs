using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class RemoveHiddenItemsTests
    {
        private readonly string RemoveHiddenItemsUri = $"users/hidden/{HiddenItemsSection.ToURI()}/remove";
        private const TraktHiddenItemsSection HiddenItemsSection = TraktHiddenItemsSection.Calendar;
        private readonly TraktUserHiddenItemsRemovePost HiddenItemsRemovePost = SetupHiddenItemsRemovePost();

        [Fact]
        public async Task TestRemoveHiddenItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitemsremovepostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                RemoveHiddenItemsUri, responseContent);

            TraktResponse<TraktUserHiddenItemsRemovePostResponse> response =
                await client.Users.RemoveHiddenItemsAsync(HiddenItemsRemovePost, HiddenItemsSection, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserHiddenItemsRemovePostResponse responseValue = response.Content;

            responseValue.Deleted.ShouldNotBeNull();
            responseValue.Deleted.Movies.ShouldBe(1U);
            responseValue.Deleted.Shows.ShouldBe(2U);
            responseValue.Deleted.Seasons.ShouldBe(2U);

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
        public async Task TestRemoveHiddenItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveHiddenItemsUri, statusCode);

            Func<Task<TraktResponse<TraktUserHiddenItemsRemovePostResponse>>> act = () => client.Users.RemoveHiddenItemsAsync(HiddenItemsRemovePost, HiddenItemsSection, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        private static TraktUserHiddenItemsRemovePost SetupHiddenItemsRemovePost()
        {
            return new TraktUserHiddenItemsRemovePost
            {
                Movies =
                [
                    new TraktUserHiddenItemsPostMovie
                    {
                        IDs = new TraktMovieIDs { Trakt = 1 },
                    },
                    new TraktUserHiddenItemsPostMovie
                    {
                        IDs = new TraktMovieIDs { IMDB = "tt0000111" }
                    }
                ],
                Shows =
                [
                    new TraktUserRemovePostShow
                    {
                        IDs = new TraktShowIDs { Trakt = 1 }
                    },
                    new TraktUserRemovePostShow
                    {
                        Seasons =
                        [
                            new TraktUserRemovePostShowSeason
                            {
                                Number = 1
                            }
                        ],
                        IDs = new TraktShowIDs { Trakt = 2 }
                    },
                    new TraktUserRemovePostShow
                    {
                        Seasons =
                        [
                            new TraktUserHiddenItemsPostShowSeason
                            {
                                Number = 2
                            }
                        ],
                        IDs = new TraktShowIDs { Trakt = 3 }
                    }
                ],
                Seasons =
                [
                    new TraktUserRemovePostSeason
                    {
                        IDs = new TraktSeasonIDs
                        {
                            Trakt = 61430,
                            TVDB = 578373,
                            TMDB = 60523
                        }
                    }
                ]
            };
        }
    }
}

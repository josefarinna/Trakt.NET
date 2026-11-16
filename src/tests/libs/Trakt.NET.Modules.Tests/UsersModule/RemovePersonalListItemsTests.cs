using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class RemovePersonalListItemsTests
    {
        private readonly string RemovePersonalListItemsUri = $"users/{Username}/lists/{ListID}/items/remove";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private readonly TraktUserPersonalListItemsRemovePost RemovePersonalListItemsPost = SetupRemovePersonalListItemsPost();

        [Fact]
        public async Task TestRemovePersonalListItemsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistitemsremovepostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(RemovePersonalListItemsUri, responseContent, null, null, null, null);

            TraktResponse<TraktUserPersonalListItemsRemovePostResponse> response =
                await client.Users.RemovePersonalListItemsAsync(Username, TraktListID, RemovePersonalListItemsPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktUserPersonalListItemsRemovePostResponse responseValue = response.Content;

            responseValue.Deleted.ShouldNotBeNull();
            responseValue.Deleted.Movies.ShouldBe(1U);
            responseValue.Deleted.Shows.ShouldBe(1U);
            responseValue.Deleted.Seasons.ShouldBe(1U);
            responseValue.Deleted.Episodes.ShouldBe(2U);
            responseValue.Deleted.People.ShouldBe(1U);
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
            responseValue.NotFound.Episodes.ShouldNotBeNull();
            responseValue.NotFound.Episodes.Count.ShouldBe(0);
            responseValue.NotFound.People.ShouldNotBeNull();
            responseValue.NotFound.People.Count.ShouldBe(0);
        }

        [Fact]
        public async Task TestRemovePersonalListItemsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistitemsremovepostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/remove",
                responseContent, null, null, null, null);

            TraktResponse<TraktUserPersonalListItemsRemovePostResponse> response =
                await client.Users.RemovePersonalListItemsAsync(Username, ListSlug, RemovePersonalListItemsPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRemovePersonalListItemsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistitemsremovepostresponse.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/remove",
                responseContent, null, null, null, null);

            TraktResponse<TraktUserPersonalListItemsRemovePostResponse> response =
                await client.Users.RemovePersonalListItemsAsync(Username, listIds, RemovePersonalListItemsPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRemovePersonalListItemsWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\customlistitemsremovepostresponse.json");

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/{Username}/lists/{ListSlug}/items/remove",
                responseContent, null, null, null, null);

            TraktResponse<TraktUserPersonalListItemsRemovePostResponse> response =
                await client.Users.RemovePersonalListItemsAsync(Username, list, RemovePersonalListItemsPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
        public async Task TestRemovePersonalListItemsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemovePersonalListItemsUri, statusCode);

            Func<Task<TraktResponse<TraktUserPersonalListItemsRemovePostResponse>>> act = () => client.Users.RemovePersonalListItemsAsync(Username, TraktListID, RemovePersonalListItemsPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRemovePersonalListItemsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemovePersonalListItemsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktUserPersonalListItemsRemovePostResponse>>> act =
                () => client.Users.RemovePersonalListItemsAsync(Username, default(TraktListIDs)!, RemovePersonalListItemsPost, TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.RemovePersonalListItemsAsync(Username, default(TraktList)!, RemovePersonalListItemsPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.RemovePersonalListItemsAsync(Username, new TraktListIDs(), RemovePersonalListItemsPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.RemovePersonalListItemsAsync(Username, 0, RemovePersonalListItemsPost, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        private static TraktUserPersonalListItemsRemovePost SetupRemovePersonalListItemsPost() => new TraktUserPersonalListItemsRemovePost
        {
            Movies =
                [
                    new TraktUserRemovePostMovie
                    {
                        IDs = new TraktMovieIDs { Trakt = 1U },
                    },
                    new TraktUserRemovePostMovie
                    {
                        IDs = new TraktMovieIDs { IMDB = "tt0000111" }
                    }
                ],
            Shows =
                [
                    new TraktUserRemovePostShow
                    {
                        IDs = new TraktShowIDs { Trakt = 1U }
                    },
                    new TraktUserRemovePostShow
                    {
                        Seasons =
                        [
                            new TraktUserRemovePostShowSeason
                            {
                                Number = 1U
                            }
                        ],
                        IDs = new TraktShowIDs { Trakt = 2U }
                    },
                    new TraktUserRemovePostShow
                    {
                        Seasons =
                        [
                            new TraktUserRemovePostShowSeason
                            {
                                Number = 1U,
                                Episodes =
                                [
                                    new TraktUserRemovePostShowEpisode
                                    {
                                        Number = 1U
                                    },
                                    new TraktUserRemovePostShowEpisode
                                    {
                                        Number = 2U
                                    }
                                ]
                            }
                        ],
                        IDs = new TraktShowIDs { Trakt = 3U }
                    }
                ],
            People =
                [
                    new TraktUserPersonalListItemsPostPerson
                    {
                        IDs = new TraktPersonIDs
                        {
                            Trakt = 2U,
                            Slug = "jeff-bridges",
                            IMDB = "nm0000313",
                            TMDB = 1229U
                        }
                    }
                ]
        };
    }
}

namespace TraktNET.Json.Users
{
    public sealed class TraktUserPersonalListItemsPostTests
    {
        [Fact]
        public void TestTraktUserPersonalListItemsPostValidate()
        {
            var userPersonalListItemsPost = new TraktUserPersonalListItemsPost();

            // movies = null, shows = null, seasons = null, episodes = null, people = null
            Action act = () => userPersonalListItemsPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null, people = null
            userPersonalListItemsPost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null, people = null
            userPersonalListItemsPost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null, people = null
            userPersonalListItemsPost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people = null
            userPersonalListItemsPost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people = empty
            userPersonalListItemsPost.People = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty, people = empty
            userPersonalListItemsPost.Movies.Add(new TraktUserPersonalListItemsPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty, people = empty
            userPersonalListItemsPost.Movies.Clear();
            userPersonalListItemsPost.Shows.Add(new TraktUserPersonalListItemsPostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty, people = empty
            userPersonalListItemsPost.Shows.Clear();
            userPersonalListItemsPost.Seasons.Add(new TraktUserPersonalListItemsPostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item, people = empty
            userPersonalListItemsPost.Seasons.Clear();
            userPersonalListItemsPost.Episodes.Add(new TraktUserPersonalListItemsPostEpisode());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people with at least one item
            userPersonalListItemsPost.Episodes.Clear();
            userPersonalListItemsPost.People.Add(new TraktUserPersonalListItemsPostPerson());
            act.ShouldNotThrow();
        }

        [Fact]
        public void TestTraktUserPersonalListItemsPostNotesAtEveryLevel()
        {
            var post = new TraktUserPersonalListItemsPost
            {
                Movies = [new TraktUserPersonalListItemsPostMovie { IDs = new TraktMovieIDs { Trakt = 1 }, Notes = "movie" }],
                Shows =
                [
                    new TraktUserPersonalListItemsPostShow
                    {
                        IDs = new TraktShowIDs { Trakt = 2 },
                        Notes = "show",
                        Seasons =
                        [
                            new TraktUserPersonalListItemsPostShowSeason
                            {
                                Number = 1,
                                Notes = "season",
                                Episodes = [new TraktUserPersonalListItemsPostShowEpisode { Number = 1, Notes = "episode" }]
                            }
                        ]
                    }
                ],
                Seasons = [new TraktUserPersonalListItemsPostSeason { IDs = new TraktSeasonIDs { Trakt = 3 }, Notes = "season" }],
                Episodes = [new TraktUserPersonalListItemsPostEpisode { IDs = new TraktEpisodeIDs { Trakt = 4 }, Notes = "episode" }],
                People = [new TraktUserPersonalListItemsPostPerson { IDs = new TraktPersonIDs { Trakt = 5 }, Notes = "person" }]
            };

            post.Movies[0].Notes.ShouldBe("movie");
            post.Shows[0].Notes.ShouldBe("show");
            post.Shows[0].Seasons![0].Notes.ShouldBe("season");
            post.Shows[0].Seasons![0].Episodes![0].Notes.ShouldBe("episode");
            post.Seasons[0].Notes.ShouldBe("season");
            post.Episodes[0].Notes.ShouldBe("episode");
            post.People[0].Notes.ShouldBe("person");
        }
    }
}

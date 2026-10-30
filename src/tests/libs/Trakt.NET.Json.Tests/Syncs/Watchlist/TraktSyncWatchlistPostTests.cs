namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncWatchlistPostTests
    {
        [Fact]
        public void TestTraktSyncWatchlistPostValidate()
        {
            var syncWatchlistPost = new TraktSyncWatchlistPost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncWatchlistPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncWatchlistPost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncWatchlistPost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncWatchlistPost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncWatchlistPost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            syncWatchlistPost.Movies.Add(new TraktSyncWatchlistPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            syncWatchlistPost.Movies.Clear();
            syncWatchlistPost.Shows.Add(new TraktSyncWatchlistPostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            syncWatchlistPost.Shows.Clear();
            syncWatchlistPost.Seasons.Add(new TraktSyncWatchlistPostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            syncWatchlistPost.Seasons.Clear();
            syncWatchlistPost.Episodes.Add(new TraktSyncWatchlistPostEpisode());
            act.ShouldNotThrow();
        }

        [Fact]
        public void TestTraktSyncWatchlistPostNotesAtEveryLevel()
        {
            var post = new TraktSyncWatchlistPost
            {
                Movies = [new TraktSyncWatchlistPostMovie { IDs = new TraktMovieIDs { Trakt = 1 }, Notes = "movie" }],
                Shows =
                [
                    new TraktSyncWatchlistPostShow
                    {
                        IDs = new TraktShowIDs { Trakt = 2 },
                        Notes = "show",
                        Seasons =
                        [
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 1,
                                Notes = "season",
                                Episodes = [new TraktSyncWatchlistPostShowEpisode { Number = 1, Notes = "episode" }]
                            }
                        ]
                    }
                ],
                Seasons = [new TraktSyncWatchlistPostSeason { IDs = new TraktSeasonIDs { Trakt = 3 }, Notes = "season" }],
                Episodes = [new TraktSyncWatchlistPostEpisode { IDs = new TraktEpisodeIDs { Trakt = 4 }, Notes = "episode" }]
            };

            post.Movies[0].Notes.ShouldBe("movie");
            post.Shows[0].Notes.ShouldBe("show");
            post.Shows[0].Seasons![0].Notes.ShouldBe("season");
            post.Shows[0].Seasons![0].Episodes![0].Notes.ShouldBe("episode");
            post.Seasons[0].IDs!.Trakt.ShouldBe(3u);
            post.Seasons[0].Notes.ShouldBe("season");
            post.Episodes[0].Notes.ShouldBe("episode");
        }
    }
}

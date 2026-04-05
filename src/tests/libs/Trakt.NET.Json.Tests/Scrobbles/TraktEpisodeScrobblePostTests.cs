namespace TraktNET.Scrobbles
{
    public sealed class TraktEpisodeScrobblePostTests
    {
        [Fact]
        public void TestTraktEpisodeScrobblePostValidate()
        {
            var episodeScrobblePost = new TraktEpisodeScrobblePost { Progress = 0 };

            // Episode = null, Show = null, Progress = 0
            Action act = () => episodeScrobblePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids = null, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode();
            act.ShouldThrow<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids have no valid id, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { IDs = new TraktEpisodeIDs() };
            act.ShouldThrow<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids = valid, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 } };
            act.ShouldNotThrow();

            // Episode valid, Progress not valid
            episodeScrobblePost.Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 } };
            episodeScrobblePost.Progress = -0.1f;
            act.ShouldThrow<TraktPostValidationException>();

            // Episode valid, Progress not valid
            episodeScrobblePost.Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 } };
            episodeScrobblePost.Progress = 100.1f;
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            episodeScrobblePost.Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 } };
            episodeScrobblePost.Progress = 0;
            act.ShouldNotThrow();

            // valid
            episodeScrobblePost.Episode = new TraktEpisode { IDs = new TraktEpisodeIDs { Trakt = 1 } };
            episodeScrobblePost.Progress = 100;
            act.ShouldNotThrow();

            // Episode != null, Show != null, Show Ids = null, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode();
            episodeScrobblePost.Show = new TraktShow();
            act.ShouldThrow<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids have no valid id, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode();
            episodeScrobblePost.Show = new TraktShow { IDs = new TraktShowIDs() };
            act.ShouldThrow<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids = valid, Episode Number not valid, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { Season = 0, Number = 0 };
            episodeScrobblePost.Show = new TraktShow { IDs = new TraktShowIDs { Trakt = 1 } };
            act.ShouldThrow<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids = valid, Episode Numbers are valid, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { Season = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { IDs = new TraktShowIDs { Trakt = 1 } };
            act.ShouldNotThrow();

            // Episode valid, Progress not valid
            episodeScrobblePost.Episode = new TraktEpisode { Season = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { IDs = new TraktShowIDs { Trakt = 1 } };
            episodeScrobblePost.Progress = -0.1f;
            act.ShouldThrow<TraktPostValidationException>();

            // Episode valid, Progress not valid
            episodeScrobblePost.Episode = new TraktEpisode { Season = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { IDs = new TraktShowIDs { Trakt = 1 } };
            episodeScrobblePost.Progress = 100.1f;
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            episodeScrobblePost.Episode = new TraktEpisode { Season = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { IDs = new TraktShowIDs { Trakt = 1 } };
            episodeScrobblePost.Progress = 0;
            act.ShouldNotThrow();

            // valid
            episodeScrobblePost.Episode = new TraktEpisode { Season = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { IDs = new TraktShowIDs { Trakt = 1 } };
            episodeScrobblePost.Progress = 100;
            act.ShouldNotThrow();
        }
    }
}

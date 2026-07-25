namespace TraktNET
{
    public static class TestConstants
    {
        public const string ClientID = "traktClientID";
        public const string ClientSecret = "traktClientSecret";
        public const string MockAccessToken = "mockAccessToken";
        public const string MockRefreshToken = "mockRefreshToken";
        public const string RedirectURI = "urn:ietf:wg:oauth:2.0:oob";
        public const string MockDeviceCode = "mockDeviceCode";
        public const string MockUserCode = "5055CC52";
        public const string DeviceVerificationURL = "https://trakt.tv/activate";
        public const uint DeviceExpiresIn = 600;
        public const uint DeviceInterval = 6;
        private static readonly object LockObject = new();
        private static TraktDevice? _mockDevice;
        private static DateTime _mockDeviceLastCreated;
        private static TraktAuthorization? _mockAuthorization;
        private static DateTime _mockAuthorizationLastCreated;

        public static TraktDevice MockDevice
        {
            get
            {
                lock (LockObject)
                {
                    if (_mockDevice == null || DateTime.UtcNow - _mockDeviceLastCreated > TimeSpan.FromSeconds(5))
                    {
                        _mockDevice = new TraktDevice
                        {
                            DeviceCode = MockDeviceCode,
                            UserCode = MockUserCode,
                            VerificationUrl = DeviceVerificationURL,
                            ExpiresIn = DeviceExpiresIn,
                            Interval = DeviceInterval
                        };
                        _mockDeviceLastCreated = DateTime.UtcNow;
                    }
                    return _mockDevice;
                }
            }
        }

        public static TraktAuthorization MockAuthorization
        {
            get
            {
                lock (LockObject)
                {
                    if (_mockAuthorization == null || DateTime.UtcNow - _mockAuthorizationLastCreated > TimeSpan.FromSeconds(5))
                    {
                        _mockAuthorization = new TraktAuthorization
                        {
                            CreatedAt = (ulong)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                            AccessToken = MockAccessToken,
                            ExpiresIn = 3600U,
                            RefreshToken = MockRefreshToken
                        };
                        _mockAuthorizationLastCreated = DateTime.UtcNow;
                    }
                    return _mockAuthorization;
                }
            }
        }

        public static class Movies
        {
            public const string MovieID = "293990";

            public const uint TraktMovieID = 293990U;

            public const string MovieSlug = "guardians-of-the-galaxy-volume-3-2023";

            public static readonly TraktMovieIDs MovieIDs = new()
            {
                Trakt = 293990U,
                Slug = "guardians-of-the-galaxy-volume-3-2023",
                IMDB = "tt6791350",
                TMDB = 447365U
            };

            public static readonly TraktFilter Filter = new()
            {
                Genres = ["action", "drama"],
                Year = 2024U
            };
        }

        public static class Shows
        {
            public const string ShowID = "1390";

            public const uint TraktShowID = 1390U;

            public const string ShowSlug = "game-of-thrones";

            public static readonly TraktShowIDs ShowIDs = new()
            {
                Trakt = 1390U,
                Slug = "game-of-thrones",
                IMDB = "tt0944947",
                TMDB = 1399U,
                TVDB = 121361U
            };

            public static readonly TraktFilter Filter = new()
            {
                Genres = ["fantasy", "drama"],
                Year = 2011U
            };
        }

        public static class Seasons
        {
            public const string SeasonID = "3967";

            public const uint TraktSeasonID = 3967U;

            public static readonly TraktSeasonIDs SeasonIDs = new()
            {
                Trakt = 3967U,
                TMDB = 3624U,
                TVDB = 30272U
            };
        }

        public static class Episodes
        {
            public const string EpisodeID = "73640";

            public const uint TraktEpisodeID = 73640U;

            public static readonly TraktEpisodeIDs EpisodeIDs = new()
            {
                Trakt = 73640U,
                IMDB = "tt1480055",
                TMDB = 63056U,
                TVDB = 3254641U
            };
        }
    }
}

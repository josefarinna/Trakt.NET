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
        public static readonly TraktDevice MockDevice = new()
        {
            DeviceCode = MockDeviceCode,
            UserCode = MockUserCode,
            VerificationUrl = DeviceVerificationURL,
            ExpiresIn = DeviceExpiresIn,
            Interval = DeviceInterval
        };

        public static readonly TraktAuthorization MockAuthorization = new()
        {
            CreatedAt = (ulong)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
            AccessToken = MockAccessToken,
            ExpiresIn = 3600U,
            RefreshToken = MockRefreshToken
        };

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
    }
}

namespace TraktNET
{
    public static class TestConstants
    {
        public const string ClientID = "traktClientID";
        public const string ClientSecret = "traktClientSecret";
        public const string MockAccessToken = "mockAccessToken";

        public static readonly TraktAuthorization MockAuthorization =
            new()
            {
                CreatedAt = (ulong)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                AccessToken = MockAccessToken,
                ExpiresIn = 3600U
            };

        public static class Movies
        {
            public const uint MovieID = 293990U;

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
            public const uint ShowID = 1390U;

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

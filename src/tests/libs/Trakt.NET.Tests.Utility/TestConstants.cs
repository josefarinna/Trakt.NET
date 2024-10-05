namespace TraktNET
{
    public static class TestConstants
    {
        public const string ClientId = "traktClientId";
        public const string ClientSecret = "traktClientSecret";
        public const string MockAccessToken = "mockAccessToken";

        public static readonly TraktAuthorization MockAuthorization =
            new()
            {
                CreatedAt = (ulong)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                AccessToken = MockAccessToken,
                ExpiresIn = 3600
            };

        public static class Movies
        {
            public const uint MovieID = 293990;

            public const string MovieSlug = "guardians-of-the-galaxy-volume-3-2023";

            public static readonly TraktMovieIds MovieIds = new()
            {
                Trakt = 293990,
                Slug = "guardians-of-the-galaxy-volume-3-2023",
                IMDB = "tt6791350",
                TMDB = 447365
            };

            public static readonly TraktFilter Filter = new()
            {
                Genres = ["action", "drama"],
                Year = 2024
            };
        }

        public static class Shows
        {
            public const string ShowID = "game-of-thrones";
        }
    }
}

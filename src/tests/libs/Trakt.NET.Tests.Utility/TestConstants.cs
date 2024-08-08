namespace TraktNET
{
    public static class TestConstants
    {
        public const string ClientId = "traktClientId";
        public const string ClientSecret = "traktClientSecret";

        public static class Movies
        {
            public const string MovieID = "guardians-of-the-galaxy-volume-3-2023";

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

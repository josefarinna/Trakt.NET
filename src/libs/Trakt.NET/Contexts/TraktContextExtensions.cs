namespace TraktNET
{
    public static class TraktContextExtensions
    {
        public static TraktAuthModule Auth(this TraktContext context) => new(context);

        public static TraktCalendarModule Calendar(this TraktContext context) => new(context);

        public static TraktCheckinsModule Checkins(this TraktContext context) => new(context);

        public static TraktCommentsModule Comments(this TraktContext context) => new(context);

        public static TraktCountriesModule Countries(this TraktContext context) => new(context);

        public static TraktEpisodesModule Episodes(this TraktContext context) => new(context);

        public static TraktGenresModule Genres(this TraktContext context) => new(context);

        public static TraktLanguagesModule Languages(this TraktContext context) => new(context);

        public static TraktListsModule Lists(this TraktContext context) => new(context);

        public static TraktMoviesModule Movies(this TraktContext context) => new(context);

        public static TraktNetworksModule Networks(this TraktContext context) => new(context);

        public static TraktPeopleModule People(this TraktContext context) => new(context);

        public static TraktRecommendationsModule Recommendations(this TraktContext context) => new(context);

        public static TraktScrobbleModule Scrobble(this TraktContext context) => new(context);

        public static TraktSearchModule Search(this TraktContext context) => new(context);

        public static TraktSeasonsModule Seasons(this TraktContext context) => new(context);

        public static TraktShowsModule Shows(this TraktContext context) => new(context);

        public static TraktSyncModule Sync(this TraktContext context) => new(context);

        public static TraktUsersModule Users(this TraktContext context) => new(context);
    }
}

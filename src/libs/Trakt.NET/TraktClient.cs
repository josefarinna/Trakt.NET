namespace TraktNET
{
    /// <summary>
    /// Provides access to all functionality of this library.<para/>
    /// Provides the only access to all of the library's modules.
    /// </summary>
    public sealed class TraktClient
    {
        /// <summary>Gets the context of the Trakt Client. See also <seealso cref="TraktContext" />.</summary>
        public TraktContext Context { get; }

        /// <summary>Gets or sets the Trakt Client Id. See also <seealso cref="ClientSecret" />.</summary>
        public string ClientID
        {
            get => Context.ClientID;
            set => Context.ClientID = value;
        }

        /// <summary>Gets or sets the Trakt Client Secret. See also <seealso cref="ClientID" />.</summary>
        public string ClientSecret
        {
            get => Context.ClientSecret;
            set => Context.ClientSecret = value;
        }

        public TraktAuthorization Authorization
        {
            get => Context.Authorization;
            set => Context.Authorization = value ?? new TraktAuthorization();
        }

        /// <summary>Provides access to the authentication module. See <seealso cref="TraktAuthModule" />.</summary>
        public TraktAuthModule Auth => Context.Auth;

        /// <summary>Provides access to the calendar module. See <seealso cref="TraktCalendarModule" />.</summary>
        public TraktCalendarModule Calendar => Context.Calendar;

        /// <summary>Provides access to the certifications module. See <seealso cref="TraktCertificationsModule" />.</summary>
        public TraktCertificationsModule Certifications => Context.Certifications;

        /// <summary>Provides access to the checkins module. See <seealso cref="TraktCheckinsModule" />.</summary>
        public TraktCheckinsModule Checkins => Context.Checkins;

        /// <summary>Provides access to the commends module. See <seealso cref="TraktCommentsModule" />.</summary>
        public TraktCommentsModule Comments => Context.Comments;

        /// <summary>Provides access to the countries module. See <seealso cref="TraktCountriesModule" />.</summary>
        public TraktCountriesModule Countries => Context.Countries;

        /// <summary>Provides access to the episodes module. See <seealso cref="TraktEpisodesModule" />.</summary>
        public TraktEpisodesModule Episodes => Context.Episodes;

        /// <summary>Provides access to the genres module. See <seealso cref="TraktGenresModule" />.</summary>
        public TraktGenresModule Genres => Context.Genres;

        /// <summary>Provides access to the languages module. See <seealso cref="TraktLanguagesModule" />.</summary>
        public TraktLanguagesModule Languages => Context.Languages;

        /// <summary>Provides access to the lists module. See <seealso cref="TraktListsModule" />.</summary>
        public TraktListsModule Lists => Context.Lists;

        /// <summary>Provides access to the movies module. See <seealso cref="TraktMoviesModule" />.</summary>
        public TraktMoviesModule Movies => Context.Movies;

        /// <summary>Provides access to the networks module. See <seealso cref="TraktNetworksModule" />.</summary>
        public TraktNetworksModule Networks => Context.Networks;

        /// <summary>Provides access to the notes module. See <seealso cref="TraktNotesModule" />.</summary>
        public TraktNotesModule Notes => Context.Notes;

        /// <summary>Provides access to the people module. See <seealso cref="TraktPeopleModule" />.</summary>
        public TraktPeopleModule People => Context.People;

        /// <summary>Provides access to the recommendations module. See <seealso cref="TraktRecommendationsModule" />.</summary>
        public TraktRecommendationsModule Recommendations => Context.Recommendations;

        /// <summary>Provides access to the scrobble module. See <seealso cref="TraktScrobbleModule" />.</summary>
        public TraktScrobbleModule Scrobble => Context.Scrobble;

        /// <summary>Provides access to the search module. See <seealso cref="TraktSearchModule" />.</summary>
        public TraktSearchModule Search => Context.Search;

        /// <summary>Provides access to the seasons module. See <seealso cref="TraktSeasonsModule" />.</summary>
        public TraktSeasonsModule Seasons => Context.Seasons;

        /// <summary>Provides access to the shows module. See <seealso cref="TraktShowsModule" />.</summary>
        public TraktShowsModule Shows => Context.Shows;

        /// <summary>Provides access to the sync module. See <seealso cref="TraktSyncModule" />.</summary>
        public TraktSyncModule Sync => Context.Sync;

        /// <summary>Provides access to the users module. See <seealso cref="TraktUsersModule" />.</summary>
        public TraktUsersModule Users => Context.Users;

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="clientID">The Trakt Client Id. See <seealso cref="ClientID" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret. See <seealso cref="ClientSecret" />.</param>
        public TraktClient(string clientID, string clientSecret)
            : this(new TraktDefaultContext(clientID, clientSecret))
        { }

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="context">The context of Trakt Client. See <seealso cref="Context" />.</param>
        public TraktClient(TraktContext context)
        {
            ArgumentValidator.ThrowIfNull(context);
            Context = context;
        }
    }
}

namespace TraktNET
{
    /// <summary>
    /// Provides access to all functionality of this library.<para/>
    /// Provides the only access to all of the library's modules.
    /// </summary>
    public sealed partial class TraktClient
    {
        /// <summary>Gets or sets the Trakt Client ID. See also <seealso cref="ClientSecret" />.</summary>
        public string ClientID
        {
            get => _context.ClientID;
            set => _context.ClientID = value;
        }

        /// <summary>Gets or sets the Trakt Client Secret. See also <seealso cref="ClientID" />.</summary>
        public string ClientSecret
        {
            get => _context.ClientSecret;
            set => _context.ClientSecret = value;
        }

        /// <summary>Gets or sets the Trakt Authorization information. See also <seealso cref="TraktAuthorization" />.</summary>
        public TraktAuthorization? Authorization
        {
            get => _context.Authorization;
            set => _context.Authorization = value;
        }

        /// <summary>Gets or sets the OAuth authorization code.</summary>
        public string? OAuthAuthorizationCode
        {
            get => _context.OAuthAuthorizationCode;
            set => _context.OAuthAuthorizationCode = value;
        }

        /// <summary>Gets or sets the Trakt Device information /> for Device authentication. See also<see cref="TraktDevice" />.</summary>
        public TraktDevice? Device
        {
            get => _context.Device;
            set => _context.Device = value;
        }

        /// <summary>Gets a GUID, which can be used for OAuth authentication requests.</summary>
        public string AntiForgeryToken => _context.AntiForgeryToken;

        /// <summary>Gets or sets, whether authorization should be ignored, if it is optional. This is disabled by default.</summary>
        public bool IgnoreOAuthIfOptional
        {
            get => _context.IgnoreOAuthIfOptional;
            set => _context.IgnoreOAuthIfOptional = value;
        }

        /// <summary>Gets or sets the User Agent that will be used in all API requests.</summary>
        public string UserAgent
        {
            get => _context.UserAgent;
            set => _context.UserAgent = value;
        }

        /// <summary>Provides access to the authentication module. See <seealso cref="TraktAuthModule" />.</summary>
        public TraktAuthModule Auth => _context.Auth;

        /// <summary>Provides access to the calendar module. See <seealso cref="TraktCalendarModule" />.</summary>
        public TraktCalendarModule Calendar => _context.Calendar;

        /// <summary>Provides access to the certifications module. See <seealso cref="TraktCertificationsModule" />.</summary>
        public TraktCertificationsModule Certifications => _context.Certifications;

        /// <summary>Provides access to the checkins module. See <seealso cref="TraktCheckinsModule" />.</summary>
        public TraktCheckinsModule Checkins => _context.Checkins;

        /// <summary>Provides access to the commends module. See <seealso cref="TraktCommentsModule" />.</summary>
        public TraktCommentsModule Comments => _context.Comments;

        /// <summary>Provides access to the countries module. See <seealso cref="TraktCountriesModule" />.</summary>
        public TraktCountriesModule Countries => _context.Countries;

        /// <summary>Provides access to the episodes module. See <seealso cref="TraktEpisodesModule" />.</summary>
        public TraktEpisodesModule Episodes => _context.Episodes;

        /// <summary>Provides access to the genres module. See <seealso cref="TraktGenresModule" />.</summary>
        public TraktGenresModule Genres => _context.Genres;

        /// <summary>Provides access to the languages module. See <seealso cref="TraktLanguagesModule" />.</summary>
        public TraktLanguagesModule Languages => _context.Languages;

        /// <summary>Provides access to the lists module. See <seealso cref="TraktListsModule" />.</summary>
        public TraktListsModule Lists => _context.Lists;

        /// <summary>Provides access to the movies module. See <seealso cref="TraktMoviesModule" />.</summary>
        public TraktMoviesModule Movies => _context.Movies;

        /// <summary>Provides access to the networks module. See <seealso cref="TraktNetworksModule" />.</summary>
        public TraktNetworksModule Networks => _context.Networks;

        /// <summary>Provides access to the notes module. See <seealso cref="TraktNotesModule" />.</summary>
        public TraktNotesModule Notes => _context.Notes;

        /// <summary>Provides access to the people module. See <seealso cref="TraktPeopleModule" />.</summary>
        public TraktPeopleModule People => _context.People;

        /// <summary>Provides access to the recommendations module. See <seealso cref="TraktRecommendationsModule" />.</summary>
        public TraktRecommendationsModule Recommendations => _context.Recommendations;

        /// <summary>Provides access to the scrobble module. See <seealso cref="TraktScrobbleModule" />.</summary>
        public TraktScrobbleModule Scrobble => _context.Scrobble;

        /// <summary>Provides access to the search module. See <seealso cref="TraktSearchModule" />.</summary>
        public TraktSearchModule Search => _context.Search;

        /// <summary>Provides access to the seasons module. See <seealso cref="TraktSeasonsModule" />.</summary>
        public TraktSeasonsModule Seasons => _context.Seasons;

        /// <summary>Provides access to the shows module. See <seealso cref="TraktShowsModule" />.</summary>
        public TraktShowsModule Shows => _context.Shows;

        /// <summary>Provides access to the sync module. See <seealso cref="TraktSyncModule" />.</summary>
        public TraktSyncModule Sync => _context.Sync;

        /// <summary>Provides access to the watchnow module. See <seealso cref="TraktWatchnowModule" />.</summary>
        public TraktWatchnowModule Watchnow => _context.Watchnow;

        /// <summary>Provides access to the users module. See <seealso cref="TraktUsersModule" />.</summary>
        public TraktUsersModule Users => _context.Users;

        /// <summary>
        /// Create the a <see cref="TraktClient" /> with the given <paramref name="clientID" /> and <paramref name="clientSecret" />.
        /// </summary>
        /// <param name="clientID">The Trakt Client ID to be used in the <see cref="TraktClient" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret to be used in the <see cref="TraktClient" />.</param>
        /// <param name="userAgent">The User Agent to be used in the <see cref="TraktClient" />.</param>
        /// <returns>A <see cref="TraktClient" /> instance.</returns>
        public static TraktClient Create(string clientID, string clientSecret, string? userAgent = null) => new(new TraktDefaultContext(clientID, clientSecret, userAgent));

        /// <summary>
        /// Create the a <see cref="TraktClient" /> with the given <paramref name="clientID" /> and <paramref name="clientSecret" />.
        /// <para />
        /// The created <see cref="TraktClient" /> uses Trakt's sandbox environment.
        /// </summary>
        /// <param name="clientID">The Trakt Client ID to be used in the <see cref="TraktClient" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret to be used in the <see cref="TraktClient" />.</param>
        /// <param name="userAgent">The User Agent to be used in the <see cref="TraktClient" />.</param>
        /// <returns>A <see cref="TraktClient" /> instance.</returns>
        public static TraktClient CreateForSandbox(string clientID, string clientSecret, string? userAgent = null) => new(new TraktSandboxContext(clientID, clientSecret, userAgent));

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="clientID">The Trakt Client ID. See <seealso cref="ClientID" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret. See <seealso cref="ClientSecret" />.</param>
        /// <param name="userAgent">The User Agent that will be used in all API requests.</param>
        public TraktClient(string clientID, string clientSecret, string? userAgent = null)
            : this(new TraktDefaultContext(clientID, clientSecret, userAgent))
        {
        }
    }
}

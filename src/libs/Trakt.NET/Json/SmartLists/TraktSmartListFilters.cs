namespace TraktNET
{
    /// <summary>Filter constraints applied to the source of a smart list.</summary>
    public record class TraktSmartListFilters
    {
        /// <summary>Genre slugs.</summary>
        public string[]? Genres { get; set; }

        /// <summary>
        /// Gets or sets the logical operator for genre filtering.
        /// See also <seealso cref="TraktFilterOperator" />.
        /// </summary>
        public TraktFilterOperator? GenresOperator { get; set; }

        /// <summary>Subgenre slugs.</summary>
        public string[]? Subgenres { get; set; }

        /// <summary>Content certifications.</summary>
        public string[]? Certifications { get; set; }

        /// <summary>2-character language codes.</summary>
        public string[]? Languages { get; set; }

        /// <summary>2-character country codes.</summary>
        public string[]? Countries { get; set; }

        /// <summary>Collection of show statuses.</summary>
        public string[]? Statuses { get; set; }

        /// <summary>Collection of network names/IDs.</summary>
        public string[]? Networks { get; set; }

        /// <summary>Collection of keywords.</summary>
        public string[]? Keywords { get; set; }

        /// <summary>
        /// Gets or sets the logical operator for keyword filtering.
        /// See also <seealso cref="TraktFilterOperator" />.
        /// </summary>
        public TraktFilterOperator? KeywordsOperator { get; set; }

        /// <summary>Collection of watchnow streaming service options.</summary>
        public string[]? Watchnow { get; set; }

        /// <summary>2-character country code for watchnow.</summary>
        public string? WatchnowCountry { get; set; }

        /// <summary>Year range [min, max]. Max 2 items.</summary>
        public uint[]? Years { get; set; }

        /// <summary>Ratings range [min, max]. Max 2 items.</summary>
        public uint[]? Ratings { get; set; }

        /// <summary>Runtimes range in minutes [min, max]. Max 2 items.</summary>
        public uint[]? Runtimes { get; set; }

        /// <summary>IMDb ratings range [min, max]. Max 2 items.</summary>
        public float[]? ImdbRatings { get; set; }

        /// <summary>Rotten Tomatoes tomatometer range [min, max]. Max 2 items.</summary>
        public uint[]? RtMeters { get; set; }

        /// <summary>Rotten Tomatoes audience score range [min, max]. Max 2 items.</summary>
        public uint[]? RtUserMeters { get; set; }

        /// <summary>Letterboxd ratings range [min, max]. Max 2 items.</summary>
        public float[]? LetterboxdRatings { get; set; }

        /// <summary>MyAnimeList ratings range [min, max]. Max 2 items.</summary>
        public float[]? MalRatings { get; set; }

        /// <summary>Parental guide nudity severity range [min, max] from 0 (none) to 3 (severe). Max 2 items.</summary>
        public uint[]? ParentalNudity { get; set; }

        /// <summary>Parental guide violence severity range [min, max] from 0 (none) to 3 (severe). Max 2 items.</summary>
        public uint[]? ParentalViolence { get; set; }

        /// <summary>Parental guide profanity severity range [min, max] from 0 (none) to 3 (severe). Max 2 items.</summary>
        public uint[]? ParentalProfanity { get; set; }

        /// <summary>Parental guide alcohol severity range [min, max] from 0 (none) to 3 (severe). Max 2 items.</summary>
        public uint[]? ParentalAlcohol { get; set; }

        /// <summary>Parental guide frightening severity range [min, max] from 0 (none) to 3 (severe). Max 2 items.</summary>
        public uint[]? ParentalFrightening { get; set; }

        /// <summary>Gets or sets whether to keep titles without a parental guide when a parental range is set.</summary>
        public bool? ParentalIncludeUnrated { get; set; }

        /// <summary>Gets or sets whether watched items should be ignored.</summary>
        public bool? IgnoreWatched { get; set; }

        /// <summary>Gets or sets whether watchlisted items should be ignored.</summary>
        public bool? IgnoreWatchlisted { get; set; }

        /// <summary>Gets or sets whether currently watching items should be ignored.</summary>
        public bool? IgnoreWatching { get; set; }

        /// <summary>Gets or sets whether unreleased items should be ignored.</summary>
        public bool? IgnoreUnreleased { get; set; }

        /// <summary>Gets or sets whether released items should be ignored.</summary>
        public bool? IgnoreReleased { get; set; }

        /// <summary>Gets or sets whether ended items should be ignored.</summary>
        public bool? IgnoreEnded { get; set; }

        /// <summary>Gets or sets whether currently airing items should be ignored.</summary>
        public bool? IgnoreAiring { get; set; }

        /// <summary>Gets or sets whether items without a release date should be ignored.</summary>
        public bool? IgnoreNoReleaseDate { get; set; }

        /// <summary>Studio slugs.</summary>
        public string[]? Studios { get; set; }

        /// <summary>Person slugs or Trakt IDs.</summary>
        public string[]? People { get; set; }

        /// <summary>
        /// Gets or sets the logical operator for people filtering.
        /// See also <seealso cref="TraktFilterOperator" />.
        /// </summary>
        public TraktFilterOperator? PeopleOperator { get; set; }

        /// <summary>
        /// Gets or sets the role for people filtering.
        /// See also <seealso cref="TraktPeopleRole" />.
        /// </summary>
        public TraktPeopleRole? PeopleRole { get; set; }

        /// <summary>Number of days within which items were released.</summary>
        public uint? ReleasedWithinDays { get; set; }

        /// <summary>TMDb ratings range [min, max]. Max 2 items.</summary>
        public float[]? TmdbRatings { get; set; }

        /// <summary>Metascore range [min, max]. Max 2 items.</summary>
        public uint[]? Metascores { get; set; }

        /// <summary>Trakt votes range [min, max]. Max 2 items.</summary>
        public uint[]? Votes { get; set; }

        /// <summary>IMDb votes range [min, max]. Max 2 items.</summary>
        public uint[]? ImdbVotes { get; set; }
    }
}



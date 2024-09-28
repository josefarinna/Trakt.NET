namespace TraktNET
{
    /// <summary>A release of a Trakt movie.</summary>
    public record class TraktMovieRelease
    {
        /// <summary>The two letter country code for the movie release.</summary>
        public string? Country { get; set; }

        /// <summary>The content certification for the movie release.</summary>
        public string? Certification { get; set; }

#if NET7_0_OR_GREATER
        /// <summary>The date of the movie release.</summary>
        public DateOnly? ReleaseDate { get; set; }
#else
        /// <summary>The UTC datetime of the movie release.</summary>
        public DateTime? ReleaseDate { get; set; }
#endif

        /// <summary>The release type for the movie release. See also <seealso cref="TraktReleaseType" />.</summary>
        public TraktReleaseType? ReleaseType { get; set; }

        /// <summary>A note for the movie release.</summary>
        public string? Note { get; set; }
    }
}

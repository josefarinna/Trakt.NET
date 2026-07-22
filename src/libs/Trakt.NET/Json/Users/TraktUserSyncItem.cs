namespace TraktNET
{
    /// <summary>Represents a paused or skipped item in a data sync.</summary>
    public record class TraktUserSyncItem
    {
        /// <summary>Gets or sets the item kind.</summary>
        public TraktUserSyncItemKind? Kind { get; set; }

        /// <summary>Gets or sets the media type.</summary>
        public TraktSyncItemType? Type { get; set; }

        /// <summary>Gets or sets the movie object if <see cref="Type" /> is movie.</summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>Gets or sets the show object if <see cref="Type" /> is show.</summary>
        public TraktShow? Show { get; set; }

        /// <summary>Gets or sets the season object if <see cref="Type" /> is season.</summary>
        public TraktSeason? Season { get; set; }

        /// <summary>Gets or sets the episode object if <see cref="Type" /> is episode.</summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>Gets or sets the service ID.</summary>
        public string? ServiceId { get; set; }

        /// <summary>Gets or sets the content ID.</summary>
        public string? ContentId { get; set; }

        /// <summary>Gets or sets the profile ID.</summary>
        public string? ProfileId { get; set; }

        /// <summary>Gets or sets the TMDB ID.</summary>
        public uint? TmdbId { get; set; }

        /// <summary>Gets or sets the TMDB series ID.</summary>
        public uint? TmdbSeriesId { get; set; }

        /// <summary>Gets or sets the UTC datetime when watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime when rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the playback progress percentage.</summary>
        public float? Progress { get; set; }

        /// <summary>Gets or sets the rating type.</summary>
        public string? RatingType { get; set; }

        /// <summary>Gets or sets the rating value.</summary>
        public uint? RatingValue { get; set; }
    }
}

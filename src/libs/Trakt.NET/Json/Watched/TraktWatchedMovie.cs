namespace TraktNET
{
    /// <summary>Contains information about a watched Trakt movie.</summary>
    public record class TraktWatchedMovie : TraktCollectionMovie
    {
        /// <summary>Gets or sets the number of plays for the watched movie.</summary>
        public uint? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie was last watched.</summary>
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie was last updated.</summary>
        public DateTime? LastUpdatedAt { get; set; }
    }
}

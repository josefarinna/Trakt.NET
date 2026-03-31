namespace TraktNET
{
    /// <summary>Contains information about a watched Trakt show.</summary>
    public record class TraktWatchedShow : TraktCollectionShow
    {
        /// <summary>Gets or sets the number of plays for the watched show.</summary>
        public uint? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was last watched.</summary>
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was last updated.</summary>
        public DateTime? LastUpdatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was resetted.</summary>
        public DateTime? ResetAt { get; set; }

        /// <summary>Gets or sets a list of watched seasons in the watched show. See also <seealso cref="TraktWatchedShowSeason" />.</summary>
        public List<TraktWatchedShowSeason>? Seasons { get; set; }
    }
}

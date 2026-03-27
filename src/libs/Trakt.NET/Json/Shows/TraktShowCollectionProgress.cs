namespace TraktNET
{
    /// <summary>Represents the collection progress of a Trakt show.</summary>
    public record class TraktShowCollectionProgress : TraktShowProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last collection occured.</summary>
        public DateTime? LastCollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected seasons. See also <seealso cref="TraktSeasonCollectionProgress" />.
        /// </summary>
        public List<TraktSeasonCollectionProgress>? Seasons { get; set; }
    }
}

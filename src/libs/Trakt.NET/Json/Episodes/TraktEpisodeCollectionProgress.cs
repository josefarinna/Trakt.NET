namespace TraktNET
{
    /// <summary>Represents the collection progress of a Trakt episode.</summary>
    public record class TraktEpisodeCollectionProgress : TraktEpisodeProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the episode was collected.</summary>
        public DateTime? LastWatchedAt { get; set; }
    }
}

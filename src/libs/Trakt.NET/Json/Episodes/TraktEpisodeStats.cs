namespace TraktNET
{
    /// <summary>Represents playback and viewing statistics for a Trakt episode.</summary>
    public record class TraktEpisodeStats
    {
        /// <summary>Gets or sets the total number of times the episode has been played.</summary>
        public uint? PlayCount { get; set; }

        /// <summary>Gets or sets the total number of minutes watched for the episode.</summary>
        public uint? MinutesWatched { get; set; }
    }
}

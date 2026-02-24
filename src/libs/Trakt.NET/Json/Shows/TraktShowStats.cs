namespace TraktNET
{
    /// <summary>Represents playback and viewing statistics for a Trakt show.</summary>
    public record class TraktShowStats
    {
        /// <summary>Gets or sets the total number of times the show has been played.</summary>
        public uint? PlayCount { get; set; }

        /// <summary>Gets or sets the total number of minutes watched for the show.</summary>
        public uint? MinutesWatched { get; set; }

        /// <summary>Gets or sets the number of minutes remaining to complete the show based on aired episodes.</summary>
        public uint? MinutesLeft { get; set; }
    }
}

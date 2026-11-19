namespace TraktNET
{
    /// <summary>Represents playback and viewing statistics for a Trakt season.</summary>
    public record class TraktSeasonStats
    {
        /// <summary>Gets or sets the total number of times the season has been played.</summary>
        public uint? PlayCount { get; set; }

        /// <summary>Gets or sets the total number of minutes watched for the season.</summary>
        public uint? MinutesWatched { get; set; }

        /// <summary>Gets or sets the number of minutes remaining to complete the season based on aired episodes.</summary>
        /// <remarks>Trakt can return a negative value when the watched minutes exceed the runtime of the aired episodes.</remarks>
        public int? MinutesLeft { get; set; }
    }
}

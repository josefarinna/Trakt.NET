namespace TraktNET
{
    /// <summary>Represents the watched progress of a Trakt season.</summary>
    public record class TraktSeasonWatchedProgress : TraktSeasonProgress
    {
        /// <summary>Gets or sets the stats about a Trakt season.</summary>
        public TraktSeasonStats? Stats { get; set; }

        /// <summary>
        /// Gets or sets the watched episodes. See also <seealso cref="TraktEpisodeWatchedProgress" />.
        /// </summary>
        public List<TraktEpisodeWatchedProgress>? Episodes { get; set; }
    }
}

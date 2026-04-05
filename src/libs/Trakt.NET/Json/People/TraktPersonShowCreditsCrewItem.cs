namespace TraktNET
{
    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public record class TraktPersonShowCreditsCrewItem
    {
        /// <summary>Gets or sets the job of the crew position.</summary>
        public string? Job { get; set; }

        /// <summary>Gets or sets the jobs collection of the crew position.</summary>
        public List<string>? Jobs { get; set; }

        /// <summary>Gets or sets the episode count of the crew position.</summary>
        public uint? EpisodeCount { get; set; }

        /// <summary>Gets or sets the series regular of the crew position.</summary>
        public bool? SeriesRegular { get; set; }

        /// <summary>
        /// Gets or sets the show of the crew position. See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }
    }
}

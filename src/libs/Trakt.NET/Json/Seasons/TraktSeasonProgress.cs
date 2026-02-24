namespace TraktNET
{
    /// <summary>Represents the progress of a Trakt season.</summary>
    public record class TraktSeasonProgress
    {
        /// <summary>Gets or sets the number of the collected or watched season.</summary>
        public uint? Number { get; set; }

        /// <summary>
        /// Gets or sets the title of the season.
        /// <para>Nullable</para>
        /// </summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the number of episodes in the season, which already aired.</summary>
        public uint? Aired { get; set; }

        /// <summary>Gets or sets the number of episodes in the season already collected or watched.</summary>
        public uint? Completed { get; set; }
    }
}

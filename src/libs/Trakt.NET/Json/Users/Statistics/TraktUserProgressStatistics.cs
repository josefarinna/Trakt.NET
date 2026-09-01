namespace TraktNET
{
    /// <summary>A collection of Trakt user statistics for progress.</summary>
    public record class TraktUserProgressStatistics
    {
        /// <summary>Gets or sets the number of items an user has started.</summary>
        public uint? Started { get; set; }

        /// <summary>Gets or sets the number of items an user has finished.</summary>
        public uint? Finished { get; set; }

        /// <summary>Gets or sets the number of items an user has dropped.</summary>
        public uint? Dropped { get; set; }
    }
}

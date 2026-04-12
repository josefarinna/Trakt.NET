namespace TraktNET
{
    /// <summary>A collection of Trakt user statistics for shows.</summary>
    public record class TraktUserShowsStatistics
    {
        /// <summary>Gets or sets the number of how many shows an user has watched.</summary>
        public uint? Watched { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has collected.</summary>
        public uint? Collected { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has rated.</summary>
        public uint? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has commented.</summary>
        public uint? Comments { get; set; }
    }
}

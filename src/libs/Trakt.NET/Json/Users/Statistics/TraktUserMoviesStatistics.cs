namespace TraktNET
{
    /// <summary>A collection of Trakt user statistics for movies.</summary>
    public record class TraktUserMoviesStatistics
    {
        /// <summary>Gets or sets the number of how many times an user has played movies.</summary>
        public uint? Plays { get; set; }

        /// <summary>Gets or sets the number of how many movies an user has watched.</summary>
        public uint? Watched { get; set; }

        /// <summary>Gets or sets the number of minutes that an user has watched movies.</summary>
        public uint? Minutes { get; set; }

        /// <summary>Gets or sets the number of how many movies an user has collected.</summary>
        public uint? Collected { get; set; }

        /// <summary>Gets or sets the number of how many movies an user has rated.</summary>
        public uint? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many movies an user has commented.</summary>
        public uint? Comments { get; set; }
    }
}

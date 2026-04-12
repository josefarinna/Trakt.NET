namespace TraktNET
{
    /// <summary>A collection of Trakt user statistics for seasons.</summary>
    public record class TraktUserSeasonsStatistics
    {
        /// <summary>Gets or sets the number of how many seasons an user has rated.</summary>
        public uint? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many seasons an user has commented.</summary>
        public uint? Comments { get; set; }
    }
}

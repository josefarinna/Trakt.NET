namespace TraktNET
{
    /// <summary>A collection of Trakt user statistics for ratings.</summary>
    public record class TraktUserRatingsStatistics
    {
        /// <summary>Gets or sets the total number of items an user has rated.</summary>
        public uint? Total { get; set; }

        /// <summary>Gets or sets the rating distribution of an user's ratings.</summary>
        public Dictionary<string, uint>? Distribution { get; set; }
    }
}

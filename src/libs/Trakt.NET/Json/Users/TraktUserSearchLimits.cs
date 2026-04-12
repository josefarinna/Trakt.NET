namespace TraktNET
{
    /// <summary>A collection of Trakt user search limits.</summary>
    public record class TraktUserSearchLimits
    {
        /// <summary>Gets or sets the number of recent search items.</summary>
        public uint? RecentCount { get; set; }
    }
}

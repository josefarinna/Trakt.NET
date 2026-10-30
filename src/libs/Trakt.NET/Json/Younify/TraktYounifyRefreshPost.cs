namespace TraktNET
{
    /// <summary>Represents the optional payload to refresh a Younify streaming connection.</summary>
    public record class TraktYounifyRefreshPost
    {
        /// <summary>
        /// Gets or sets whether to only mark the service as synced now, so history from before this moment is ignored.
        /// </summary>
        public bool? SkipSync { get; set; }
    }
}

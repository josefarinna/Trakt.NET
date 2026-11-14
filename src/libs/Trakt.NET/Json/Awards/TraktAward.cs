namespace TraktNET
{
    /// <summary>An award.</summary>
    public record class TraktAward
    {
        /// <summary>Gets or sets the award slug.</summary>
        public string? Slug { get; set; }

        /// <summary>Gets or sets the award name.</summary>
        public string? Name { get; set; }
    }
}

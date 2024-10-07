namespace TraktNET
{
    /// <summary>A Trakt certification.</summary>
    public record class TraktCertification
    {
        /// <summary>The certification name.</summary>
        public string? Name { get; set; }

        /// <summary>The certification slug.</summary>
        public string? Slug { get; set; }

        /// <summary>The certification description.</summary>
        public string? Description { get; set; }
    }
}

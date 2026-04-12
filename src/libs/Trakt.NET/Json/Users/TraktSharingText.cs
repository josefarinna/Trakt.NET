namespace TraktNET
{
    /// <summary>Represents Trakt user social media sharing text settings.</summary>
    public record class TraktSharingText
    {
        /// <summary>Gets or sets the user's sharing text for watching an item.</summary>
        public string? Watching { get; set; }

        /// <summary>Gets or sets the user's sharing text for watched items.</summary>
        public string? Watched { get; set; }

        /// <summary>Gets or sets the user's sharing text for rated items.</summary>
        public string? Rated { get; set; }
    }
}

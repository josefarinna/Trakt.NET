namespace TraktNET
{
    /// <summary>Represents image links for a watch now source.</summary>
    public record class TraktWatchnowSourceImages
    {
        /// <summary>Gets or sets the logo image URL.</summary>
        public string? Logo { get; set; }

        /// <summary>Gets or sets the channel image URL.</summary>
        public string? Channel { get; set; }
    }
}

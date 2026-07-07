namespace TraktNET
{
    /// <summary>Represents a watch now source supported by Trakt.</summary>
    public record class TraktWatchnowSource
    {
        /// <summary>Gets or sets the source identifier.</summary>
        public string? Source { get; set; }

        /// <summary>Gets or sets the display name of the source.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets whether the source is free.</summary>
        public bool Free { get; set; }

        /// <summary>Gets or sets whether the source is a cinema release.</summary>
        public bool Cinema { get; set; }

        /// <summary>Gets or sets whether the source is hosted on Amazon.</summary>
        public bool Amazon { get; set; }

        /// <summary>Gets or sets the theme color of the source.</summary>
        public string? Color { get; set; }

        /// <summary>Gets or sets the number of links available for this source.</summary>
        public int LinkCount { get; set; }

        /// <summary>Gets or sets the logo/channel images for the source.</summary>
        public TraktWatchnowSourceImages? Images { get; set; }
    }
}

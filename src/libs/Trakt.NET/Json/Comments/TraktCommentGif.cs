namespace TraktNET
{
    /// <summary>Represents a GIF attached to a comment.</summary>
    public record class TraktCommentGif
    {
        /// <summary>The URL of the GIF.</summary>
        public string? Url { get; set; }

        /// <summary>The intrinsic width in pixels of the GIF.</summary>
        public uint? Width { get; set; }

        /// <summary>The intrinsic height in pixels of the GIF.</summary>
        public uint? Height { get; set; }
    }
}

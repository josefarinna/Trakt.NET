namespace TraktNET
{
    /// <summary>Represents a GIF attached to a comment.</summary>
    public record class TraktCommentGif
    {
        /// <summary>The URL of the GIF.</summary>
        public string? Url { get; set; }

        /// <summary>The Klipy slug of the GIF.</summary>
        public string? Slug { get; set; }
    }
}

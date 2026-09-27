using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A comment update post.</summary>
    public record class TraktCommentUpdatePost
    {
        /// <summary>Gets or sets the comment's content.</summary>
        public string? Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        public bool? Spoiler { get; set; }

        /// <summary>Gets or sets the URL of a GIF to attach to the comment.</summary>
        public string? Gif { get; set; }

        /// <summary>Gets or sets the intrinsic width in pixels of the GIF attached to the comment.</summary>
        [JsonPropertyName("gif_width")]
        public uint? GifWidth { get; set; }

        /// <summary>Gets or sets the intrinsic height in pixels of the GIF attached to the comment.</summary>
        [JsonPropertyName("gif_height")]
        public uint? GifHeight { get; set; }

        public virtual void Validate()
        {
            if (string.IsNullOrWhiteSpace(Gif))
            {
                if (Comment == null)
                    throw new TraktPostValidationException(nameof(Comment), "comment must not be null");

                if (Comment.WordCount() < 5)
                    throw new TraktPostValidationException(nameof(Comment), "comment has too few words - at least five words are required");
            }
        }
    }
}

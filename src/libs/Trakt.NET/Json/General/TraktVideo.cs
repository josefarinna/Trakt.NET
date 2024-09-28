namespace TraktNET
{
    /// <summary>A Trakt video item.</summary>
    public record class TraktVideo
    {
        /// <summary>The title of the video item.</summary>
        public string? Title { get; set; }

        /// <summary>The URL of the video item.</summary>
        public string? Url { get; set; }

        /// <summary>The site where the video is hosted.</summary>
        public string? Site { get; set; }

        /// <summary>The type of the video item. See also <seealso cref="TraktVideoType" />.</summary>
        public TraktVideoType? Type { get; set; }

        /// <summary>The resolution size of the video item.</summary>
        public uint? Size { get; set; }

        /// <summary>The flag whether the video item is from an official source.</summary>
        public bool? Official { get; set; }

        /// <summary>The UTC datetime when the video item was published.</summary>
        public DateTime? PublishedAt { get; set; }

        /// <summary>The two character country code of the video item.</summary>
        public string? Country { get; set; }

        /// <summary>The two character language code of the video item.</summary>
        public string? Language { get; set; }
    }
}

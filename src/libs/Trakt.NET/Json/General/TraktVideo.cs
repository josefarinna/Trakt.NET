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

        /// <summary>Gets the culture name of the video item.</summary>
        /// <returns>The culture name of the video item.</returns>
        public string CultureName()
        {
            if (!string.IsNullOrEmpty(Language) && !string.IsNullOrEmpty(Country))
            {
                return $"{Language}-{Country!.ToUpperInvariant()}";
            }

            return string.Empty;
        }

        /// <summary>Gets a string representation of the video item.</summary>
        /// <returns>A string representation of the video item.</returns>
        public override string ToString()
        {
            string type = string.Empty;
            string title = string.Empty;

            if (Type.HasValue && Type.Value != TraktVideoType.Unspecified)
            {
                type = Type.Value.DisplayName();
            }

            if (!string.IsNullOrEmpty(Title))
            {
                title = Title!;
            }

            if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(title))
            {
                return $"{type}: {title}";
            }

            return title;
        }
    }
}

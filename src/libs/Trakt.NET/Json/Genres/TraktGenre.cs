namespace TraktNET
{
    /// <summary>A Trakt genre.</summary>
    public record class TraktGenre
    {
        /// <summary>Gets or sets the genre name.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the Trakt slug of the genre.</summary>
        public string? Slug { get; set; }

        /// <summary>Gets or sets the Trakt subgenres.</summary>
        public List<TraktSubgenre>? Subgenres { get; set; }

        /// <summary>Gets or sets the genre type. See also <seealso cref="TraktGenreType" />.</summary>
        public TraktGenreType? Type { get; set; }

        /// <summary>Returns a string representation of the genre.</summary>
        /// <returns>The name of the genre if it exists; otherwise, a placeholder.</returns>
        public override string ToString()
        {
            string name = string.IsNullOrEmpty(Name) ? "name not set" : Name!;
            string slug = string.IsNullOrEmpty(Slug) ? "slug not set" : Slug!;
            return $"{name}, {slug}";
        }
    }
}

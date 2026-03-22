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
        /// <returns>The name of the genre if it exists; otherwise, an empty string.</returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return Name!;
            }

            return string.Empty;
        }
    }
}

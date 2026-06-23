namespace TraktNET
{
    /// <summary>A Trakt subgenre.</summary>
    public record class TraktSubgenre
    {
        /// <summary>Gets or sets the subgenre name.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the Trakt slug of the subgenre.</summary>
        public string? Slug { get; set; }

        /// <summary>Returns a string representation of the subgenre.</summary>
        /// <returns>The name of the subgenre if it exists; otherwise, a placeholder.</returns>
        public override string ToString()
        {
            string name = string.IsNullOrEmpty(Name) ? "name not set" : Name!;
            string slug = string.IsNullOrEmpty(Slug) ? "slug not set" : Slug!;
            return $"{name}, {slug}";
        }
    }
}

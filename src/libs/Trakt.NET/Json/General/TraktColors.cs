namespace TraktNET
{
    /// <summary>Dominant color palettes for the content's images.</summary>
    public record class TraktColors
    {
        /// <summary>Dominant colors for the poster image.</summary>
        public List<string>? Poster { get; set; }
    }
}
